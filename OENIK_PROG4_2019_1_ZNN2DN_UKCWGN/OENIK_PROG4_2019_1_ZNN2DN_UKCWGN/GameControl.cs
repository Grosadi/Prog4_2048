// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using _2048.Logic;
    using _2048.Repository;

    /// <summary>
    /// Controlls the game.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        /// <summary>
        /// logic.
        /// </summary>
        private GameLogic logic;

        /// <summary>
        /// model.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// renderer.
        /// </summary>
        private GameRenderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// 
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
            this.KeyDown += this.GameControl_KeyDown;
        }

        private void GameControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: this.logic.MoveLeft(); break;
                case Key.Right: this.logic.MoveRight(); break;
                case Key.Up: this.logic.MoveUp(); break;
                case Key.Down: this.logic.MoveDown(); break;
            }

            this.InvalidateVisual();
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel();
            this.renderer = new GameRenderer(this.model);

            this.InvalidateVisual();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawingContext"D></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.BuildDrawing());
            }
        }
    }
}
