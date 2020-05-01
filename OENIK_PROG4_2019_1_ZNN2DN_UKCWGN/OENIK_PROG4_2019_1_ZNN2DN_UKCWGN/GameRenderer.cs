// <copyright file="GameRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using _2048.Repository;
    using _2048.Repository.Seged;

    /// <summary>
    /// asd.
    /// </summary>
    public class GameRenderer
    {
        private GameModel model;

        private int width = 400;
        private int height = 500;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model">GameModel.</param>
        public GameRenderer(GameModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Gets or sets the background.
        /// </summary>
        public Drawing OldBackground { get; set; }

        /// <summary>
        /// Gets or sets the score formatted text.
        /// </summary>
        public Drawing OldScore { get; set; }

        /// <summary>
        /// Gets or sets the withdraw formatted text.
        /// </summary>
        public Drawing OldWithDraw { get; set; }

        /// <summary>
        /// This method is responsible for Drawing.
        /// </summary>
        /// <returns>A group of drawings.</returns>
        public Drawing BuildDrawing()
        {
            DrawingGroup dg = new DrawingGroup();

            this.model.Gamesize = 4; // ezek a tesztelés miatt vannak itt, INNENTŐL-
            this.model.Board = new Tile[this.model.Gamesize, this.model.Gamesize];
            this.model.Score = 1204235;
            this.model.WithdrawNum = 5;

            for (int i = 0; i < this.model.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Board.GetLength(1); j++)
                {
                    this.model.Board[i, j] = new Tile(4096);
                }
            } // - IDÁIG

            dg.Children.Add(this.GetBackground());

            for (int i = 0; i < this.model.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Board.GetLength(1); j++)
                {
                    dg.Children.Add(this.GetTile(this.model.Board[i, j], i, j));
                }
            }

            for (int i = 0; i < this.model.Board.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Board.GetLength(1); j++)
                {
                    dg.Children.Add(this.GetTile(this.model.Board[i, j], i, j));
                }
            }

            dg.Children.Add(this.GetScore());
            dg.Children.Add(this.GetScoreValue());
            dg.Children.Add(this.GetWithDrawal());
            dg.Children.Add(this.GetWithDrawalNum());

            return dg;
        }

        /// <summary>
        /// Creates background if not exists.
        /// </summary>
        /// <returns>Background drawing.</returns>
        public Drawing GetBackground()
        {
            if (this.OldBackground == null)
            {
                this.OldBackground = new GeometryDrawing(
                    Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0, 0, this.width, this.height)));
            }

            return this.OldBackground;
        }

        /// <summary>
        /// This method is responsible for the drawing of the current tile.
        /// </summary>
        /// <param name="tile">Current Tile.</param>
        /// <param name="i">Wich tile in the row.</param>
        /// <param name="j">Wich tile int the column.</param>
        /// <returns>The curret tile as a Drawing.</returns>
        public Drawing GetTile(Tile tile, int i, int j)
        {
            int x = (i * (this.width / this.model.Gamesize)) + 5;
            int y = (j * (this.width / this.model.Gamesize)) + 100;

            int tileSize = this.width / this.model.Gamesize;

            if (tile.Value != 0)
            {
                DrawingGroup dg = new DrawingGroup();
                dg.Children.Add(new GeometryDrawing(
                   this.ValueToBackgroundBrush(tile.Value),
                   new Pen(Brushes.Black, 2),
                   new RectangleGeometry(new Rect(x, y, tileSize, tileSize), 15, 15)));

                FontFamilyConverter ffc = new FontFamilyConverter();
                FontFamily fontFamily = (FontFamily)ffc.ConvertFromString("Helvetica Neue");
                Typeface typeface = new Typeface(fontFamily, FontStyles.Normal, FontWeights.Bold, FontStretches.Condensed);
                FormattedText fm = new FormattedText(
                    tile.Value.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    typeface,
                    20,
                    Brushes.Red);

                dg.Children.Add(new GeometryDrawing(
                    Brushes.Red,
                    new Pen(Brushes.Red, 1),
                    fm.BuildGeometry(new Point(
                        x + (tileSize / 2) - (fm.Width / 2),
                        y + (tileSize / 2) - (fm.Height / 2)))));

                return dg;
            }

            return new GeometryDrawing(
                Brushes.LightGray,
                new Pen(Brushes.Black, 2),
                new RectangleGeometry(new Rect(x, y, tileSize, tileSize)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Drawing GetScoreValue()
        {
            FormattedText scoreFM = new FormattedText(
                this.model.Score.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                24,
                Brushes.Gold);

            double y = (this.width / 2) - ((this.model.Score.ToString().Length * 12) / 2);

            GeometryDrawing score = new GeometryDrawing(
                null,
                new Pen(Brushes.Gold, 2),
                scoreFM.BuildGeometry(new Point(y, 50)));

            return score;
        }

        public Drawing GetScore()
        {
            if (this.OldScore == null)
            {
                FormattedText scoreFM = new FormattedText(
                "Score",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                24,
                Brushes.Gold);

                double x = (this.width / 2) - ((5 * 12) / 2);

                this.OldScore = new GeometryDrawing(
                    null,
                    new Pen(Brushes.Gold, 2),
                    scoreFM.BuildGeometry(new Point(x, 10)));
            }

            return this.OldScore;
        }

        public Drawing GetWithDrawal()
        {
            if (this.OldWithDraw == null)
            {
                FormattedText fm = new FormattedText(
                "Press space\nto withdraw!",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                20,
                Brushes.Gold);

                this.OldWithDraw = new GeometryDrawing(
                    null,
                    new Pen(Brushes.Gold, 1),
                    fm.BuildGeometry(new Point(5, 5)));
            }

            return this.OldWithDraw;
        }

        public Drawing GetWithDrawalNum()
        {
            FormattedText fm = new FormattedText(
                this.model.WithdrawNum.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                20,
                Brushes.Gold);

            GeometryDrawing wd = new GeometryDrawing(
                null,
                new Pen(Brushes.Gold, 1),
                fm.BuildGeometry(new Point(50, 50)));

            return wd;
        }

        /// <summary>
        /// Returns a specified Brush depends of TileValue.
        /// </summary>
        /// <param name="value"> Tile value.</param>
        /// <returns>A brush.</returns>
        public Brush ValueToBackgroundBrush(int value)
        {
            switch (value)
            {
                case 2:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#EEE4DA");
                case 4:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#ECE0C8");
                case 8:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#F2B179");
                case 16:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#F59563");
                case 32:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#F57C5F");
                case 64:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#F65D3B");
                case 128:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#EDCE71");
                case 256:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#EECC61");
                case 512:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#ECC850");
                case 1024:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#EDC53F");
                case 2048:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#EEC22E");
                case 4096:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#BEEE2E");
                default:
                    return (SolidColorBrush)new BrushConverter().ConvertFrom("#3D3A33");
            }
        }
    }
}
