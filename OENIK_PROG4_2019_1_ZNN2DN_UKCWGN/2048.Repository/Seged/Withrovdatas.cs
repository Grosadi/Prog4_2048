// <copyright file="Withrovdatas.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository.Seged
{
    /// <summary>
    /// Stores data needed for vithrow.
    /// </summary>
    public class Withrovdatas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Withrovdatas"/> class.
        /// sets the previous state of the game.
        /// </summary>
        /// <param name="gamesize">the size of the game.</param>
        public Withrovdatas(int gamesize)
        {
            this.Values = new int[gamesize, gamesize];
            for (int i = 0; i < gamesize; i++)
            {
                for (int j = 0; j < gamesize; j++)
                {
                    this.Values[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data of score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets values.
        /// </summary>
        public int[,] Values { get; set; }

        /// <summary>
        /// Gets or sets a the highest tile.
        /// </summary>
        public int Highest { get; set; }
    }
}
