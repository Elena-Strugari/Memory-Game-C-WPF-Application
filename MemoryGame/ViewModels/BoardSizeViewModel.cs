using MemoryGame.Commands;
using MemoryGame.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MemoryGame.ViewModels
{
    public class BoardSizeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<int> EvenSizes { get; } = new ObservableCollection<int> { 2, 4, 6 };

        private int _selectedRows = 4;
        private int _selectedColumns = 4;

        public int SelectedRows
        {
            get => _selectedRows;
            set { _selectedRows = value; OnPropertyChanged(); }
        }

        public int SelectedColumns
        {
            get => _selectedColumns;
            set { _selectedColumns = value; OnPropertyChanged(); }
        }

        public ICommand StartCommand { get; }

        public BoardSizeViewModel()
        {
            StartCommand = new RelayCommand(_ => StartGame());
        }

        private void StartGame()
        {
            GameConfiguration.Rows = SelectedRows;
            GameConfiguration.Columns = SelectedColumns;
            GameConfiguration.TimeLimit = 60;

            var gameView = new GameView();
            gameView.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.BoardSizeView)
                ?.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
