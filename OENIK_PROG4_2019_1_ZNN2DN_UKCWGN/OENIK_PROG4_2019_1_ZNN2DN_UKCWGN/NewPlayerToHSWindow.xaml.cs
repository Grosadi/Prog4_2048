// <copyright file="NewPlayerToHSWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for NewPlayerToHSWindow.xaml.
    /// </summary>
    public partial class NewPlayerToHSWindow : Window
    {
        private HighScoreVM vm;
        private int score;
        private int highest;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewPlayerToHSWindow"/> class.
        /// </summary>
        public NewPlayerToHSWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewPlayerToHSWindow"/> class.
        /// </summary>
        /// <param name="score">Score of the player.</param>
        /// <param name="highest">Highest tile of the player.</param>
        public NewPlayerToHSWindow(int score, int highest)
            : base()
        {
            this.vm = new HighScoreVM();
            this.score = score;
            this.highest = highest;

            this.KeyDown += this.NewPlayerToHSWindow_KeyDown;

            this.InitializeComponent();
        }

        private void NewPlayerToHSWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    this.vm.AddPlayer(this.Player_Name.Text, this.score, this.highest);

                    MessageBox.Show("Saved succesfully!");

                    this.Close();
                    break;
                case Key.Space:
                    this.vm.AddPlayer(this.Player_Name.Text, this.score, this.highest);

                    MessageBox.Show("Saved succesfully!");

                    this.Close();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.vm.AddPlayer(this.Player_Name.Text, this.score, this.highest);

            MessageBox.Show("Saved succesfully!");

            this.Close();
        }
    }
}
