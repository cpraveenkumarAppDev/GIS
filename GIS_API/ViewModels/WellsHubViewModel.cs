using GIS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;


namespace GIS_API.ViewModels
{
    public class WellsHubViewModel
    {
        public string WELL_ID { get; set; }
        public string WELL_SOURCE { get; set; }
        public string ISSUE { get; set; }
        public string ISSUE_TYPE { get; set; }
        //public DateTime ISSUE_DATE { get; set; }
        public string STATUS { get; set; }
        public string IDENTIFIED_BY { get; set; }
        public string COMMENTS { get; set; }
    }
}
