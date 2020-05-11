// <copyright file="GameWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for GameWindow.xaml.
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// Constructor for Load Game.
        /// </summary>
        public GameWindow()
        {
            this.Size = 0;
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// Constructor to start a new game.
        /// </summary>
        /// <param name="size">Size of the table.</param>
        /// <param name="time">Time, if 0, the game is endless.</param>
        public GameWindow(int size, int time)
            : this()
        {
            this.Size = size;
            this.Time = time;
        }

        /// <summary>
        /// Gets or sets the size of the table.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        public int Time { get; set; }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
