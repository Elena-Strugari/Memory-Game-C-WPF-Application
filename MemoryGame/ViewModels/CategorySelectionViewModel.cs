using MemoryGame.Commands;
using MemoryGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MemoryGame.ViewModels
{
    public class CategorySelectionViewModel
    {
        public ICommand ChooseColorCommand { get; }
        public ICommand ChooseSketchCommand { get; }
        public ICommand ChooseGrayScaleCommand { get; }

        public ICommand CustomBoardCommand { get; }
        public ICommand StandardBoardCommand { get; }


        public ICommand BackCommand { get; }
        public CategorySelectionViewModel()
        {
            ChooseColorCommand = new RelayCommand(_ => Choose("Color"));
            ChooseSketchCommand = new RelayCommand(_ => Choose("Sketch"));
            ChooseGrayScaleCommand = new RelayCommand(_ => Choose("GrayScale"));

            CustomBoardCommand = new RelayCommand(_ => OpenCustomBoardSize());
            StandardBoardCommand = new RelayCommand(_ => OpenStandardBoard());


            BackCommand = new RelayCommand(_ => GoBack());
        }

        private void Choose(string category)
        {
            GameConfiguration.SelectedCategory = category;

            //Exemplu: poți seta o listă de imagini în funcție de categorie
            GameConfiguration.SelectedCategory = category;
            GameConfiguration.SelectedImages = category switch
            {
                "Color" => new List<string>
                {
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag1.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag2.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag3.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag4.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag5.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag6.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag7.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Color\\Imag8.jpg",
                    
                },
                "Sketch" => new List<string>
                {
                     "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag1.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag2.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag3.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag4.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag5.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag6.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag7.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag8.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag9.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag10.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag11.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\Sketch\\Imag12.jpg",

                },
                "GrayScale" => new List<string>
                {
                     "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag1.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag2.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag3.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag4.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag5.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag6.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag7.jpg",
                    "C:\\Users\\elena\\OneDrive\\Documente\\Facultate-INFORMATICA\\An_2\\sem2\\MAP\\MemoryGame\\MemoryGame\\Resources\\GrayScale\\Imag8.jpg",

                },
                _ => new List<string>()
            };

        }

        private void OpenStandardBoard()
        {
            GameConfiguration.Rows = 4;
            GameConfiguration.Columns = 4;
            GameConfiguration.TimeLimit = 60;

            var gameWindow = new GameView();
            gameWindow.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.CategorySelectionView)
                ?.Close();
        }
        private void OpenCustomBoardSize()
        {
            var customBoardSizeView = new BoardSizeView();
            customBoardSizeView.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.CategorySelectionView)
                ?.Close();
        }


        private void GoBack()
        {
            var menu = new MainMenuView();
            menu.Show();

            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w is Views.CategorySelectionView)
                ?.Close();
        }

    }
}
