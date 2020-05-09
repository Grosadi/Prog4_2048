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
    using System.Windows.Threading;
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

        private Stopwatch sw;

        private DispatcherTimer tickTimer;

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
                case Key.Space:
                    {
                        try
                        {
                            bool succes = this.logic.WithDrawal();
                            if (succes)
                            {
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Out of Withdraws!");
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Nothing to withdraw!");
                            break;
                        }
                    }
            }

            this.InvalidateVisual();

            if (this.model.GameOver && this.model.WithdrawNum == 0)
            {
                MessageBox.Show("Game Over!");

                Window.GetWindow(this).Close();
            }
            else if (this.model.GameOver)
            {
                MessageBox.Show("Game Over, but\nYou left " + this.model.WithdrawNum.ToString() + " withdraws!");
                this.model.GameOver = false;
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
                    MessageBox.Show("No saved game!");
                    this.repo.NewGame(4, 0);
                }
            }
            else
            {
                int size = int.Parse(win.GetType().GetProperty("Size").GetValue(win).ToString());
                int time = int.Parse(win.GetType().GetProperty("Time").GetValue(win).ToString());
                this.repo.NewGame(size, time);
                if (time > 0)
                {
                    this.sw = new Stopwatch();
                    this.sw.Start();

                    this.tickTimer = new DispatcherTimer();
                    this.tickTimer.Interval = TimeSpan.FromSeconds(1);
                    this.tickTimer.Tick += this.TickTimer_Tick;
                    this.tickTimer.Start();
                }
            }

            if (win != null)
            {
                win.KeyDown += this.GameControl_KeyDown;
                win.Closed += this.Win_Closed;
            }

            this.InvalidateVisual();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            if (this.model.DeltaTime > 0)
            {
                this.model.DeltaTime = this.model.Matchtime - this.sw.Elapsed.TotalSeconds;
                this.InvalidateVisual();
            }
            else
            {
                this.tickTimer.Stop();
                MessageBox.Show("Time is up!\nYour score is: " + this.model.Score.ToString());
                Window.GetWindow(this).Close();
            }
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            if (this.model.Matchtime == 0)
            {
                MessageBox.Show("Mentés és név bekérés");
                this.repo.SaveGame("log.txt");
            }
        }
    }
}
