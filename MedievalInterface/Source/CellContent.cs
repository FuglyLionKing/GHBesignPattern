using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MedievalInterface.Source
{
    class CellContent : WrapPanel
    {
        public Point Position;
        public String ImagePath;
        public List<GameElement> gameElements = new List<GameElement>();
        public MainWindow window;
        public bool activated = false;

        public CellContent(Point position, String color)
        {
            this.Position = position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color)); 
        }

        public CellContent(MainWindow window, GameElement element, String color)
        {
            this.window = window;
            this.gameElements.Add(element);
            this.Position = element.Position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color));
            this.Children.Add(new Label() { Content = element.Label });
            this.ImagePath = element.ImagePath;
            this.MouseLeftButtonUp += CellContent_Click;
        }

        private void CellContent_Click(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            //
        }

        public void addElement(GameElement element)
        {
            this.gameElements.Add(element);
            this.Children.Add(new Label() { Content = element.Label });
        }
    }
}
