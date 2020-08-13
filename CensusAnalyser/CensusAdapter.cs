// <copyright file="CensusAdapter.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// This class used for creating adapter pattern base class.
    /// </summary>
    internal abstract class CensusAdapter
    {
        /// <summary>
        /// This method reads the CSV file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="header">File header.</param>
        /// <returns>Abstract dictionary.</returns>
        public abstract Dictionary<string, CensusDTO> ReadCensusFile(string path, string header);

        /// <summary>
        /// This method loads data.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Array of data.</returns>
        public string[] LoadData(string path)
        {
            if (!File.Exists(path))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }

            if (Path.GetExtension(path) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }

            string[] data = File.ReadAllLines(path);
            return data;
        }
    }
}