using StopWatchesCore.Models;
using StopWatchesCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace StopWatchesCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StopWatchService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new StopWatchService();
        }

        //  DispatcherTimer setup
        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var ts = stopWatch.Elapsed;
            txtSW1.Text = ts.Hours.ToString().PadLeft(2,'0') + ":" + ts.Minutes.ToString().PadLeft(2, '0') + ":" + ts.Seconds.ToString().PadLeft(2, '0');

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
        private void btnSW1_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
                btnSW1.Content = "START";
            }
            else
            {
                stopWatch.Start();
                btnSW1.Content = "STOP";
            }                
            

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
           
        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            if(stopWatch.IsRunning)
            {
                var sw = new SotpWatch();
                var ts = stopWatch.Elapsed;
                sw.Hours = ts.Hours;
                sw.Minutes = ts.Minutes;
                _service.CreateStopWatch(sw)
            }
         
        }
    }
}
