// <copyright file="Tile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository.Seged
{
    /// <summary>
    /// It needed for the tiles, with two attribution,
    /// one dóstore its values, the other stores if its had beeen combined.
    /// </summary>
    public class Tile
    {
        private int value;
        private bool merged;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class.
        ///
        /// </summary>
        /// <param name="value">value of the tiles.</param>
        public Tile(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets value of the tile.
        /// </summary>
        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether gets or sets Merged value of the tiles.
        /// </summary>
        public bool Merged
        {
            get
            {
                return this.merged;
            }

            set
            {
                this.merged = value;
            }
        }

/// <summary>
/// Decicdes if a tile can merge with the other one.
/// </summary>
/// <param name="other">other tile.</param>
/// <returns>if merge is possible.</returns>
        public bool CanMergeWith(Tile other)
        {
            return !this.merged && other != null && !other.Merged && this.value == other.Value;
        }

/// <summary>
/// Merge two tiles.
/// </summary>
/// <param name="other">the other tile.</param>
/// <returns>merged tiles.</returns>
        public int MergeWith(Tile other)
        {
            if (this.CanMergeWith(other))
            {
                this.value *= 2;
                this.merged = true;
                return this.value;
            }

            return -1;
        }
    }
}
