﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseModel.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Bhargavi Nadimpalli"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooModels
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// class response model
    /// </summary>
    /// <typeparam name="T">of type T</typeparam>
    public class ResponseModel<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseModel{T}"/> is status.
        /// </summary>
        /// <value>
        ///   <c>true</c> if status; otherwise, <c>false</c>.
        /// </value>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data { get; set; }

       
    }
}
