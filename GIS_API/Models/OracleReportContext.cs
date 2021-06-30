namespace GIS_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GIS_API.Models;

    public partial class OracleReportContext : DbContext
    {
        public OracleReportContext()
            : base("name=OracleReportContext")
        {
        }


        public virtual DbSet<WellRegistry> WellRegistry { get; set; }

        //public virtual DbSet<CustomerView> CustomerViews { get; set; }


    }

}
