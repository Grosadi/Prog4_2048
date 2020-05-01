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

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow((int)this.size.Value, (int)this.time.Value);
            gw.Show();
            this.Close();
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Close();
        }

        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow hw = new HighScoreWindow();
            hw.Show();
        }
    }
}
