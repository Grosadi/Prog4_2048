// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using _2048.Repository.Seged;

    /// <summary>
    /// Define the class Gamemodel.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the board of the game.
        /// </summary>
        Tile[,] Board { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets highest score of all time.
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
        double Timer { get; set; }

        /// <summary>
        /// Gets or sets the duration of the match.
        /// </summary>
        int Matchtime { get; set; }
    }
}
