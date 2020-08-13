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

        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INVALID_HEADER,
            INVALID_DELIMITER,
            INVALID_FILE_TYPE,
            INVALID_COUNTRY,
        }

        public ExceptionType exceptionType;

        public CensusAnalyserException(ExceptionType exceptionType)
            : base(exceptionType.ToString())
        {
            this.exceptionType = exceptionType;
        }
    }
}
