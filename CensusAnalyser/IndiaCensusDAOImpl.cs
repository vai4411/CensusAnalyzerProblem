using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CensusAnalyserProblem
{
    class IndiaCensusDAOImpl : IndiaCensusDAO
    {
        System.Collections.IDictionary IndiaCensusDAO.GetTotalEntries(string path)
        {
            string[] data = File.ReadAllLines(path);
            return data.ToDictionary(key => key, value => value);
        }
    }
}
