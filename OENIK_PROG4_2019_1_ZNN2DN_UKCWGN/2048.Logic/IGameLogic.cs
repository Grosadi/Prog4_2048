// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic
{
    using _2048.Repository;

    /// <summary>
    /// Define the class GameLogic.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Gets or sets gamemodel.
        /// </summary>
        IGameModel GameModel { get; set; }

        /// <summary>
        /// Gets or sets repository.
        /// </summary>
        IRepository Repository { get; set; }

        /// <summary>
        /// Move Left.
        /// </summary>
        /// <returns>with a left move.</returns>
        bool MoveLeft();

        /// <summary>
        /// Move Right.
        /// </summary>
        /// <returns>with a right move.</returns>
        bool MoveRight();

        /// <summary>
        /// Move UP.
        /// </summary>
        /// <returns>with a move to upwards.</returns>
        bool MoveUp();

        /// <summary>
        /// Move Down.
        /// </summary>
        /// <returns>with a move to downwords.</returns>
        bool MoveDown();

        /// <summary>
        /// The main method, it controls and moves the game.
        /// </summary>
        /// <param name="countdownFrom">inside pararam.</param>
        /// <param name="yIncr">Y incrase.</param>
        /// <param name="xIncr">X incrase.</param>
        /// <param name="side">the number of tiles per side in the game.</param>
        /// <returns>with the right reaction after a move.</returns>
        bool Move(int countdownFrom, int yIncr, int xIncr, int side);

        /// <summary>
        /// Call the Withhdraw method from repository.
        /// </summary>
        void WithDrawal();
    }
}
