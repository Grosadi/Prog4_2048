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
        /// starts new game, an empty type.
        /// </summary>
        void NewGame();

        /// <summary>
        /// Move Left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Move Right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Move UP.
        /// </summary>
        void MoveUp();

        /// <summary>
        /// Move Down.
        /// </summary>
        void MoveDown();

        /// <summary>
        ///  The main method of the game, responsible for moving the tiles and spawning them in the right way.
        /// </summary>
        void Move();
    }
}
