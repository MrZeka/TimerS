using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TimerS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }
        private static System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private static bool isClicked = false;
        private static DateTime Date = new DateTime(0001, 01, 01, 0, 0, 1);
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            if (!isClicked)
            {
                Start_Stop.Content = "Stop";
                dispatcherTimer.Start();
                isClicked = true;
                OverTime.Content = "";
            }
            else if (isClicked)
            {
                Start_Stop.Content = "Start";
                dispatcherTimer.Stop();
                Date = new DateTime(0001, 01, 01, 0, 0, 1);
                isClicked = false;              
            }
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime Over = new DateTime(0001, 01, 01, 0, 0, 5);
            TextBoxT.Text = String.Format("{0:mm:ss}", Date);
            Date = Date.AddSeconds(1);
            if (Date.CompareTo(Over) == 1)
            {
                OverTime.Content = "It is overtime";
            }
        }
    }
}
