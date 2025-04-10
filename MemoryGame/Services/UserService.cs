using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MemoryGame.Services
{
    public static class UserService
    {
        private static readonly string FilePath = "users.json";

        public static ObservableCollection<User> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new ObservableCollection<User>();

            try
            {
                var json = File.ReadAllText(FilePath);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                return new ObservableCollection<User>(users ?? new List<User>());
            }
            catch
            {
                return new ObservableCollection<User>();
            }
        }

        public static void SaveUsers(IEnumerable<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static void AddUser(User newUser)
        {
            var users = LoadUsers();
            users.Add(newUser);
            SaveUsers(users);
        }

        public static void DeleteUser(User userToDelete)
        {
            var users = LoadUsers();
            var user = users.FirstOrDefault(u => u.Username == userToDelete.Username);
            if (user != null)
            {
                users.Remove(user);
                SaveUsers(users);
            }
        }
    }
}
