using GIS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;


namespace GIS_API.ViewModels
{
    public class WaterbankViewModel
    {

        public static List<WaterBankView> GetData(string ama_ina)
        {
            //WaterbankViewModel waterbankViewModel = new WaterbankViewModel();
            var waterbankViewModel =  WaterBankView.GetList(p => p.AMA_INA == ama_ina).ToList();

            return waterbankViewModel;
        }
        public static List<WaterBankView> GetAll()
        {
            //WaterbankViewModel waterbankViewModel = new WaterbankViewModel();
            var waterbankViewModel = WaterBankView.GetAll();

            return waterbankViewModel;
        }
    }
}
