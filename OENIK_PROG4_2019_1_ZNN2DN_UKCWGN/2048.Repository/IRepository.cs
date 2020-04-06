// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Repository
{
    /// <summary>
    /// Define the class Repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Load the game from a file, saved game if possible, otherwise new game if that is the players desire.
        /// </summary>
        /// <param name="file">The file of the saved game, or new one.</param>
       void LoadGame(string[] file);

      /// <summary>
      /// Starts New Game.
      /// </summary>
      /// <param name="size">the size of the track.</param>
       void NewGame(int size);

        /// <summary>
        /// To save the Game.
        /// </summary>
        /// <param name="file">the locaation of the saved game.</param>
       void SaveGame(string file);

        /// <summary>
        /// MovesAviable.
        /// </summary>
        /// <returns>If therer is any  more moves available.</returns>
       bool MovesAvailable();

        /// <summary>
        /// After each move it places a new tile randomly.
        /// </summary>
       void SpawnRandomTile();

        /// <summary>
        /// Set Merged attribution back to false for the whole board.
        /// </summary>
       void ClearMerged();
    }
}
