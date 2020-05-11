// <copyright file="GameRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using _2048.Data;
    using _2048.Repository.Seged;

    /// <summary>
    /// GameRepository.
    /// </summary>
    public class GameRepository : IRepository
    {
        private Random rnd = new Random();

        private DataBaseContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRepository"/> class.
        /// </summary>
        public GameRepository()
        {
            this.Model = new GameModel();
            this.dbContext = new DataBaseContext();
        }

        /// <summary>
        /// Gets or sets the GameModel instance.
        /// </summary>
        public GameModel Model { get; set; }

        /// <summary>
        /// Load the last game from file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void LoadGame(string fileName)
        {
            // this.Model = new GameModel();
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
                    if (int.Parse(line[j]) != 0)
                    {
                        // fordítva a kirajzolás miatt
                        this.Model.Board[j, i] = new Tile(int.Parse(line[j]));
                    }
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
            // this.Model = new GameModel();
            this.Model.Gamesize = size;
            this.Model.Board = new Tile[size, size];
            this.Model.Score = 0;
            this.Model.GameOver = false;
            this.Model.Gamewin = false;
            this.Model.WithdrawNum = 5;
            this.Model.Matchtime = matchTime;
            this.Model.DeltaTime = matchTime;
            /*for (int i = 0; i < this.Model.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.Model.Board.GetLength(1); j++)
                {
                    this.Model.Board[i, j] = new Tile(0);
                    this.Model.Board[i, j].Merged = false;
                }
            }*/

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
            for (int i = 0; i < this.Model.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.Model.Board.GetLength(1); j++)
                {
                    // fordítva a kirajzolás miatt
                    if (this.Model.Board[j, i] != null)
                    {
                        // fordítva a kirajzolás miatt
                        sw.Write(this.Model.Board[j, i].Value + ",");
                    }
                    else
                    {
                        sw.Write("0,");
                    }
                }

                sw.WriteLine();
            }

            sw.Close();
        }

        /// <summary>
        /// Get all player from db, ordered by score.
        /// </summary>
        /// <returns>Returns a list with players.</returns>
        public List<PLAYER> GetPlayerByScore()
        {
            return this.dbContext.GetAll();
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

        /// <summary>
        /// Set Merged attribution back to false for the whole board.
        /// </summary>
        public void ClearMerged()
        {
            for (int i = 0; i < this.Model.Gamesize; i++)
            {
                for (int j = 0; j < this.Model.Gamesize; j++)
                {
                    if (this.Model.Board[i, j] != null)
                    {
                        this.Model.Board[i, j].Merged = false;
                    }
                }
            }
        }
    }
}
