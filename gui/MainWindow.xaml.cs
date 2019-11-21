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
        private const double FPS = 60.0;


        public MainWindow()
        {
            InitializeComponent();
            new Player("Me");
            Grid.Width = World.WIDTH;
            Grid.Height = World.HEIGHT;
            Timer timer = new Timer(1000 / FPS);
            timer.Elapsed += OnFrame;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnFrame(Object source, ElapsedEventArgs e)
        {
            Canvas.Dispatcher.Invoke(new Action(() => Canvas.Children.Clear()));

            foreach (Player player in World.Instance.Players)
            {
                Canvas.Dispatcher.Invoke(new Action(() =>
                {
                    Ellipse circle;



                    circle = new Ellipse();


                    circle.Stroke = System.Windows.Media.Brushes.Black;
                    circle.Fill = System.Windows.Media.Brushes.DarkBlue;
                    circle.HorizontalAlignment = HorizontalAlignment.Left;
                    circle.VerticalAlignment = VerticalAlignment.Center;
                    circle.Width = 0;
                    circle.Height = 0;
                    Canvas.Children.Add(circle);




                    Point mousePos = Mouse.GetPosition(Canvas);
                    Point playerPos = new Point(player.Possition.X + (player.Mass), player.Possition.Y + (player.Mass));

                    Vector direction = new Vector(mousePos.X - playerPos.X, mousePos.Y - playerPos.Y);
                    // direction.Normalize();
                    direction = direction / 10.0;
                    player.Direction = direction;
                    player.move();




                    circle.Width = player.Mass * 2;
                    circle.Height = player.Mass * 2;

                    // Console.WriteLine(player.Possition.X + " " + player.Possition.Y);

                    Canvas.SetLeft(circle, player.Possition.X);
                    Canvas.SetTop(circle, player.Possition.Y);

                }));



            }
        }


    }


}
