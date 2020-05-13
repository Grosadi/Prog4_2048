// <copyright file="HighScoreVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Collections.ObjectModel;
    using _2048.Data;
    using _2048.Repository;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// HighScore View Model.
    /// </summary>
    public class HighScoreVM : ViewModelBase
    {
        private GameRepository repo;
        private ObservableCollection<PLAYER> players;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreVM"/> class.
        /// </summary>
        public HighScoreVM()
        {
            this.repo = new GameRepository();
            this.players = new ObservableCollection<PLAYER>(this.repo.GetPlayerByScore());
        }

        /// <summary>
        /// Gets or sets the players of the viewmodel.
        /// </summary>
        public ObservableCollection<PLAYER> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.Set(ref this.players, value);
            }
        }

        /// <summary>
        /// Add new player to the DB.
        /// </summary>
        /// <param name="name">Name of the player.</param>
        /// <param name="score">Score of the player.</param>
        /// <param name="highest">Highest tile of the player.</param>
        public void AddPlayer(string name, int score, int highest)
        {
            this.repo.AddPlayer(name, score, highest);
        }
    }
}
