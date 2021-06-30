using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HydrographTest.Models
{
    public class HydrographManager
    {
        public List<Hydrograph> Hydrographs { get; set; }

        public HydrographManager()
        {
            this.Hydrographs = new List<Hydrograph>();

            var imageDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/Content/Images/Hydrographs"));
            var images = imageDirectory.GetFiles().ToList();

            foreach (var fileInfo in images)
            {
                this.Hydrographs.Add(new Hydrograph(fileInfo.FullName));
            }
        }
    }
}