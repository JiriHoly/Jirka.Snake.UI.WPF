using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Jirka.Snake.Logic;

namespace Jirka.Snake.UI.WPF.Class
{
    internal class Renderer
    {
        private Grid GameGrid { get; set; }

        public Renderer(Grid gameGrid, int sizeOfTheGrid)
        {
            // Make clear GameGrid
            this.GameGrid = gameGrid;

            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < sizeOfTheGrid -1; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < sizeOfTheGrid -1; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void RenderGrid(List<Point> Points)
        {
            GameGrid.Children.Clear();

            // var point = Game.Level.Board.ListPoints;

            var pointsToRender = Points.Where(x => x.Status == Logic.Enums.PointStatus.Snake || x.Status == Logic.Enums.PointStatus.Food).ToList();


            foreach (var item in pointsToRender)
            {
                Rectangle rec = new Rectangle();

                switch (item.Status)
                {
                    case Logic.Enums.PointStatus.Snake:
                        rec.Fill = Brushes.Black;
                        break;
                    case Logic.Enums.PointStatus.Food:
                        rec.Fill = Brushes.Green;
                        break;
                    default:
                        rec.Fill = Brushes.White;
                        break;
                }

                Grid.SetRow(rec, item.X);
                Grid.SetColumn(rec, item.Y);
                GameGrid.Children.Add(rec);
            }

        }

    }
}
