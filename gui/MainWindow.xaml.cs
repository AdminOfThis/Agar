using Agar.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<Player, Ellipse> map = new Dictionary<Player, Ellipse>();

        public MainWindow()
        {
            InitializeComponent();
            new Player("Me");
            Grid.Width = World.WIDTH;
            Grid.Height = World.HEIGHT;
            Timer timer = new Timer(1000 / 2.0);
            timer.Elapsed += OnFrame;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnFrame(Object source, ElapsedEventArgs e)
        {
            //Canvas.Dispatcher.Invoke(new Action(() => Canvas.Children.Clear()));

            foreach (Player player in World.Instance.Players)
            {
                Ellipse circle;
                map.TryGetValue(player, out circle);

                Canvas.Dispatcher.Invoke(new Action(() =>
                {
                    Point mousePos = Mouse.GetPosition(Canvas);
                    Point playerPos = new Point(player.Possition.X, player.Possition.Y);

                    Vector direction = new Vector(mousePos.X - playerPos.X, mousePos.Y - playerPos.Y);
                    // direction.Normalize();
                    direction = direction / 10.0;
                    player.Direction = direction;
                    player.move();


                    if (circle == null)
                    {
                        circle = new Ellipse();
                        map.Add(player, circle);

                        circle.Stroke = System.Windows.Media.Brushes.Black;
                        circle.Fill = System.Windows.Media.Brushes.DarkBlue;
                        circle.HorizontalAlignment = HorizontalAlignment.Left;
                        circle.VerticalAlignment = VerticalAlignment.Center;
                        circle.Width = 50;
                        circle.Height = 50;
                        Canvas.Children.Add(circle);

                    }
                    // Console.WriteLine(player.Possition.X + " " + player.Possition.Y);

                    Canvas.SetLeft(circle, player.Possition.X);
                    Canvas.SetTop(circle, player.Possition.Y);

                }));



            }
        }


    }


}
