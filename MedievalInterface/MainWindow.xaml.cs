using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GHBesignPattern.Controller.Simulation;
using GHBesignPattern.Model.Boards;
using MedievalInterface.Source;
using DesignPatternProject;

namespace MedievalInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IZone[,] zones;

        public MainWindow()
        {
            InitializeComponent();
            this.CreateGrid();
        }

        private void CreateGrid()
        {
            for (var i = 0; i < zones.GetLength(0); i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                for (var j = 0; j < zones.GetLength(1); j++)
                {
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                }
            }
        }

        private void FeedGrid()
        {
            this.FlushAllGrid();
            for (var i = 0; i < zones.GetLength(0); i++)
            {
                for (var j = 0; j < zones.GetLength(1); j++)
                {
                    var zone = zones[i,j];
                    foreach (var character in zone.Characters)
                    {
                        this.FeedCell(new CellContent(new GameElement(new Point(i, j), character.Name, null), "#CCCCCC"));
                    }
                    foreach (var item in zone.Characters)
                    {
                        this.FeedCell(new CellContent(new GameElement(new Point(i, j), item.Name, null), "#101010"));
                    }
                }
            }
        }

        private void FlushAllGrid()
        {
            MainGrid.Children.RemoveRange(0, MainGrid.Children.Count);
        }

        private void FeedCell(CellContent cell)
        {
            MainGrid.Children.Add(cell);
            Grid.SetColumn(cell, (int)cell.Position.Y);
            Grid.SetRow(cell, (int)cell.Position.X);
        }

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            var runner = new SimpleSimulationRunner { UpdateDisplayer = FeedGrid };
            runner.Start();
        }
    }
}
