// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace _2048.Logic
{
    using System;
    using _2048.Repository;
    using _2048.Repository.Seged;

    /// <summary>
    /// Handles Business Logic.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Gamemodel currently used by gamlogic.
        /// </summary>
        /// <param name="gameModel">gamemodel.</param>
        /// <param name="repository">repository.</param>
        public GameLogic(IGameModel gameModel, IRepository repository)
        {
            this.GameModel = gameModel;
            this.Repository = repository;
        }

        /// <summary>
        /// Gets or sets actual gamemodel.
        /// </summary>
        public IGameModel GameModel { get; set; }

        /// <summary>
        /// Gets or sets actual repository.
        /// </summary>
        public IRepository Repository { get; set; }

        /// <summary>
        /// The main method of the game, responsible for moving the tiles and spawning them in the right way.
        /// </summary>
        /// <param name="countdownFrom">param used for calculation.</param>
        /// <param name="yIncr">Y incrase.</param>
        /// <param name="xIncr">x Incrase.</param>
        /// <param name="side">The number of tile per side.</param>
        /// <returns>with a raction for a move.</returns>
        public bool Move(int countdownFrom, int yIncr, int xIncr, int side)
            {
                bool moved = false;
                for (int i = 0; i < side * side; i++)
                {
                    int j = Math.Abs(countdownFrom - i);

                    // we use this two variable for moving between tiles.
                    int r = j / side;
                    int c = j % side;

                    // if the tile is empty we should continue.
                    if (this.GameModel.Board[r, c] == null)
                    {
                        continue; // passes control to the next iteration of the enclosing while, do, for, or foreach statement in which it appears.
                }

                    // we make a move to the specified deriction
                    int nextR = r + yIncr;
                    int nextC = c + xIncr;

                    // while the tiles can move or cominate with each other.
                    while (nextR >= 0 && nextR < side && nextC >= 0 && nextC < side)
                    {
                        Tile next = this.GameModel.Board[nextR, nextC];
                        Tile curr = this.GameModel.Board[r, c];

                        // if newyt tile is null, we dontd do any combination , just move there
                        if (next == null)
                        {
                            if (this.GameModel.CheckAvailableMoves)
                            {
                                return true;
                            }

                            this.GameModel.Board[nextR, nextC] = curr;
                            this.GameModel.Board[r, c] = null;
                            r = nextR;
                            c = nextC;
                            nextR += yIncr;
                            nextC += xIncr;
                            moved = true;
                        }

                        // if merge is possible with the next tile we should combinate them and move then
                        else if (next.CanMergeWith(curr))
                        {
                            if (this.GameModel.CheckAvailableMoves)
                            {
                                return true;
                            }

                            // if the given tile has a bigger value than highest value we should overwrite the highest value.
                            int value = next.MergeWith(curr);
                            if (value > this.GameModel.Highest)
                            {
                                this.GameModel.Highest = value;
                            }

                            // after a move we incrase the score.
                            this.GameModel.Score += value;
                            this.GameModel.Board[r, c] = null;
                            moved = true;
                            break;
                        }

                        // else exit from the sequence.
                        else
                        {
                            break;
                        }
                    }
                }

                // if move was possible
                if (moved)
                {
                    this.Repository.ClearMerged();
                    this.Repository.SpawnRandomTile();

                    if (!this.MovesAvailable())
                    {
                        this.GameModel.GameOver = true;
                    }
                    else if (this.GameModel.Highest == 2048)
                    {
                        this.GameModel.Gamewin = true;
                    }
                }

                return moved;
            }

        /// <summary>
        /// Down.
        /// </summary>
        /// <returns>with a move downwards.</returns>
        public bool MoveDown()
        {
            return this.Move((this.GameModel.Gamesize * this.GameModel.Gamesize) - 1, 0, 1, this.GameModel.Gamesize);//le
        }

        /// <summary>
        /// Left.
        /// </summary>
        /// <returns>with a move left.</returns>
        public bool MoveLeft()
        {

            return this.Move(0, -1, 0, this.GameModel.Gamesize);//balra
        }

        /// <summary>
        /// Right.
        /// </summary>
        /// <returns>with a move right.</returns>
        public bool MoveRight()
        {
            
            return this.Move((this.GameModel.Gamesize * this.GameModel.Gamesize) - 1, 1, 0, this.GameModel.Gamesize);//jobbra
        }

        /// <summary>
        /// MovesAviable.
        /// </summary>
        /// <returns>If therer is any  more moves available.</returns>
        public bool MovesAvailable()
        {
            this.GameModel.CheckAvailableMoves = true;
            bool movesAvailable = this.MoveLeft() || this.MoveRight() || this.MoveUp() || this.MoveDown();
            this.GameModel.CheckAvailableMoves = false;
            return movesAvailable;
        }

        /// <summary>
        /// Up.
        /// </summary>
        /// <returns>with a move to upwards.</returns>
        public bool MoveUp()
        {
            
            return this.Move(0, 0, -1, this.GameModel.Gamesize);//fel
        }

        /// <summary>
        /// Calls the withdrawal method from repository.
        /// </summary>
        public void WithDrawal()
        {
            new NotImplementedException();
        }
    }
}
