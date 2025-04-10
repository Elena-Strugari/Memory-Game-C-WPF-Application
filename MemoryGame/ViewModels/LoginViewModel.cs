using MemoryGame.Commands;
using MemoryGame.Models;
using MemoryGame.Services;
using MemoryGame.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MemoryGame.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }
        private User _selectedUser;

        public User SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public ICommand CreateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand PlayCommand { get; }

        public LoginViewModel()
        {
            Users = UserService.LoadUsers();
            CreateUserCommand = new RelayCommand(_ => OpenCreateUser());
            DeleteUserCommand = new RelayCommand(_ => DeleteUser(), _ => SelectedUser != null);
            PlayCommand = new RelayCommand(_ => PlayGame(), _ => SelectedUser != null);
        }

        private void OpenCreateUser()
        {
            Window loginWindow = Application.Current.Windows
            .OfType<Window>()
            .FirstOrDefault(w => w is Views.LoginView);

            loginWindow?.Hide(); 

            var window = new CreateUserView();
            window.ShowDialog();

            loginWindow?.Close(); 

            // Reîncarcă utilizatorii
            Users = UserService.LoadUsers();
            OnPropertyChanged(nameof(Users));
        }

        //private void DeleteUser()
        //{
        //    if (MessageBox.Show($"Are you sure you want to delete user '{SelectedUser.Username}'?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        UserService.DeleteUser(SelectedUser);
        //        Users.Remove(SelectedUser);
        //        SelectedUser = null;
        //        OnPropertyChanged(nameof(Users));
        //    }
        //}
        private void DeleteUser()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Selectați un utilizator pentru a-l șterge.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (MessageBox.Show($"Sigur doriți să ștergeți utilizatorul '{SelectedUser.Username}'?", "Confirmare", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // 1. Șterge utilizatorul din colecția de utilizatori
                UserService.DeleteUser(SelectedUser);
                Users.Remove(SelectedUser);

                // 2. Șterge datele utilizatorului din fișierele de joc
                GameService.DeleteGamesByUser(SelectedUser.Username);

                // 3. Șterge datele utilizatorului din fișierul de statistici
                StatisticsService.DeleteStatisticsByUser(SelectedUser.Username);

                SelectedUser = null;
                OnPropertyChanged(nameof(Users));
            }
        }


        private void PlayGame()
        {
            GameConfiguration.CurrentUser = SelectedUser;
            var menu = new MainMenuView();
            menu.Show();
            Application.Current.Windows
            .OfType<Window>().FirstOrDefault(w => w is Views.LoginView).Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
