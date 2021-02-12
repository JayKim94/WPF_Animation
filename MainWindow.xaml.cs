using System;
using System.Collections.Generic;
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

namespace WPF_Animationen_Steinert_Simon_Kim
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer dt = new DispatcherTimer();
        private Stopwatch sw = new Stopwatch();
        private string ElapsedTime;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            dt.Start();
            sw.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                ElapsedTime = string.Format("{0:00}.{1:00} s", ts.Seconds, ts.Milliseconds);
                tblZeit.Text = ElapsedTime;
            }
        }
    }
}
