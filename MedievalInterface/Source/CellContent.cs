using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedievalInterface.Source
{
    class CellContent : WrapPanel
    {
        public Point Position;
        public String ImagePath;
        public List<GameElement> gameElements = new List<GameElement>();

        public CellContent(Point position, String color)
        {
            this.Position = position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color)); 
        }

        public CellContent(GameElement element, String color)
        {
            this.gameElements.Add(element);
            this.Position = element.Position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color));
            this.Children.Add(new Label() { Content = element.Label });
            this.ImagePath = element.ImagePath;
        }

        public void addElement(GameElement element)
        {
            this.gameElements.Add(element);
            this.Children.Add(new Label() { Content = element.Label });
        }
    }
}
