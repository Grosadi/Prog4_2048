// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _2048.Repository.Seged;

    /// <summary>
    /// GameModel.
    /// </summary>
    public class GameModel : IGameModel
    {
        private IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Constructor to start new game.
        /// </summary>
        /// <param name="size">the num of tile per side.</param>
        /// <param name="matchTime">the duration of the match.</param>
        public GameModel(int size, int matchTime)
        {
            this.repo.NewGame(size, matchTime);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Constructor to load last game.
        /// </summary>
        /// <param name="file">name of readable file.</param>
        public GameModel(string file)
        {
            string[] lines = File.ReadAllLines(file);

            this.repo.LoadGame(lines);
        }

        /// <summary>
        /// Gets or sets the actual size of the board.
        /// </summary>
        public int Gamesize { get; set; }

        /// <summary>
        /// Gets or sets the size of the board. Board[Gamesize, Gamesize].
        /// </summary>
        public Tile[,] Board { get; set; }

        /// <summary>
        /// Gets or sets the actual score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the highest Tile value.
        /// </summary>
        public int Highest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if game is over.
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the player wins the game.
        /// </summary>
        public bool Gamewin { get; set; }

        /// <summary>
        /// Gets or sets the timer, to massure time.
        /// </summary>
        public double DeltaTime { get; set; }

        /// <summary>
        /// Gets or sets the duration of the match. Possibilities: 2min, 5 min, 10min, endless.
        /// </summary>
        public int Matchtime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether checkaviable attribution.
        /// </summary>
        public bool CheckAvailableMoves { get; set; }

        /// <summary>
        /// Gets or sets the number of Withdraws.
        /// </summary>
        public int WithdrawNum { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Constructor to start a new game.
        /// </summary>
        /// <param name="size">size of board.</param>
        /// <param name="matchTime">sets time of the game. If 0, then its an endless game.</param>
    }
}
