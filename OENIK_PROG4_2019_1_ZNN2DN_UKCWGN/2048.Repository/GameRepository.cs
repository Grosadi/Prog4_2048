﻿// <copyright file="GameRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _2048.Repository.Seged;

    /// <summary>
    /// GameRepository.
    /// </summary>
    public class GameRepository : IRepository
    {
        private readonly Random rnd = new Random();

        private GameModel Model { get; set; }

        /// <summary>
        /// Set Merged attribution back to false for the whole board.
        /// </summary>
        public void ClearMerged()
        {
            for (int i = 0; i < this.Model.Gamesize; i++)
            {
                for (int j = 0; j < this.Model.Gamesize; j++)
                {
                    this.Model.Board[i, j].Merged = false;
                }
            }
        }

        /// <summary>
        /// Load the last game from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void LoadGame(string fileName)
        {
            string[] file = File.ReadAllLines(fileName);

            this.Model.Score = int.Parse(file[0]);
            this.Model.Highest = int.Parse(file[1]);
            this.Model.DeltaTime = double.Parse(file[2]);
            this.Model.WithdrawNum = int.Parse(file[3]);
            this.Model.Gamesize = int.Parse(file[4]);
            this.Model.Board = new Tile[this.Model.Gamesize, this.Model.Gamesize];

            for (int i = 0; i < this.Model.Board.GetLength(0); i++)
            {
                string[] line = file[5 + i].Split(',');
                for (int j = 0; j < this.Model.Board.GetLength(1); j++)
                {
                    this.Model.Board[i, j] = new Tile(int.Parse(line[j]));
                }
            }
        }

        /// <summary>
        /// Starst new Game.
        /// </summary>
        /// <param name="size"> size of the board.</param>
        /// <param name="matchTime"> sets time of the game. If 0, then its an endless game.</param>
        public void NewGame(int size, int matchTime)
        {
            this.Model.Gamesize = size;
            this.Model.Board = new Tile[size, size];
            this.Model.Score = 0;
            this.Model.GameOver = false;
            this.Model.Gamewin = false;
            this.Model.Matchtime = matchTime;

            this.SpawnRandomTile();
            this.SpawnRandomTile();
        }

        /// <summary>
        /// Save the actual status of the game.
        /// </summary>
        /// <param name="file">Name of file.</param>
        public void SaveGame(string file)
        {
            StreamWriter sw = new StreamWriter(file, false);
            sw.WriteLine(this.Model.Score);
            sw.WriteLine(this.Model.Highest);
            sw.WriteLine(this.Model.DeltaTime);
            sw.WriteLine(this.Model.WithdrawNum);
            sw.WriteLine(this.Model.Gamesize);
            for (int i = 0; i < this.Model.Gamesize; i++)
            {
                for (int j = 0; j < this.Model.Gamesize; j++)
                {
                    sw.Write(this.Model.Board[i, j].Value + ',');
                }

                sw.WriteLine();
            }

            sw.Close();
        }

        /// <summary>
        /// After each move it places a new tile randomly.
        /// </summary>
        public void SpawnRandomTile()
        {
            bool success = false;
            while (!success)
            {
                int x = this.rnd.Next(this.Model.Board.GetLength(0));
                int y = this.rnd.Next(this.Model.Board.GetLength(1));
                if (this.Model.Board[x, y] == null)
                {
                    this.Model.Board[x, y] = new Tile(2 * this.rnd.Next(1, 3));
                    success = true;
                }
            }
        }
    }
}
