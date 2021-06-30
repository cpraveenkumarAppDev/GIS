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
    [Table("ADWR_ADMIN.ANNUAL_REPORT_DATA_VIEW")]
    public class AnnualReportData : Repository<AnnualReportData>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("YR")]
        public int? YR { get; set; }
        [Column("CSMT_CODE")]
        public string CSMT_CODE { get; set; }
        [Column("OL")]
        public int? OL { get; set; }
        [Column("FILING_DATE")]
        public DateTime FILING_DATE { get; set; }
    }
}