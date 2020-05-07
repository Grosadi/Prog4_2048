// <copyright file="TestClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic.Tests
{
    using _2048.Repository;
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

        }

    }
}
