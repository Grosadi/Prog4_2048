// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Closing += this.MainWindow_Closing;
            this.InitializeComponent();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HighScoreVM vm = new HighScoreVM();
            vm.SaveChanges();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow((int)this.size.Value, (int)this.time.Value);
            gw.Show();
            this.Hide();
            gw.Closed += this.Gw_Closed;
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Hide();
            gw.Closed += this.Gw_Closed;
        }

        private void Gw_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow hw = new HighScoreWindow();
            hw.Show();
        }
    }
}
