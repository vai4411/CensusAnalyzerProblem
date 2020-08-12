using System.Collections.Generic;

namespace CensusAnalyserProblem
{
    public class CensusFactory
    {
        public Dictionary<string, CensusDTO> GetCensusData(CountryEnum country, string path, string header)
        {
            if (country.Equals(CountryEnum.INDIA))
                return new IndianCensusAdapter().ReadCensusFile(path, header);
            else if (country.Equals(CountryEnum.US))
                return new USCensusAdapter().ReadCensusFile(path, header);
            else
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_COUNTRY);
        }
    }
}
