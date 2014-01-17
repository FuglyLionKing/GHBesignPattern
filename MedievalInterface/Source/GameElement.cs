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
        public Point Position;
        public string Label;
        public string ImagePath;

        public GameElement(Point position, string label, string imagePath)
        {
            this.Position = position;
            this.Label = label;
            this.ImagePath = imagePath;
        }
    }
}
