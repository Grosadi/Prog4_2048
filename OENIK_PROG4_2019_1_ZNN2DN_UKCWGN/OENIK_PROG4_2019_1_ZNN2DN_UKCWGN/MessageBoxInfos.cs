// <copyright file="MessageBoxInfos.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace OENIK_PROG4_2019_1_ZNN2DN_UKCWGN
{
    using System.Windows.Media;

    /// <summary>
    /// Class, what contains infos about the custom messagebox.
    /// </summary>
    public class MessageBoxInfos
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxInfos"/> class.
        /// </summary>
        public MessageBoxInfos()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxInfos"/> class.
        /// </summary>
        /// <param name="msg">Message.</param>
        /// <param name="button">Button content.</param>
        /// <param name="brush">Message color/brush.</param>
        public MessageBoxInfos(string msg, string button, Brush brush)
        {
            this.Msg = msg;
            this.Button = button;
            this.MsgBrush = brush;
        }

        /// <summary>
        /// Gets or sets the message of messagebox.
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Gets or sets the content of the button.
        /// </summary>
        public string Button { get; set; }

        /// <summary>
        /// Gets or sets the color of the message.
        /// </summary>
        public Brush MsgBrush { get; set; }
    }
}
