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
        /// starts new game.
        /// </summary>
        /// <param name="size">the size of the track( number of the tiles per side).</param>
        /// <param name="matchTime">game duration.</param>
       void NewGame(int size, int matchTime);

        /// <summary>
        /// To save the Game.
        /// </summary>
        /// <param name="file">the locaation of the saved game.</param>
       void SaveGame(string file);

        /// <summary>
        /// After each move it places a new tile randomly.
        /// </summary>
       void SpawnRandomTile();

        /// <summary>
        /// Set Merged attribution back to false for the whole board.
        /// </summary>
       void ClearMerged();

        /// <summary>
        /// During agame withhdrawal possible five times, it sets back the previosus state of the board.
        /// </summary>
       void Withdrawal();
    }
}
