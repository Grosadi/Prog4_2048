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
            this.values = new Tile[gamesize, gamesize];
            //for (int i = 0; i < gamesize; i++)
            //{
            //    for (int j = 0; j < gamesize; j++)
            //    {
            //        this.values[i,j]= new Tile
            //    }
            //}
        }
       public int Score { get; set; }
        public Tile [,] values { get; set; }
    }
}
