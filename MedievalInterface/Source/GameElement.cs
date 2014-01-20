using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedievalInterface.Source
{
    class GameElement
    {
        public 
        public string ImagePath;
        public bool IsSelected;


        public GameElement(Point position, string label, string imagePath, bool isSelected)
        {
            Position = position;
            Label = label;
            ImagePath = imagePath;
            IsSelected = isSelected;
        }
    }
}
