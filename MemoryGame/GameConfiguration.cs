using MemoryGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public static class GameConfiguration
    {
        public static int Rows { get; set; } = 4;
        public static int Columns { get; set; } = 4;
        public static int TimeLimit { get; set; } = 60;
        public static string SelectedCategory { get; set; } = string.Empty;
        public static List<string> SelectedImages { get; set; } = new List<string>();
        public static User CurrentUser { get; set; }
        public static bool LoadingFromSave { get; set; } = false;

    }
}

