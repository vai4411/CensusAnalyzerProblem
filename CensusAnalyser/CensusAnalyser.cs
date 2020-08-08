using System;
using System.IO;

namespace CensusAnalyserProblem
{
    public class CensusAnalyser
    {
        public static int getStateCensusCount(string path)
        {
            int count = 0;
            if (!path.Contains("IndiaStateCensusData"))
                throw new CensusAnalyserException("Incorrect File");
            if (!path.Contains(".csv"))
                throw new CensusAnalyserException("Incorrect File Type");

            string[] census = File.ReadAllLines(path);
            if (census[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                throw new CensusAnalyserException("Incorrect File Header");
            foreach (string record in census)
            {
                if (!record.Contains(","))
                    throw new CensusAnalyserException("Incorrect Delimiter");
            }
            for (int i = 0; i < census.Length; i++)
            {
                count++;
            }
            return count - 1;
        }

        public static int getStateCodeCount(string path)
        {
            int count = 0;
            if (!path.Contains("IndiaStateCode"))
                throw new CensusAnalyserException("Incorrect File");
            if (!path.Contains(".csv"))
                throw new CensusAnalyserException("Incorrect File Type");

            string[] code = File.ReadAllLines(path);
            foreach (string record in code)
            {
                if (!record.Contains(","))
                    throw new CensusAnalyserException("Incorrect Delimiter");
            }
            for (int i = 0; i < code.Length; i++)
            {
                count++;
            }
            return count - 1;
        }
    }
}
