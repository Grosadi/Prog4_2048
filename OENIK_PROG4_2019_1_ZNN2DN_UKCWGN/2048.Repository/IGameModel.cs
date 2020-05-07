// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System.Collections.Generic;
    using _2048.Repository.Seged;

    /// <summary>
    /// Define the class Gamemodel.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the size of the Game.
        /// </summary>
        int Gamesize { get; set; }

        /// <summary>
        /// Gets or sets the board of the game.
        /// </summary>
        Tile[,] Board { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the variable with the highest tile's value.
        /// </summary>
        int Highest { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if game is over.
        /// </summary>
        bool GameOver { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the player wins the game.
        /// </summary>
        bool Gamewin { get; set; }

        /// <summary>
        /// Gets or sets the timer, to massure time.
        /// </summary>
        double DeltaTime { get; set; }

        /// <summary>
        /// Gets or sets the duration of the match. Possibilities: 2min, 5 min, 10min, endless.
        /// </summary>
        int Matchtime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether checkaviable attribution.
        /// </summary>
        bool CheckAvailableMoves { get; set; }

        /// <summary>
        /// Gets or sets the number of Withdraws.
        /// </summary>
        int WithdrawNum { get; set; }

        /// <summary>
        /// Gets or sets stack for store states of the game.
        /// </summary>
        Stack<Withrovdatas> Withrovdatas { get; set; }
    }
}
