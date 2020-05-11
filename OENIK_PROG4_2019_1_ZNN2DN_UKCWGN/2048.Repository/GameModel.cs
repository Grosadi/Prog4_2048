// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System.Collections.Generic;
    using _2048.Repository.Seged;

    /// <summary>
    /// GameModel.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        public GameModel()
        {
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
        /// Gets or sets stack for store states of the game.
        /// </summary>
        public Stack<Withrovdatas> Withrovdatas { get; set; }

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
    }
}
