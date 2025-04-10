using MemoryGame.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MemoryGame.Views;
using MemoryGame.Services;
using MemoryGame.Models;

namespace MemoryGame.ViewModels
{
    public class MainMenuViewModel
    {
        private readonly Window _menuWindow;

        public ICommand NewGameCommand { get; }
        public ICommand LoadGameCommand { get; }
        public ICommand StatisticsCommand { get; }
        public ICommand ExitCommand { get; }

        public MainMenuViewModel(Window menuWindow)
        {
            _menuWindow = menuWindow;

            NewGameCommand = new RelayCommand(_ => StartNewGame());
            LoadGameCommand = new RelayCommand(_ => LoadGame());
            StatisticsCommand = new RelayCommand(_ => ShowStatistics());
            ExitCommand = new RelayCommand(_ => ExitApp());
        }

        private void StartNewGame()
        {
            var categoryWindow = new CategorySelectionView();
            categoryWindow.Show();
            _menuWindow?.Close();
        }

        private void LoadGame()
        {
            if (!GameService.HasSavedGame())
            {
                MessageBox.Show("Nu există un joc salvat.");
                return;
            }
            GameConfiguration.LoadingFromSave = true;
            var gameView = new GameView();
            gameView.Show();

            _menuWindow?.Close();
        }



        private void ShowStatistics()
        {
            var statsWindow = new StatisticsView();
            statsWindow.Show();
            _menuWindow?.Close();
        }

        private void ExitApp()
        {
            Application.Current.Shutdown();
        }
    }

}
