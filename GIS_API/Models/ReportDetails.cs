using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_API.Models
{
    [Table("RGR.REPORTING_DETAIL")]
    public class ReportDetail : Repository<ReportDetail>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("REPORTDETAILID")]
        public int? ReportDetailId { get; set; }

        [Column("REPORTID")]
        public int? ReportId { get; set; }

        [Column("REPORTTYPE")]
        public string ReportType { get; set; }

        [Column("SITENAME")]
        public string SiteName { get; set; }

        [Column("MUNICIPALITY")]
        public string Municipality { get; set; }

        [Column("TOTALCONNECTIONS")]
        public int? TotalConnections { get; set; }

        [Column("SOURCEORUSE")]
        public string SourceOrUse { get; set; }

        [Column("SOURCEORUSEDETAIL")]
        [StringLength(100, ErrorMessage = "Cannot be longer than 100 characters.")]
        public string SourceOrUseDetail { get; set; }

        [Column("RIGHTID")]
        [StringLength(14, ErrorMessage = "Water Right No. cannot be logner than 14 characters")]
        public string RightId { get; set; }

        [Column("REGISTRYID")]
        public string RegistryId { get; set; }

        [Column("METERED")]
        public string Metered { get; set; }

        [Column("ESTIMATIONDETAIL")]
        [StringLength(30, ErrorMessage = "Estimation Details cannot be longer than 30 characters.")]
        public string EstimationDetail { get; set; }

        [Column("QUANTITY")]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal Quantity { get; set; }

        [Column("BEGINREADING")]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal? StartReading { get; set; }

        [Column("ENDREADING")]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal? EndReading { get; set; }

        [Column("UNITOFMEASUREMENT")]
        public string UnitOfMeasurement { get; set; }

        [Column("COMMENTS")]
        public string Comments { get; set; }

        [Column("LOCATION")]
        public string Location { get; set; }

        [Column("WM_ID")]
        public int? WaterMovementId { get; set; }
    }
}
