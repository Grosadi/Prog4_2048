// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System;
    using System.Diagnostics;
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
        /// repo.
        /// </summary>
        private GameRepository repo;

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
        /// Constructor for Load Game.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
        }

        /// <summary>
        /// OnRender method, responsible for drawing.
        /// </summary>
        /// <param name="drawingContext"D>Drawable objects.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                drawingContext.DrawDrawing(this.renderer.BuildDrawing());
            }
        }

        private void GameControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                    case Key.Left: this.logic.MoveLeft(); break;
                    case Key.Right: this.logic.MoveRight(); break;
                    case Key.Up: this.logic.MoveUp(); break;
                    case Key.Down: this.logic.MoveDown(); break;
                    case Key.Space: this.logic.WithDrawal(); break;
            }

            this.InvalidateVisual();

            if (this.model.GameOver)
            {
                MessageBox.Show("Game Over!");

                Window.GetWindow(this).Close();
            }

            if (this.model.Gamewin)
            {
                MessageBox.Show("You Win!\nBut you can continue playing!");
            }
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.repo = new GameRepository();
            this.model = this.repo.Model;
            this.logic = new GameLogic(this.model, this.repo);
            this.renderer = new GameRenderer(this.model);

            int n = 0;
            Window win = Window.GetWindow(this);
            if (win.GetType().GetProperty("Size").GetValue(win).ToString() == n.ToString())
            {
                try
                {
                    this.repo.LoadGame("log.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Nincs mentett játék!");
                    this.repo.NewGame(4, 0);
                }
            }
            else
            {
                int size = int.Parse(win.GetType().GetProperty("Size").GetValue(win).ToString());
                int time = int.Parse(win.GetType().GetProperty("Time").GetValue(win).ToString());
                this.repo.NewGame(size, time);
            }

            if (win != null)
            {
                win.KeyDown += this.GameControl_KeyDown;
                win.Closed += this.Win_Closed;
            }

            this.InvalidateVisual();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Mentés és név bekérés");
            this.repo.SaveGame("log.txt");
        }
    }
}
