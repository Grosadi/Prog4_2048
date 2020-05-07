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
        public Withrovdatas(int gamesize)
        {
            this.values = new int[gamesize, gamesize];
            for (int i = 0; i < gamesize; i++)
            {
                for (int j = 0; j < gamesize; j++)
                {
                    this.values[i, j] = 0;
                }
            }
        }

        public int Score { get; set; }

        public int [,] values { get; set; }
        public int Highest { get; set; }
    }
}
