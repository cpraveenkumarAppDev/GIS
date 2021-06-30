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
    [Table("ADWR_ADMIN.HUB_QA")]
    public class WellsHubRecordUpdates : Repository<WellsHubRecordUpdates>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ? ID { get; set; }
        [Column("WELL_ID")]
        public string WELL_ID { get; set; }
        [Column("WELL_SOURCE")]
        public string WELL_SOURCE { get; set; }
        [Column("ISSUE")]
        public string ISSUE { get; set; }
        [Column("ISSUE_TYPE")]
        public string ISSUE_TYPE { get; set; }
        [Column("ISSUE_DATE")]
        public DateTime ISSUE_DATE { get; set; }
        [Column("STATUS")]
        public string STATUS { get; set; }
        [Column("IDENTIFIED_BY")]
        public string IDENTIFIED_BY { get; set; }
        [Column("ISSUE_OWNER")]
        public string ISSUE_OWNER { get; set; }
        [Column("COMMENTS")]
        public string COMMENTS { get; set; }
        [Column("LOCATION")]
        public string LOCATION { get; set; }
    }
}