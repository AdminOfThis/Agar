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
        public MainWindow()
        {
            InitializeComponent();
            new Player("Me");
            Grid.Width = World.WIDTH;
            Grid.Height = World.HEIGHT;
            Timer timer = new Timer(1000);
            timer.Elapsed += OnFrame;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
    
    public void OnFrame(Object source, ElapsedEventArgs e) {
            Console.WriteLine("TEST");
            Canvas.Dispatcher.Invoke(new Action(() => Canvas.Children.Clear()));
            foreach(Player player in World.Instance.Players)
            {
                Canvas.Dispatcher.Invoke(new Action(() => { 
                Ellipse circle = new Ellipse();
                    circle.Stroke = System.Windows.Media.Brushes.Black;
                    circle.Fill = System.Windows.Media.Brushes.DarkBlue;
                    circle.HorizontalAlignment = HorizontalAlignment.Left;
                    circle.VerticalAlignment = VerticalAlignment.Center;
                    circle.Width = 50;
                    circle.Height = 50;
                    Canvas.Children.Add(circle);
                    Console.WriteLine(player.Position.X + " " + player.Position.Y);
                Canvas.SetLeft(circle, player.Position.X);
                Canvas.SetTop(circle, player.Position.Y);
                }));
            }
        }
    }

    
}
