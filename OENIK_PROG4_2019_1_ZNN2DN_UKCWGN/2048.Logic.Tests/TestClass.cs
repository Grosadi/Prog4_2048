// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic.Tests
{
    using _2048.Repository;
    using _2048.Repository.Seged;
    using NUnit.Framework;

    /// <summary>
    /// Tests Logic.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        private IRepository repository;
        private IGameLogic logic;
        private IGameModel gameModel;

        /// <summary>
        /// Sets game.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            int gamesize = 4;
            Tile[,] board = new Tile[gamesize, gamesize];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = new Tile(0);
                }
            }
            this.gameModel = new GameModel();
            this.repository = new GameRepository();
            this.logic = new GameLogic(this.gameModel, this.repository);
        }

        [Test]
        public void MoveupWhenItIsForbidden()
        {
            // logic.MoveDown()
          //  this.logic.GameModel = new GameModel();
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveLeft();
            Assert.IsFalse(this.logic.MoveUp());
            //Repository.Verify(X => X.ClearMerged(), Times.Never);
        }

        [Test]
        public void IsWithrowSetsTheScoreBack()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveUp();
            this.logic.WithDrawal();
            Assert.That(this.gameModel.Score.Equals(0));
        }

    }
}
