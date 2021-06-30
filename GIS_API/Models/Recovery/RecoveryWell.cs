using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_API.Models
{
    [Table("rgr.irrigationdistrict")]
    public partial class RecoveryWell : SdeRepository<RecoveryWell>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("irri.OBJECTID")]
        public int OBJECTID { get; set; }
        [Column("muni.NAME")]
        public string WATER_NAME { get; set; }
        [Column("LONG_NAME")]
        public string IRRI_NAME { get; set; }
        [Column("city.NAME")]
        public string CITY_NAME { get; set; }
        [Column("FILENO")]
        public string FILENO { get; set; }
    }
}
