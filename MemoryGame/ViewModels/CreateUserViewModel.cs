using MemoryGame.Commands;
using MemoryGame.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using MemoryGame.Views;
using MemoryGame.Services;

namespace MemoryGame.ViewModels
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _avatarPath;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string AvatarPath
        {
            get => _avatarPath;
            set { _avatarPath = value; OnPropertyChanged(); }
        }

        public ICommand BrowseAvatarCommand { get; }
        public ICommand CreateCommand { get; }

        public ObservableCollection<string> AvatarPaths { get; set; }
        private int _currentAvatarIndex;
        public string SelectedAvatar
        {
            get => AvatarPaths.Count > 0 ? AvatarPaths[_currentAvatarIndex] : null;
            set
            {
                _avatarPath = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(AvatarPath));
            }
        }


        public ICommand NextAvatarCommand { get; }
        public ICommand PreviousAvatarCommand { get; }

        public CreateUserViewModel()
        {
            AvatarPaths = new ObservableCollection<string>
            {
                "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Avatars\\avatar1.jpg",
                "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Avatars\\avatar2.jpg",
                "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Avatars\\avatar3.jpg",
                "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Avatars\\avatar4.jpg",
                "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Avatars\\avatar5.jpg",
               
            };



            CreateCommand = new RelayCommand(CreateUser, CanCreate);
           // CreateCommand = new RelayCommand(CreateUser);
            NextAvatarCommand = new RelayCommand(_ => NextAvatar());
            PreviousAvatarCommand = new RelayCommand(_ => PreviousAvatar());
        }

        private void NextAvatar()
        {
            _currentAvatarIndex = (_currentAvatarIndex + 1) % AvatarPaths.Count;
            AvatarPath = SelectedAvatar;
            OnPropertyChanged(nameof(SelectedAvatar));
        }

        private void PreviousAvatar()
        {
            _currentAvatarIndex = (_currentAvatarIndex - 1 + AvatarPaths.Count) % AvatarPaths.Count;
            AvatarPath = SelectedAvatar;
            OnPropertyChanged(nameof(SelectedAvatar));
        }

        private void CreateUser(object obj)
        {
            var user = new User { Username = Username, AvatarPath = AvatarPath };
            UserService.AddUser(user);

            var window = new MainMenuView();
            window.Show();

            Application.Current.Windows
           .OfType<Window>().FirstOrDefault(w => w is Views.CreateUserView).Close();
        }

        private bool CanCreate(object obj) => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(AvatarPath);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
