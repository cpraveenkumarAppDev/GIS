namespace GIS_API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GIS_API.Models;

    public partial class OracleSdeContext : DbContext
    {
        public OracleSdeContext()
            : base("name=OracleSdeContext")
        {
        }
       // public virtual DbSet<WellsHub> WellsHub { get; set; }
        public virtual DbSet<RecoveryWell> RecoveryWell { get; set; }
    }

}
