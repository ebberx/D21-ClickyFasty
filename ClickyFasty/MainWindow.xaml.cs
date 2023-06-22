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
using System.Diagnostics;

namespace ClickyFasty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch sw = new Stopwatch();
        int counter = 20;
        public MainWindow()
        {
            InitializeComponent();

            Button btnStart = new Button();
            btnStart.Content = "start";
            btnStart.Width = 50;
            btnStart.Height = 30;
            btnStart.Click += start;
            grid.Children.Add(btnStart);

        }

        private void start(object sender, EventArgs e) {
            sw.Start();
            click(sender, e);
        }

        private void click(object sender, EventArgs e) {
            if (counter != 0)
            {
                SpawnButton(counter);
                counter--;
            }
            else
            {
                sw.Stop();
                Label result = new Label();
                result.Content = "The result was " + sw.Elapsed.TotalSeconds + " seconds.";
                result.HorizontalAlignment = HorizontalAlignment.Center;
                result.FontSize = 28;
                grid.Children.Add(result);
            }
            grid.Children.Remove((UIElement)sender);
        }

        public void SpawnButton(int counter) {
            Button btn = new Button();
            btn.Content = counter;
            btn.Width = 50;
            btn.Height = 30;
            btn.Click += click;
            Random rand = new Random();
            btn.Margin = new Thickness(rand.Next(-800, 800),rand.Next(-450,450),0,0);
            grid.Children.Add(btn);
        }
    }
}
