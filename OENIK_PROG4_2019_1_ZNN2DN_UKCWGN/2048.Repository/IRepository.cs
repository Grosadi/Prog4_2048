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
    }
}
