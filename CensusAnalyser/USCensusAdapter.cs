// <copyright file="USCensusAdapter.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class use for indian census adapter.
    /// </summary>
    internal class USCensusAdapter : CensusAdapter
    {
        /// <summary>
        /// This method return dictionary of state code and census data.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <param name="header">File header.</param>
        /// <returns>Dictonary of data.</returns>
        public override Dictionary<string, CensusDTO> ReadCensusFile(string path, string header)
        {
            Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();
            string[] data = this.LoadData(path);
            if (data.ElementAt(0) != header)
            {
                throw new CensusAnalyserException("Invalid header", CensusAnalyserException.ExceptionType.INVALID_HEADER);
            }

            foreach (string record in data.Skip(1))
            {
                string[] entries = record.Split(',');
                if (record.Split(',').Length != header.Split(',').Length)
                {
                    throw new CensusAnalyserException("Invalid delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }

                map.Add(entries[1], new CensusDTO(new CensusCSV(entries[0], entries[1], entries[2], entries[3], entries[4], entries[5], entries[6], entries[7], entries[8])));
            }

            return map;
        }
    }
}
