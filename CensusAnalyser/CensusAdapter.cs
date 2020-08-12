using System.Collections.Generic;
using System.IO;

namespace CensusAnalyserProblem
{
    abstract class CensusAdapter
    {
        public abstract Dictionary<string, CensusDTO> ReadCensusFile(string path,string header);

        public static Dictionary<string, CensusDTO> map = new Dictionary<string, CensusDTO>();
        public string[] LoadData(string path)
        {
            if (!File.Exists(path))
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            if (Path.GetExtension(path) != ".csv")
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            string[] data = File.ReadAllLines(path);
            return data;
        }
    }
}

