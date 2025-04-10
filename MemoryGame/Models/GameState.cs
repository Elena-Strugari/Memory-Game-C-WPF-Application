using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class GameState
    {
        public List<string> TileImages { get; set; } = new List<string>();
        public bool[] FlippedTiles { get; set; } = Array.Empty<bool>();
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int TimeLeft { get; set; }
        public string Category { get; set; }
        public string Username { get; set; }


    }
}
