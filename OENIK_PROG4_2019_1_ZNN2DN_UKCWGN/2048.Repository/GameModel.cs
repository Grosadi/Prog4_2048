﻿using _2048.Repository.Seged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Repository
{
    /// <summary>
    /// GameModel.
    /// </summary>
    public class GameModel : IGameModel
    {
        IRepository repo;

        /// <summary>
        /// Gets or sets the actual size of the board.
        /// </summary>
        public int Gamesize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the size of the board. Board[Gamesize, Gamesize].
        /// </summary>
        public Tile[,] Board { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the actual score.
        /// </summary>
        public int Score { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the highest Tile value.
        /// </summary>
        public int Highest { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public bool GameOver { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public bool Gamewin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public double DeltaTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public int Matchtime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public bool CheckAvailableMoves { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// 
        /// </summary>
        public int WithdrawNum { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Constructor to start a new game.
        /// </summary>
        /// <param name="size">size of board.</param>
        /// <param name="matchTime">sets time of the game. If 0, then its an endless game.</param>
        public GameModel(int size, int matchTime)
        {
            this.repo.NewGame(size, matchTime);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Constructor to load last game.
        /// </summary>
        /// <param name="file">name of readable file.</param>
        public GameModel(string file)
        {
            string[] lines = File.ReadAllLines(file);

            this.repo.LoadGame(lines);
        }
    }
}