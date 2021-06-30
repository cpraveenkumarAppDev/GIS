using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_API.Models
{
    [Table("WELLS.WELLSHUB_STATIC")]
    public partial class WellsHub : SdeRepository<WellsHub>
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("OBJECTID")]
    public int OBJECTID { get; set; }
    [Column("REGISTRY_ID")]
    public string REGISTRY_ID { get; set; }
    [Column("SHAPECLOB")]
    public string SHAPECLOB { get; set; }
    //[Column("SITE_ID")]
    //public string SITE_ID { get; set; }
    //[Column("WELL35_ID")]
    //public string WELL35_ID { get; set; }
    //[Column("ISSUE")]
    //public string ISSUE { get; set; }
    //[Column("ISSUE_TYPE")]
    //public string ISSUE_TYPE { get; set; }
    //[Column("STATUS")]
    //public string STATUS { get; set; }
    //[Column("CADASTRAL")]
    //public string CADASTRAL { get; set; }
    //[Column("OWNER_NAME")]
    //public string OWNER_NAME { get; set; }
    //[Column("WELLTYPE")]
    //public string WELLTYPE { get; set; }
    //[Column("RGR_PUMP_DATA")]
    //public string RGR_PUMP_DATA { get; set; }
    //[Column("WELL_TYPE_GROUP")]
    //public string WELL_TYPE_GROUP { get; set; }
    //[Column("APPROVED")]
    //public DateTime APPROVED { get; set; }
    //[Column("INSTALLED")]
    //public DateTime INSTALLED { get; set; }
    //[Column("WELL_DEPTH")]
    //public int WELL_DEPTH { get; set; }
    //[Column("WATER_LEVEL")]
    //public int WATER_LEVEL { get; set; }
    //[Column("CASING_DEPTH")]
    //public int CASING_DEPTH { get; set; }
    //[Column("CASING_DIAMETER")]
    //public int CASING_DIAMETER { get; set; }
    //[Column("CASING_TYPE")]
    //public string CASING_TYPE { get; set; }
    //[Column("PUMPRATE")]
    //public int PUMPRATE { get; set; }
    //[Column("DRAW_DOWN")]
    //public int DRAW_DOWN { get; set; }
    //[Column("COMPLETION_REPORT_STATUS")]
    //public string COMPLETION_REPORT_STATUS { get; set; }
    //[Column("DRILL_LOG")]
    //public string DRILL_LOG { get; set; }
    //[Column("WELL_CANCELLED")]
    //public string WELL_CANCELLED { get; set; }
    //[Column("UTM_X_METERS")]
    //public long UTM_X_METERS { get; set; }
    //[Column("UTM_Y_METERS")]
    //public long UTM_Y_METERS { get; set; }
    //[Column("APPLICATION_DATE")]
    //public DateTime APPLICATION_DATE { get; set; }
    //[Column("ADDRESS1")]
    //public string ADDRESS1 { get; set; }
    //[Column("ADDRESS2")]
    //public string ADDRESS2 { get; set; }
    //[Column("CITY")]
    //public string CITY { get; set; }
    //[Column("STATE")]
    //public string STATE { get; set; }
    //[Column("ZIP")]
    //public string ZIP { get; set; }
    //[Column("ZIP4")]
    //public string ZIP4 { get; set; }
    //[Column("LOCAL_ID")]
    //public string LOCAL_ID { get; set; }
    //[Column("WL_COUNT")]
    //public int WL_COUNT { get; set; }
    //[Column("LASTWLDATE")]
    //public string LASTWLDATE { get; set; }
    //[Column("WL_DTW")]
    //public long WL_DTW { get; set; }
    //[Column("WL_ELEV")]
    //public long WL_ELEV { get; set; }
    //[Column("WELL_SOURCE")]
    //public string WELL_SOURCE { get; set; }
    }
    }
