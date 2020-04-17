// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows;
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
        GameLogic logic;

        /// <summary>
        /// model.
        /// </summary>
        GameModel model;

        /// <summary>
        /// renderer.
        /// </summary>
        GameRenderer renderer;

        public GameControl()
        {
            Loaded += GameControl_Loaded;
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel();
            this.renderer = new GameRenderer(this.model);

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null)
            {
                drawingContext.DrawDrawing(renderer.BuildDrawing());
            }
        }
    }
}
