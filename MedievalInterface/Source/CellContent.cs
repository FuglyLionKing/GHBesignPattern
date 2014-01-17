﻿using System;
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
        public List<GameElement> gameElements;

        public CellContent(Point position, String color)
        {
            this.Position = position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color)); 
        }

        public CellContent(GameElement element, String color)
        {
            this.Position = element.Position;
            this.Background = (Brush)(new BrushConverter().ConvertFrom(color));
            this.Children.Add(new Label() { Content = element.Label });
            this.ImagePath = element.ImagePath;
        }
    }
}
