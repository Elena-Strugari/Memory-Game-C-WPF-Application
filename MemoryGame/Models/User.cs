﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class User
    {
        public string Username { get; set; }
        public string AvatarPath { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}
