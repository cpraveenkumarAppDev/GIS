using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HydrographTest.Models
{
    public class Hydrograph
    {
        public string Id { get; set; }
        public Uri ImageUri { get; set; }
        [JsonIgnore]
        public string Location { get; set; }

        public Hydrograph(string path)
        {
            var file = new FileInfo(path);

            this.Id = GetIdFromFileName(file.Name);
#if DEBUG
            this.ImageUri = new Uri(ConfigurationManager.AppSettings["DevelopmentEndpointPrefix"] + "getimage/" + this.Id);
#else
            this.ImageUri = new Uri(ConfigurationManager.AppSettings["ProductionEndpointPrefix"] + "getimage/" + this.Id);
#endif

            this.Location = path;
        }

        public string GetIdFromFileName(string name)
        {
            string id = "";

            Regex regex = new Regex(@"(\d{15})");
            Match match = regex.Match(name);

            if (match.Success)
            {
                id = match.Value;
            }
            else
            {
                id = "error";
            }

            return id;
        }
    }
}