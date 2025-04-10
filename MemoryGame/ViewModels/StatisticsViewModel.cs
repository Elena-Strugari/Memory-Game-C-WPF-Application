using MemoryGame.Commands;
using MemoryGame.Models;
using MemoryGame.Services;
using MemoryGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MemoryGame.ViewModels
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private Statistics _statistics;

        public int TotalGamesPlayed
        {
            get => _statistics.GamesPlayed;
            set
            {
                _statistics.GamesPlayed = value;
                OnPropertyChanged();
            }
        }

        public int GamesWon
        {
            get => _statistics.GamesWon;
            set
            {
                _statistics.GamesWon = value;
                OnPropertyChanged();
            }
        }

        public int GamesLost
        {
            get => _statistics.GamesLost;
            set
            {
                _statistics.GamesLost = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<User> Leaderboard { get; set; }
        public ICommand BackCommand { get; }
        public ICommand HelpCommand { get; }

        public StatisticsViewModel()
        {
            _statistics = StatisticsService.LoadStatistics();
            BackCommand = new RelayCommand(_ => GoBack());
            HelpCommand = new RelayCommand(_ => ShowHelp());

            var allUsers = UserService.LoadUsers();
            Leaderboard = new ObservableCollection<User>(allUsers.OrderByDescending(u => u.GamesWon));

            User current = GameConfiguration.CurrentUser;
            if (current != null)
            {
                _statistics.Username = current.Username;
                _statistics.GamesPlayed = current.GamesPlayed;
                _statistics.GamesWon = current.GamesWon;
                _statistics.GamesLost = current.GamesLost;

                StatisticsService.SaveStatistics(_statistics);
            }
        }

        private void GoBack()
        {
            var menu = new MainMenuView();
            menu.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.StatisticsView)
                ?.Close(); 
        }

        private void ShowHelp()
        {
            string message = "👩‍🎓 Nume: Strugari Elena Raluca\n" +
                             "📧 Email: elena.strugari@student.unitbv.ro\n" +
                             "👥 Grupa: 10LF234\n" +
                             "📘 Specializarea: Informatică - Anul 2";

            MessageBox.Show(message, "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
