﻿using System.Windows;
using System.Windows.Controls;
using GHBesignPattern.Controller.Simulation;
using GHBesignPattern.Model.Boards;
using MedievalInterface.Source;
using MedievalWarfare.MedivalWarfare;


namespace MedievalInterface
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IZone[,] _zones;
        ISimulation simulation = SimulationFactory.GenerateSimpleSimulation();

        public MainWindow()
        {
            InitializeComponent();
            this.InitGrid();
            this.CreateGrid();
        }

        private void InitGrid()
        {
            
            this._zones = simulation.Board;
        }

        private void CreateGrid()
        {
            for (var i = 0; i < _zones.GetLength(0); i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                for (var j = 0; j < _zones.GetLength(1); j++)
                {
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                }
            }
        }

        private void FeedGrid()
        {
            this.FlushAllGrid();
            for (var i = 0; i < _zones.GetLength(0); i++)
            {
                for (var j = 0; j < _zones.GetLength(1); j++)
                {
                    var zone = _zones[i,j];
                    CellContent cellContent = null;
                    foreach (var character in zone.Characters)
                    {
                        cellContent = new CellContent(new GameElement(new Point(i, j), character.Name, null), "#CCCCCC");
                        this.FeedCell(cellContent);
                    }
                    foreach (var item in zone.Items)
                    {
                        if (cellContent == null)
                        {
                            this.FeedCell(new CellContent(new GameElement(new Point(i, j), item.Name, null), "#101010"));
                        }
                        else
                        {
                            cellContent.addElement(new GameElement(new Point(i, j), item.Name, null));
                        }
                    }
                }
            }
            //System.Delegate
            MainGrid.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, (NoArgDelegate)
                delegate { });
        }

        private delegate void NoArgDelegate();

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
            var runner = new SimpleSimulationRunner { UpdateDisplayer = FeedGrid, _simulation =  this.simulation };
            runner.Start();
        }
    }
}
