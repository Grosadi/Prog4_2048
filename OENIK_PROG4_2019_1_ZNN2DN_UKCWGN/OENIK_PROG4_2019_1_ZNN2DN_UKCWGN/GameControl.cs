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

        private int gameWinCounter;

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
                        bool succes = this.logic.WithDrawal();
                        if (succes)
                           {
                              break;
                           }
                        else if (this.model.WithdrawNum < 1)
                            {
                                MessageBoxInfos infoS = new MessageBoxInfos(
                                                         "Out of Withdraws!",
                                                         "OK",
                                                         Brushes.Red);
                                CustomMessageBox msgbox = new CustomMessageBox(infoS);
                                msgbox.ShowDialog();

                                break;
                            }
                        else
                        {
                            MessageBoxInfos infos = new MessageBoxInfos(
                                                            "Nothing to withdraw!",
                                                            "OK",
                                                            Brushes.YellowGreen);
                            CustomMessageBox msgBox = new CustomMessageBox(infos);
                            msgBox.ShowDialog();

                            break;
                        }
                    }
            }

            this.InvalidateVisual();

            if (this.model.GameOver && this.model.WithdrawNum == 0)
            {
                MessageBoxInfos infos = new MessageBoxInfos(
                    "Game Over!",
                    "OK",
                    Brushes.Red);
                CustomMessageBox msgBox = new CustomMessageBox(infos);
                msgBox.ShowDialog();

                Window.GetWindow(this).Close();
            }
            else if (this.model.GameOver)
            {
                MessageBoxInfos infos = new MessageBoxInfos(
                    "Game Over, but\nYou left " + this.model.WithdrawNum.ToString() + " withdraws!",
                    "Cool",
                    Brushes.YellowGreen);
                CustomMessageBox msgBox = new CustomMessageBox(infos);
                msgBox.ShowDialog();

                this.model.GameOver = false;
            }

            if (this.model.Gamewin && this.gameWinCounter < 1)
            {
                this.gameWinCounter++;

                MessageBoxInfos infos = new MessageBoxInfos(
                    "You Win!\nBut you can continue playing!",
                    "Cool",
                    Brushes.Green);
                CustomMessageBox msgBox = new CustomMessageBox(infos);
                msgBox.ShowDialog();

                this.model.Gamewin = false;
            }
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.repo = new GameRepository();
            this.model = this.repo.Model;
            this.logic = new GameLogic(this.model, this.repo);
            this.renderer = new GameRenderer(this.model);
            this.gameWinCounter = 0;

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
                    MessageBoxInfos infos = new MessageBoxInfos("No saved game!", "OK", Brushes.Red);
                    CustomMessageBox msgBox = new CustomMessageBox(infos);
                    msgBox.ShowDialog();

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

                MessageBoxInfos infos = new MessageBoxInfos(
                    "Time is up!\nYour score is: " + this.model.Score.ToString(),
                    "OK",
                    Brushes.YellowGreen);
                CustomMessageBox msgBox = new CustomMessageBox(infos);
                msgBox.ShowDialog();

                Window.GetWindow(this).Close();
            }
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            if (this.model.Matchtime == 0)
            {
                NewPlayerToHSWindow newPlayer = new NewPlayerToHSWindow(this.model.Score, this.model.Highest);
                newPlayer.ShowDialog();
                this.repo.SaveGame("log.txt");
            }
        }
    }
}
