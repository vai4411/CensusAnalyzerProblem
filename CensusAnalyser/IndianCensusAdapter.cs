using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    class IndianCensusAdapter : CensusAdapter
    {
        private static readonly string CENSUS_HEADER = "State,Population,AreaInSqKm,DensityPerSqKm";
        public override Dictionary<string, CensusDTO> ReadCensusFile(string path,string header)
        {
            Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();
            string[] data = LoadData(path);
            if (data.ElementAt(0) != header)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER);
            foreach (string record in data.Skip(1))
            {
                string[] entries = record.Split(',');
                if (record.Split(',').Length != header.Split(',').Length)
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER);

                if (header.Equals(CENSUS_HEADER))
                    map.Add(entries[0], new CensusDTO(new IndiaCensusCSV(entries[0], entries[1], entries[2], entries[3])));
                else
                    map.Add(entries[1], new CensusDTO(new IndiaStateCodeCSV(entries[0], entries[1], entries[2], entries[3])));
            }
            return map;
        }
    }
}
