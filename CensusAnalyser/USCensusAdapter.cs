using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyserProblem
{
    class USCensusAdapter : CensusAdapter
    {
        public override Dictionary<string, CensusDTO> ReadCensusFile(string path, string header)
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

                map.Add(entries[1], new CensusDTO(new USCensusCSV(entries[0], entries[1], entries[2]
                        , entries[3], entries[4], entries[5], entries[6], entries[7], entries[8])));
            }
            return map;
        }
    }
}
