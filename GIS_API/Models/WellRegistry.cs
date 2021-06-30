using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GIS_API.Models
{
    [Table("WELLS.WELL_REGISTRY")]
    public class WellRegistry : Repository<WellRegistry>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("REGISTRY_ID")]
        public string RegistryId { get; set; }
        [Column("ASSESSOR_BOOK")]
        public string Book { get; set; }
        [Column("ASSESSOR_MAP")]
        public string Map { get; set; }
        [Column("ASSESSOR_PARCEL")]
        public string Parcel { get; set; }
        [Column("CNTY_CODE")]
        public string County { get; set; }
    }
}