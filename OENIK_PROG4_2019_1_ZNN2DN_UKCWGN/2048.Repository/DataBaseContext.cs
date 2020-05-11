// <copyright file="DataBaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _2048.Data;

    /// <summary>
    /// Database operator class.
    /// </summary>
    public class DataBaseContext
    {
        private HighScoreDBEntities highScoreDB;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseContext"/> class.
        /// </summary>
        public DataBaseContext()
        {
            this.highScoreDB = new HighScoreDBEntities();
        }

        /// <summary>
        /// Get the all player from DB.
        /// </summary>
        /// <returns>Returns with a list of players, rank by score.</returns>
        public List<PLAYER> GetAll()
        {
            List<PLAYER> list = this.highScoreDB.PLAYER.ToList();

            var players = from x in list
                          orderby x.PLAYER_SCORE descending
                          select x;

            return players.ToList();
        }

        /// <summary>
        /// Add a new Player to the DB.
        /// </summary>
        /// <param name="name">Player name.</param>
        /// <param name="score">Reached score.</param>
        /// <param name="highest">Reached highest tile.</param>
        public void AddPlayer(string name, int score, int highest)
        {
            this.highScoreDB.PLAYER.Add(new PLAYER()
            {
                PLAYER_NAME = name,
                PLAYER_SCORE = score,
                PLAYER_HIGHEST_TILE = highest,
                PLAYER_DATETIME = DateTime.Now,
            });

            this.highScoreDB.SaveChanges();
        }

        /// <summary>
        /// Removes selected Player from DB.
        /// </summary>
        /// <param name="name">Name of the Player.</param>
        public void DelPlayer(string name)
        {
            PLAYER player = this.highScoreDB.PLAYER.Single(x => x.PLAYER_NAME == name);
            this.highScoreDB.PLAYER.Remove(player);
            this.highScoreDB.SaveChanges();
        }

        /// <summary>
        /// Removes all entities from DB.
        /// </summary>
        public void ResetDataBase()
        {
            foreach (var item in this.highScoreDB.PLAYER)
            {
                this.highScoreDB.PLAYER.Remove(item);
            }

            this.highScoreDB.SaveChanges();
        }
    }
}
