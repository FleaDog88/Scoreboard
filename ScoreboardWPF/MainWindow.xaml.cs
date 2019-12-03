using ScoreboardAccessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ScoreboardWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {

        private ScoreBoardDisplay _score;

        public event PropertyChangedEventHandler PropertyChanged;
        Random random = new Random();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
            LoadInitialSampleData();
            this.DataContext = Score;

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 4);
            dispatcherTimer.Start();
        }

        public ScoreBoardDisplay Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                RaisePropertyChanged("Score");
            }
        }

        private void LoadSettings()
        {
            var verticalFillRectangle = new Rectangle();
            verticalFillRectangle.Width = this.RenderSize.Width;
            verticalFillRectangle.Height = this.RenderSize.Height;

            // Create a vertical linear gradient with four stops.   
            LinearGradientBrush myVerticalGradient =
                new LinearGradientBrush();
            myVerticalGradient.StartPoint = new Point(0.5, 0);
            myVerticalGradient.EndPoint = new Point(0.5, 1);
            var nebraskaOneGreen = new SolidColorBrush(Color.FromArgb(0xFF, 0x92, 0xcd, 0x1d));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(nebraskaOneGreen.Color, 0.0));
            myVerticalGradient.GradientStops.Add(
                new GradientStop(Colors.Black, 1.2));

            // Use the brush to paint the rectangle.
            this.RootGrid.Background = myVerticalGradient;
        }

        private void LoadInitialSampleData()
        {
            var accessor = new ScoreBoardAccessor(new ScoreBoardDisplay());
            Score = accessor.EditHomeTeam("Nebraska One Flames");
            Score = accessor.EditVisitorTeam("Omaha Spikes");
            Score = accessor.AddHomeScore();
            Score = accessor.AddVisitorScore();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var accessor = new ScoreBoardAccessor(Score);
            
            if (random.Next(0, 10) % 2 == 0)
            {
                Score = accessor.AddHomeScore();
            }
            else
            {
                Score = accessor.AddVisitorScore();
            }

            if (Score.HomeScore > 5 || Score.VisitorScore > 5)
            {
                dispatcherTimer.Stop();
                var adWindow = new AdWindow();
                adWindow.Closed += new EventHandler(adWindow_Closed);
                adWindow.Show();
            }
        }

        private void adWindow_Closed(object sender, EventArgs e)
        {
            dispatcherTimer.Start();
        }
    }
}
