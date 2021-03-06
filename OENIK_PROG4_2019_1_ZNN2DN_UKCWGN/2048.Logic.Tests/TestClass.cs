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
        /// Sets game for the test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.gameModel = new GameModel();
            this.repository = new GameRepository();
            this.logic = new GameLogic(this.gameModel, this.repository);
            this.repository.NewGame(4, 0);
        }

        /// <summary>
        /// Tests if two tile can be merged if they dont have the same value.
        /// </summary>
        [Test]
        public void MoveupWhenItIsForbidden()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Gamesize = 4;
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(4);
            Assert.IsFalse(this.logic.MoveUp());
            Assert.That(this.logic.GameModel.Board[0, 0].Value == 2);
        }

        /// <summary>
        /// Test If two Tile have the same value and they sholud merge, their value adds, and so score sets.
        /// </summary>
        [Test]
        public void MoveIfItsPossibleAndMoveSetsScore()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Gamesize = 4;
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveUp();
            Assert.That(this.logic.GameModel.Board[0, 0].Value == 4);
            Assert.That(this.logic.GameModel.Score != 0);
            Assert.That(this.logic.GameModel.Score.Equals(4));
        }

        /// <summary>
        /// Tests if you only can withrow if you have havent used all your possibilities yet.
        /// </summary>
        [Test]
        public void IswithrowWorksOnlyWhenYouHaveMoreLeft()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Gamesize = 4;
            this.logic.GameModel.WithdrawNum = 1;
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveUp();
            this.logic.MoveLeft();
            this.logic.MoveRight();
            Assert.IsTrue(this.logic.WithDrawal());
            this.logic.WithDrawal();
            Assert.IsFalse(this.logic.WithDrawal());
        }

        /// <summary>
        /// Tests if after a move the tiles mergeg status sets back to the default.
        /// </summary>
        [Test]
        public void IsMergeStatusOftheTilesSetBackAfteraMove()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Gamesize = 4;
            this.logic.GameModel.Board[0, 0] = new Tile(2);
            this.logic.GameModel.Board[0, 1] = new Tile(2);
            this.logic.MoveUp();
            this.logic.MoveDown();
            this.logic.MoveLeft();
            this.logic.MoveUp();
            bool temp = true;
            for (int i = 0; i < this.logic.GameModel.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.logic.GameModel.Board.GetLength(1); j++)
                {
                    if (this.logic.GameModel.Board[i, j] != null)
                    {
                        temp = this.logic.GameModel.Board[i, j].Merged;
                        Assert.IsTrue(temp);
                    }
                }
            }
        }

        /// <summary>
        /// Test if Highest value of the gamemodel sets to the hihest value we got from during move.
        /// </summary>
        [Test]
        public void IsHihghestreturnwiththehighestvalueWeGetFromAMerge()
        {
            this.logic.GameModel.Board = new Tile[4, 4];
            this.logic.GameModel.Gamesize = 4;
            this.logic.GameModel.Board[0, 0] = new Tile(8);
            this.logic.GameModel.Board[0, 1] = new Tile(8);
            this.logic.GameModel.Board[0, 2] = new Tile(9);
            this.logic.GameModel.Board[0, 3] = new Tile(12);
            this.logic.GameModel.Board[1, 1] = new Tile(12);
            this.logic.GameModel.Board[1, 2] = new Tile(12);
            this.logic.MoveUp();

            Assert.That(this.logic.GameModel.Highest == 24);
        }
    }
}
