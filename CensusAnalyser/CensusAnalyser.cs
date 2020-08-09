using System.IO;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        string path;
        string header;

        public CensusAnalyser(string path,string header)
        {
            this.path = path;
            this.header = header;
        }

        public int getCount()
        {
            int count = 0;
            if (!File.Exists(path))
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            if (!path.Contains(".csv"))
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            string[] data = File.ReadAllLines(path);
            if (data[0] != header)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_HEADER);
            foreach (string record in data)
            {
                if (record.Split(',').Length != header.Split(',').Length)
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
            }
            for (int i = 0; i < data.Length; i++)
            {
                count++;
            }
            return count - 1;
        }
    }
}
