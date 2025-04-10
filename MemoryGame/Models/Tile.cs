using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class Tile : INotifyPropertyChanged
    {
        private bool _isFlipped;
        private string _imagePath;

        public bool IsFlipped
        {
            get => _isFlipped;
            set { _isFlipped = value; OnPropertyChanged(); }
        }

        public string ImagePath
        {
            get => _imagePath;
            set { _imagePath = value; OnPropertyChanged(); }
        }

        public string BackImagePath => "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag8.jpg";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    //public class Tile
    //{
    //    public string ImagePath { get; set; }         // Calea către imaginea afișată când este întoarsă
    //    public bool IsFlipped { get; set; }           // Dacă este întoarsă
    //    public bool IsMatched { get; set; }           // Dacă a fost deja găsită o pereche

    //    public Tile(string imagePath)
    //    {
    //        ImagePath = imagePath;
    //        IsFlipped = false;
    //        IsMatched = false;
    //    }
    //}
}
