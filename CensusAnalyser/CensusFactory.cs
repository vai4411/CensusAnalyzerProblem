// <copyright file="CensusFactory.cs" company="Bridgelabz">
// Copyright (c) Bridgelabz. All rights reserved.
// </copyright>

namespace CensusAnalyserProblem
{
    using System.Collections.Generic;

    /// <summary>
    /// This class used to implement factory pattern.
    /// </summary>
    public class CensusFactory
    {
        /// <summary>
        /// This method return dictionary of india and us data.
        /// </summary>
        /// <param name="country">Country name.</param>
        /// <param name="path">File path.</param>
        /// <param name="header">File header.</param>
        /// <returns>Dictonary of data.</returns>
        public Dictionary<string, CensusDTO> GetCensusData(CountryEnum country, string path, string header)
        {
            if (country.Equals(CountryEnum.INDIA))
            {
                return new IndianCensusAdapter().ReadCensusFile(path, header);
            }
            else if (country.Equals(CountryEnum.US))
            {
                return new USCensusAdapter().ReadCensusFile(path, header);
            }
            else
            {
                throw new CensusAnalyserException("Invalid country", CensusAnalyserException.ExceptionType.INVALID_COUNTRY);
            }
        }
    }
}
