namespace GIS_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GIS_API.Models;

    public partial class OracleContext : DbContext
    {
        public OracleContext()
            : base("name=OracleContext")
        {
        }


        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportDetail> ReportDetails { get; set; }
        public virtual DbSet<WaterBankView> WaterBankView { get; set; }
        public virtual DbSet<WellsHubRecordUpdates> WellsHubRecordUpdates { get; set; }
        public virtual DbSet<AnnualReportData> AnnualReportData { get; set; }
        //public virtual DbSet<WellRegistry> WellRegistry { get; set; }

        //public virtual DbSet<CustomerView> CustomerViews { get; set; }


    }

}
