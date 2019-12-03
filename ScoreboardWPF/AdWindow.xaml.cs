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
using System.Windows.Shapes;

namespace ScoreboardWPF
{
    /// <summary>
    /// Interaction logic for AdWindow.xaml
    /// </summary>
    public partial class AdWindow : Window
    {
        public AdWindow()
        {
            InitializeComponent();
            AdContainer.MediaEnded += AdContainer_MediaEnded;
            LoadMovie();
        }

        public void LoadMovie()
        {
            AdContainer.Source = new Uri(@"c:\temp\movies\video.mov");
            AdContainer.LoadedBehavior = MediaState.Play;
        }

        public void AdContainer_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
