using System;
using System.Windows;
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
    public partial class MainWindow
    {
/// <summary>
/// TODO : 
/// Dans les interfaces MovingBehavior ajouter en membres un defaultDistance -> correspond a la distance par default de déplacement
/// Nerroyer l'ensemble des projets
/// 
/// Ajouter les zones des distances de vues
/// Ajouter une liste pour selectionner les Characters
/// Ajouter des Characters
/// Ajouter des Items
/// 
/// 
/// </summary>
        IZone[,] _zones;
        readonly ISimulation _simulation = SimulationFactory.GenerateSimpleSimulation();

        public MainWindow()
        {
            InitializeComponent();
            InitGameElements();
            InitGrid();
            CreateGrid();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void InitGameElements()
        {
            for (var i = 0; i < _zones.GetLength(0); i++)
            {
                for (var j = 0; j < _zones.GetLength(1); j++)
                {
                    var zone = _zones[i, j];

                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void InitGrid()
        {
            
            _zones = _simulation.Board;
        }

        private void CreateGrid()
        {
            var height = _zones.GetLength(0);
            var width = _zones.GetLength(1);
            const int cellSize = 20;

            for (var i = 0; i < height; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(cellSize) });   
            }
            for (var j = 0; j < width; j++)
            {
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(cellSize) });
            }
            var parent = (Border)MainGrid.Parent;
            parent.Height = cellSize*height;
            parent.Width = cellSize*width;
        }

        private void FeedGrid()
        {
            FlushAllGrid();
            for (var i = 0; i < _zones.GetLength(0); i++)
            {
                for (var j = 0; j < _zones.GetLength(1); j++)
                {
                    var zone = _zones[i,j];
                    CellContent cellContent = null;
                    foreach (var character in zone.Characters)
                    {
                        cellContent = new CellContent(this, new GameElement(new Point(i, j), character.Name, null), "#FF0000");
                        FeedCell(cellContent);
                        CreateLookField(cellContent.Position, 5);
                    }
                    foreach (var item in zone.Items)
                    {
                        if (cellContent == null)
                        {
                            FeedCell(new CellContent(null, new GameElement(new Point(i, j), item.Name, null), "#00FF00"));
                        }
                        else
                        {
                            cellContent.addElement(new GameElement(new Point(i, j), item.Name, null));
                        }
                    }
                }
            }
            MainGrid.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle, (NoArgDelegate) delegate { });
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

        private void CreateLookField(Point position, int distance)
        {
            for (var i = 1; i < distance; i++)
            {
                if (position.Y + i < _zones.GetLongLength(0)) FeedCell(new CellContent(new Point(position.X, position.Y + i ), "#cccccc"));
                if (position.Y - i >= 0) FeedCell(new CellContent(new Point(position.X, position.Y - i), "#cccccc"));
                if (position.X + i < _zones.GetLongLength(1)) FeedCell(new CellContent(new Point(position.X + i, position.Y), "#cccccc"));
                if (position.X - i >= 0) FeedCell(new CellContent(new Point(position.X - i, position.Y), "#cccccc"));
            }
        }

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            var runner = new SimpleSimulationRunner { UpdateDisplayer = FeedGrid, _simulation =  _simulation };
            runner.Start();
        }
    }
}
