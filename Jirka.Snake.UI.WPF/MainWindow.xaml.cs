using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Jirka.Snake.UI.WPF.Class;
using Jirka.Snake.Logic;

namespace Jirka.Snake.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        Renderer renderer;
        DispatcherTimer GameTimer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonStartGame_Click(object sender, RoutedEventArgs e)
        {
            // param for game will be read from config file in the future
            game = new Game(1, Logic.Enums.SizeOfTheGame.medium, Logic.Enums.SpeedOfTheGame.medium);
            renderer = new Renderer(GameGrid, ((int)game.SizeOfTheGame));

            

            GameTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(400)
            };
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();
            GameGrid.Focus();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                game.MoveSnake();
            } catch (ArgumentOutOfRangeException)
            {
                GameTimer.Stop();
                MessageBox.Show($"Narazili jste do zdi! Vaše skore je {game.player.Score}");
            }
            catch 
            {
                GameTimer.Stop();
                MessageBox.Show($"Narazili jste! Vaše skore je {game.player.Score}");
            }


            LabelScore.Content = game.player.Score.ToString();
            LabelBestScore.Content = game.player.BestScore.ToString();
            LabelPlayer.Content = game.player.Name;
            renderer.RenderGrid(game.Points);
            
        }

        private void GameGrid_KeyDownAction(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    game.ChangeActuallDirection(Logic.Enums.Direction.Up);
                    break;
                case Key.Down:
                    game.ChangeActuallDirection(Logic.Enums.Direction.Down);
                    break;
                case Key.Left:
                    game.ChangeActuallDirection(Logic.Enums.Direction.Left);
                    break;
                case Key.Right:
                    game.ChangeActuallDirection(Logic.Enums.Direction.Right);
                    break;
            } 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
