using MemoryGame.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using MemoryGame.Views;
using MemoryGame.Models;
using MemoryGame.Services;

namespace MemoryGame.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private int _timeLeft;
        private bool _isPaused;

        public ObservableCollection<Tile> Tiles { get; set; }
        public ICommand FlipTileCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand SaveGameCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ContinueCommand { get; }

        private Tile _firstSelectedTile;
        private Tile _secondSelectedTile;
        private bool _isCheckingMatch = false;
        private Statistics _statistics;

        public string TimeLeftDisplay => _isPaused ? "Paused" : _timeLeft.ToString();

        public GameViewModel()
        {
            FlipTileCommand = new RelayCommand(param => FlipTile(param as Tile));
            PauseCommand = new RelayCommand(_ => PauseGame());
            SaveGameCommand = new RelayCommand(_ => SaveGame());
            ExitCommand = new RelayCommand(_ => ExitGame());
            ContinueCommand = new RelayCommand(_ => ContinueGame());



            if (GameConfiguration.LoadingFromSave)
            {
                LoadGame();
                GameConfiguration.LoadingFromSave = false;

            }
            else
            {
                InitializeTiles();
                StartTimer();
            }
        }

        private void InitializeTiles()
        {
            Tiles = new ObservableCollection<Tile>();
            _statistics = StatisticsService.LoadStatistics();
            _statistics.Username= GameConfiguration.CurrentUser.Username;
            _statistics.GamesPlayed++;

            // StatisticsService.SaveStatistics(_statistics);
            try
            {
                StatisticsService.SaveStatistics(_statistics);
                GameConfiguration.CurrentUser.GamesPlayed = _statistics.GamesPlayed;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea statisticilor: {ex.Message}", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            int totalTiles = GameConfiguration.Rows * GameConfiguration.Columns;

            var images = GameConfiguration.SelectedImages
                .SelectMany(img => Enumerable.Repeat(img, 2)) 
                .Take(totalTiles)
                .OrderBy(_ => Guid.NewGuid())
                .ToList();

            foreach (var img in images)
            {
                Tiles.Add(new Tile { ImagePath = img, IsFlipped = false });
            }

            OnPropertyChanged(nameof(Tiles));
        }

        private async void FlipTile(Tile tile)
        {
            if (tile == null || _isPaused || tile.IsFlipped || _isCheckingMatch)
                return;

            tile.IsFlipped = true;

            if (_firstSelectedTile == null)
            {
                _firstSelectedTile = tile;
            }
            else
            {
                _secondSelectedTile = tile;
                _isCheckingMatch = true;

                await Task.Delay(800); // timp de vizualizare

                if (_firstSelectedTile.ImagePath == _secondSelectedTile.ImagePath)
                {
                    // pereche corecta → se lasa 
                }
                else
                {
                    // nu sunt pereche → se intorc 
                    _firstSelectedTile.IsFlipped = false;
                    _secondSelectedTile.IsFlipped = false;
                }

                _firstSelectedTile = null;
                _secondSelectedTile = null;
                _isCheckingMatch = false;
            }
            if (AreAllTilesFlipped())
            {
                _timer.Stop();
                _statistics.GamesWon++;
                StatisticsService.SaveStatistics(_statistics);
                GameConfiguration.CurrentUser.GamesWon = _statistics.GamesWon;

                MessageBox.Show("🎉 Felicitări! Ai terminat jocul!", "Victory", MessageBoxButton.OK, MessageBoxImage.Information);
                ExitGame();
            }
            _isCheckingMatch = false;


            OnPropertyChanged(nameof(Tiles));
        }


        private void StartTimer()
        {
             _timeLeft = GameConfiguration.TimeLimit;
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (s, e) =>
            {
                if (!_isPaused)
                {
                    _timeLeft--;
                    OnPropertyChanged(nameof(TimeLeftDisplay));

                    if (_timeLeft <= 0)
                    {
                        _timer.Stop();
                        _statistics.GamesLost++;
                        StatisticsService.SaveStatistics(_statistics);
                        GameConfiguration.CurrentUser.GamesLost = _statistics.GamesLost;
                        MessageBox.Show("⏰ Time's up!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                        ExitGame();
                    }
                }
            };
            _timer.Start();
        }

        private void PauseGame()
        {
            _isPaused = true;
            OnPropertyChanged(nameof(TimeLeftDisplay));
        }

        private void ContinueGame()
        {
            _isPaused = false;
            OnPropertyChanged(nameof(TimeLeftDisplay));
        }

        private void SaveGame()
        {
            var gameState = new GameState
            {
                Rows = GameConfiguration.Rows,
                Columns = GameConfiguration.Columns,
                TimeLeft = _timeLeft,
                Category = GameConfiguration.SelectedCategory, 
                Username = GameConfiguration.CurrentUser.Username, 
                TileImages = GameConfiguration.SelectedImages.ToList(),
                FlippedTiles = Tiles.Select(t => t.IsFlipped).ToArray()
            };

            try
            {
                GameService.SaveGame(gameState);
                MessageBox.Show("Joc salvat cu succes.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea jocului: {ex.Message}", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitGame()
        {
            var menu = new MainMenuView();
            menu.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.GameView)
                ?.Close();
        }
        private bool AreAllTilesFlipped()
        {
            return Tiles.All(tile => tile.IsFlipped);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
        private void LoadGame()
        {
            try
            {
                var gameState = GameService.LoadGame();
                if (gameState == null)
                {
                    MessageBox.Show("Nu există un joc salvat.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                GameConfiguration.Rows = gameState.Rows;
                GameConfiguration.Columns = gameState.Columns;
                GameConfiguration.SelectedCategory = gameState.Category;
                GameConfiguration.CurrentUser = new User { Username = gameState.Username };
                GameConfiguration.SelectedImages = gameState.TileImages;
                _timeLeft = gameState.TimeLeft;
                GameConfiguration.TimeLimit = _timeLeft;
                OnPropertyChanged(nameof(TimeLeftDisplay));
                StartTimer();

               
                Tiles = new ObservableCollection<Tile>();
                for (int i = 0; i <gameState.TileImages.Count; i++)
                {
                    Tiles.Add(new Tile
                    {
                        ImagePath = gameState.TileImages[i],
                        IsFlipped = gameState.FlippedTiles[i]
                    });
                }
                OnPropertyChanged(nameof(Tiles));

                MessageBox.Show("Joc încărcat cu succes.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea jocului: {ex.Message}", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }



    public class Tile : INotifyPropertyChanged
    {
        private bool _isFlipped;
        public bool IsFlipped
        {
            get => _isFlipped;
            set { _isFlipped = value; OnPropertyChanged(); }
        }

        public string ImagePath { get; internal set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
