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
using System.Windows.Media.Animation;
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
        private bool isMenuOpen = false;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Timer

            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);

            
            /*
             * Animation Menu (Ein-/Ausblenden)
             */
            TimeSpan duration = TimeSpan.FromMilliseconds(1000);

            DoubleAnimation expandAnimation = new DoubleAnimation()
            {
                To = 200,
                Duration = duration,
            };
            Storyboard.SetTargetName(expandAnimation, panelMenu.Name);
            Storyboard.SetTargetProperty(expandAnimation, new PropertyPath(StackPanel.WidthProperty));

            DoubleAnimation shrinkAnimation = new DoubleAnimation()
            {
                To = 0,
                Duration = duration,
            };
            Storyboard.SetTargetName(shrinkAnimation, panelMenu.Name);
            Storyboard.SetTargetProperty(shrinkAnimation, new PropertyPath(StackPanel.WidthProperty));

            Storyboard expandStoryboard = new Storyboard();
            Storyboard shrinkStoryboard = new Storyboard();
            expandStoryboard.Children.Add(expandAnimation);
            shrinkStoryboard.Children.Add(shrinkAnimation);

            btnMenu.Click += delegate (object sender, RoutedEventArgs args)
            {
                if (!isMenuOpen)
                {
                    expandStoryboard.Begin(panelMenu);
                    isMenuOpen = true;
                }
                else
                {
                    shrinkStoryboard.Begin(panelMenu);
                    isMenuOpen = false;
                }
            };
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            dt.Start();
            sw.Start();

            /*
             * Animation Button (beim Klicken)
             */
            Button btn = sender as Button;
            double time = 0.3;
            DoubleAnimation doubleAnimation = new DoubleAnimation(100, 80, TimeSpan.FromSeconds(time));
            DoubleAnimation doubleAnimationReverse = new DoubleAnimation(80, 100, TimeSpan.FromSeconds(time));
            doubleAnimation.Completed += (s, c) =>
            {

                btn.BeginAnimation(HeightProperty, doubleAnimationReverse);
                btn.BeginAnimation(WidthProperty, doubleAnimationReverse);
            };
            btn.BeginAnimation(HeightProperty, doubleAnimation);
            btn.BeginAnimation(WidthProperty, doubleAnimation);

            /*
             * Animation Button (beim Klicken)
             */
            Storyboard stimerVergroeßern = new Storyboard();
            DoubleAnimation dAtimerVergroeßern = new DoubleAnimation(55, new Duration(TimeSpan.FromSeconds(1)));
            stimerVergroeßern.Children.Add(dAtimerVergroeßern);
            Storyboard.SetTargetProperty(dAtimerVergroeßern, new PropertyPath(TextBlock.FontSizeProperty));
            stimerVergroeßern.Begin(tblZeit);

            Storyboard sTimerBackground = new Storyboard();
            DoubleAnimation dABackgroundVerkleinern = new DoubleAnimation(325, new Duration(TimeSpan.FromSeconds(1)));
            sTimerBackground.Children.Add(dABackgroundVerkleinern);
            Storyboard.SetTargetProperty(dABackgroundVerkleinern, new PropertyPath(StackPanel.HeightProperty));
            sTimerBackground.Begin(timerBackground);

            Storyboard sbuttonBackground = new Storyboard();
            DoubleAnimation dABackgroundVergroeßern = new DoubleAnimation(125, new Duration(TimeSpan.FromSeconds(1)));
            sbuttonBackground.Children.Add(dABackgroundVergroeßern);
            Storyboard.SetTargetProperty(dABackgroundVergroeßern, new PropertyPath(StackPanel.HeightProperty));
            sbuttonBackground.Begin(buttonBackground);
        }
    

        private void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                ElapsedTime = string.Format("{0:00}.{1:0} s", ts.Seconds, ts.Milliseconds);
                tblZeit.Text = ElapsedTime;
            }
        }
    }
}
