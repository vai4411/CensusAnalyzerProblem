namespace CensusAnalyserProblem
{
    public class CensusDTO
    {
        public string state;
        public int sr;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public CensusDTO(IndiaCensusCSV indiaCensusDAO)
        {
            this.state = indiaCensusDAO.state;
            this.population = indiaCensusDAO.population;
            this.area = indiaCensusDAO.area;
            this.density = indiaCensusDAO.density;
        }

        public CensusDTO(IndiaStateCodeCSV stateCodeDAO)
        {
            this.sr = stateCodeDAO.sr;
            this.state = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }

        public CensusDTO(USCensusCSV usCensusDAO)
        {
            this.stateCode = usCensusDAO.stateCode;
            this.state = usCensusDAO.state;
            this.population = usCensusDAO.population;
            this.housingUnits = usCensusDAO.housingUnits;
            this.totalArea = usCensusDAO.totalArea;
            this.waterArea = usCensusDAO.waterArea;
            this.landArea = usCensusDAO.landArea;
            this.populationDensity = usCensusDAO.populationDensity;
            this.housingDensity = usCensusDAO.housingDensity;
        }
    }
}
