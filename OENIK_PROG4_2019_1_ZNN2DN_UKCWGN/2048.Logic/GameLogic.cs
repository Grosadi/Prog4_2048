// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic
{
    using _2048.Repository;

    /// <summary>
    /// Handles Business Logic.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Gamemodel currently used by gamlogic.
        /// </summary>
        /// <param name="gameModel">gamemodel.</param>
        /// <param name="repository">repository.</param>
        public GameLogic(IGameModel gameModel, IRepository repository)
        {
            this.GameModel = gameModel;
            this.Repository = repository;
        }

        /// <summary>
        /// Gets or sets actual gamemodel.
        /// </summary>
        public IGameModel GameModel { get; set; }

        /// <summary>
        /// Gets or sets actual repository.
        /// </summary>
        public IRepository Repository { get; set; }

        /// <summary>
        ///  The main method of the game, responsible for moving the tiles and spawning them in the right way.
        /// </summary>
        public void Move()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Down.
        /// </summary>
        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Left.
        /// </summary>
        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Right.
        /// </summary>
        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Up.
        /// </summary>
        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void NewGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
