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

            string[] n = File.ReadAllLines(path);
            if (n[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                throw new CensusAnalyserException("Incorrect File Header");
            foreach (string record in n)
            {
                if (!record.Contains(","))
                    throw new CensusAnalyserException("Incorrect Delimiter");
            }
            for (int i = 0; i < n.Length; i++)
            {
                count++;
            }
            return count - 1;
        }

        public static int getStateCodeCount(string path)
        {
            int count = 0;
            string[] n = File.ReadAllLines(path);
            for (int i = 0; i < n.Length; i++)
            {
                count++;
            }
            return count - 1;
        }
    }
}
