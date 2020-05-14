// <copyright file="CustomMessageBox.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml.
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        /// <param name="infos">Infos to show.</param>
        public CustomMessageBox(MessageBoxInfos infos)
            : this()
        {
            this.DataContext = null;
            this.DataContext = infos;

            this.Loaded += CustomMessageBox_Loaded;

            this.InitializeComponent();
        }

        private void CustomMessageBox_Loaded(object sender, RoutedEventArgs e)
        {
            KeyDown += CustomMessageBox_KeyDown;
        }

        private void CustomMessageBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Enter: Window.GetWindow(this).Close(); break;
                case System.Windows.Input.Key.Space: Window.GetWindow(this).Close(); break;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMessageBox"/> class.
        /// </summary>
        public CustomMessageBox()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the Datacontext.
        /// </summary>
        public MessageBoxInfos Infos
        {
            get { return this.DataContext as MessageBoxInfos; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
