using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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

            // Exit Button
            btnExit.Click += delegate (object sender, RoutedEventArgs args)
            {
                Application.Current.Shutdown();
            };

            /*
             * Animation Menu (Ein-/Ausblenden)
             */
            TimeSpan duration = TimeSpan.FromMilliseconds(1000);

            DoubleAnimation expandAnimation = new DoubleAnimation()
            {
                To = 200,
                Duration = duration,
            };
            expandAnimation.Completed += delegate (object sender, EventArgs args)
            {
                panelMenuButtons.Visibility = Visibility.Visible;
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

            /*
             * Animation Pfeile
             */
            TimeSpan rotateDuration = TimeSpan.FromMilliseconds(1000);
            DoubleAnimation rotateAnimation = new DoubleAnimation(0, 180, rotateDuration);
            DoubleAnimation rotateAnimationReverse = new DoubleAnimation(180, 0, rotateDuration);
            RotateTransform rotateTransform = new RotateTransform();

            btnMenu.RenderTransform = rotateTransform;
            btnMenu.RenderTransformOrigin = new Point(0.5, 0.5);

            /*
             * On Click
             */
            btnMenu.Click += delegate (object sender, RoutedEventArgs args)
            {
                if (!isMenuOpen)
                {
                    expandStoryboard.Begin(panelMenu);
                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
                    isMenuOpen = true;
                }
                else
                {
                    panelMenuButtons.Visibility = Visibility.Hidden;
                    shrinkStoryboard.Begin(panelMenu);
                    rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimationReverse);
                    isMenuOpen = false;
                }
            };
        }

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if ((string)btn.Content == "Starten")
            {
                dt.Start();
                sw.Start();
                btn.Content = "Stoppen";
            }
            else
            {
                sw.Stop();
                btn.Content = "Starten";
            }

            /*
             * Animation Button (beim Klicken)
             */
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
                ElapsedTime = string.Format("{0:0}.{1:00}", ts.Seconds, ts.Milliseconds);
                tblZeit.Text = ElapsedTime;
            }
        }
    }
}
