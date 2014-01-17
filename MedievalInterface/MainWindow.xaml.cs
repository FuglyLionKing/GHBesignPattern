using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MedievalInterface.Source;

namespace MedievalInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int GridRows = 10;
        private const int GridColumns = 10;

        public MainWindow()
        {
            InitializeComponent();
            this.CreateGrid();
        }

        private void CreateGrid()
        {
            var label = new Label()
            {
                Content = "toto"
            };
            for (var i = 0; i < GridRows; i++)
            {
                MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50) });
                for (var j = 0; j < GridColumns; j++)
                {
                    MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });

                }
            }
            //this.FeedCell(new CellContent(new Point(6, 0), "#FF0000"));

            //this.FeedCell(new CellContent(new GameElement(new Point(0, 7), "Toto", null), "#FF0FF0"));
        }

        private void FeedGrid()
        {
            var gridElements = new List<Object>();
            foreach (var gridElement in gridElements)
            {
                if (gridElement.GetType() == typeof (Object))
                {
                    //this.FeedCell(new CellContent(new Point(6, 0), "#FF0000"));
                }
                else
                {
                    //this.FeedCell(new CellContent(new GameElement(new Point(0, 7), "Toto", null), "#FF0FF0"));
                }
            }
        }

        private void FeedCell(CellContent cell)
        {
            MainGrid.Children.Add(cell);
            Grid.SetColumn(cell, (int)cell.Position.Y);
            Grid.SetRow(cell, (int)cell.Position.X);
        }

        //private void FlushGridRow();
        //MainGrid.Children.

        private void FlushAllGrid()
        {
            MainGrid.Children.RemoveRange(0, MainGrid.Children.Count);
        }

        //private void active

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            //this.FlushGrid();
        }
    }
}
