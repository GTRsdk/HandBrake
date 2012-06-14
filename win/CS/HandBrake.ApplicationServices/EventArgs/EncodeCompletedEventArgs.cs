﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EncodeCompletedEventArgs.cs" company="HandBrake Project (http://handbrake.fr)">
//   This file is part of the HandBrake source code - It may be used under the terms of the GNU General Public License.
// </copyright>
// <summary>
//   Encode Progress Event Args
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HandBrake.ApplicationServices.EventArgs
{
    using System;

    /// <summary>
    /// Encode Progress Event Args
    /// </summary>
    public class EncodeCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncodeCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="sucessful">
        /// The sucessful.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <param name="errorInformation">
        /// The error information.
        /// </param>
        public EncodeCompletedEventArgs(bool sucessful, Exception exception, string errorInformation)
        {
            this.Successful = sucessful;
            this.Exception = exception;
            this.ErrorInformation = errorInformation;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Successful.
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Gets or sets Exception.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets ErrorInformation.
        /// </summary>
        public string ErrorInformation { get; set; }
    }
}
