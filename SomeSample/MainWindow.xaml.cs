using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SomeSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private DispatcherTimer timer = new DispatcherTimer();
        private bool isPositiveWeight = true;
        private bool isPositiveHeight = true;
        public MainWindow() {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(1); // update 20 times/second
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e) {
            if(MyEllipse.Margin.Left == 1920) isPositiveWeight = false;
            if(MyEllipse.Margin.Left == 0) isPositiveWeight = true;
            if(MyEllipse.Margin.Top == 1080) isPositiveHeight = false;
            if(MyEllipse.Margin.Top == 0) isPositiveHeight = true;

            if(isPositiveWeight && isPositiveHeight)
                MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left + 10, MyEllipse.Margin.Top + 10, 0, 0);
            else if(isPositiveWeight && !isPositiveHeight)
                MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left + 10, MyEllipse.Margin.Top - 10, 0, 0);
            else if(!isPositiveWeight && isPositiveHeight)
                MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left - 10, MyEllipse.Margin.Top + 10, 0, 0);
            else
                MyEllipse.Margin = new Thickness(MyEllipse.Margin.Left - 10, MyEllipse.Margin.Top - 10, 0, 0);
        }

        private void Window_MouseLeftButtonDown(object sender, EventArgs e) {
            var ellipse = new Ellipse();
            ellipse.Fill = Brushes.Brown;
            ellipse.Height = 40;
            ellipse.Width = 40;
            ellipse.Stroke = Brushes.Black;
            var left = new Random().Next(0, 1920);
            var top = new Random().Next(0, 1080);
            ellipse.Margin = new Thickness(0, 0, left, top);
            MyGrid.Children.Add(ellipse);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
