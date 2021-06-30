using GIS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;


namespace GIS_API.ViewModels
{
    public class GISWebDataViewModel
    {
        public GISWebData GISWebData { get; set; }
        public void SaveNewRecord()
        {
            GISWebData.APPLICATION_NAME = "GWSI";
            GISWebData.APPLICATION_URL = "https://gisweb3.azwater.gov/gwsi";
            GISWebData.Add(GISWebData);
        }
    }
}
