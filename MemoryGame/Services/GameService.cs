using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryGame.Services
{
    public static class GameService
    {
        private static readonly string GameStateFile = "gamestate.json";

        public static void SaveGame(GameState state)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(state);
            System.IO.File.WriteAllText(GameStateFile, json);
        }

        public static GameState LoadGame()
        {
            if (!System.IO.File.Exists(GameStateFile)) return null;

            var json = System.IO.File.ReadAllText(GameStateFile);
            return System.Text.Json.JsonSerializer.Deserialize<GameState>(json);
        }

        public static bool HasSavedGame() => System.IO.File.Exists(GameStateFile);

        public static void DeleteSavedGame()
        {
            if (System.IO.File.Exists(GameStateFile))
                System.IO.File.Delete(GameStateFile);
        }
        public static void DeleteGamesByUser(string username)
        {
            if (!File.Exists(GameStateFile))
                return;

            var game = LoadGame();
            if (game != null && game.Username == username)
            {
                File.Delete(GameStateFile);
            }
        }
    }
}
