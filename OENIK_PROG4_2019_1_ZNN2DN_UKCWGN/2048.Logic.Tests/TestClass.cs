// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic.Tests
{
    using _2048.Repository;
    using _2048.Repository.Seged;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests Logic.
    /// </summary>
    [TestFixture]
    public class TestClass
    {
        private Mock<IRepository> mockedRepository;
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

            this.mockedRepository = new Mock<IRepository>();
          //  this.mockedRepository.SetReturnsDefault(board);
            this.gameModel = new GameModel();
            this.logic = new GameLogic(this.gameModel, this.mockedRepository.Object);
           // this.mockedRepository.Setup(X => X.NewGame(4, 4)).Callback(X => );
           // this.mockedRepository.SetupProperty<GameModel>(x=>x.NewGame())
        }

        [Test]
        public void CanmergewhennotEqual()
        {
            // logic.MoveDown()
            this.logic.GameModel = new GameModel();
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveLeft();

           // Assert.That(this.gameModel.Board[0, 0].Value == 4);
           // Assert.That(logic.MoveDown(), It.Is <);
            Assert.IsFalse(this.logic.MoveUp());
            mockedRepository.Verify(X => X.ClearMerged(), Times.Never);
        }

    }
}
