using GIS_API.ViewModels;
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
    [Table("WRJRN.GISWEB_DATA")]
    public class GISWebData : Repository<GISWebData>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int? ID { get; set; }
        [Column("USERS_COUNT")]
        public int USERS_COUNT { get; set; }
        [Column("APPLICATION_NAME")]
        public string APPLICATION_NAME { get; set; }
        [Column("APPLICATION_URL")]
        public string APPLICATION_URL { get; set; }
        [Column("ENVIRONMENT")]
        public string ENVIRONMENT { get; set; }
        [Column("LOGGED_DATE")]
        public DateTime LOGGED_DATE { get; set; }
    }
}