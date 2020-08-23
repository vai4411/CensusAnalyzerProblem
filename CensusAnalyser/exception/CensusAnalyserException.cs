// <copyright file="CensusAnalyserException.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    using System;

    /// <summary>
    /// This class used for custom exception.
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        public string message;

        /// <summary>
        /// This enum used for exception type.
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_HEADER,
            INVALID_DELIMITER,
            INVALID_FILE_TYPE,
            INVALID_COUNTRY,
        }

        public ExceptionType exceptionType;

        /// <summary>
        /// This method used for throw exception.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="exceptionType">Exception type.</param>
        public CensusAnalyserException(string message, ExceptionType exceptionType)
            : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
