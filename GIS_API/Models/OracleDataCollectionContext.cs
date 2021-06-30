namespace GIS_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GIS_API.Models;

    public partial class OracleDataCollectionContext : DbContext
    {
        public OracleDataCollectionContext()
            : base("name=OracleDataCollectionContext")
        {
        }


        public virtual DbSet<GISWebData> GISWebData { get; set; }

        //public virtual DbSet<CustomerView> CustomerViews { get; set; }


    }

}
