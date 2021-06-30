using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GIS_API.Models
{
    [Table("RGR.REPORTING_CWS_VIEW")]
    public partial class ReportView : Repository<ReportView>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("WRF_ID")]
        public int WaterRightFacilityId { get; set; }
        [Column("PCC")]
        public string ProgramCertificateConveyanceNumber { get; set; }
        [Column("WRF_NAME")]
        public string WaterRightFacilityName { get; set; }
        [Column("DEQ_NAME")]
        public string ADEQName { get; set; }
        [Column("CUSTOMER_NAME")]
        public string Name { get; set; }
        [Column("CUSTOMER_ADDR1")]
        public string Address { get; set; }
        [Column("CUSTOMER_ADDR2")]
        public string AddressLine2 { get; set; }
        [Column("CUSTOMER_CITY")]
        public string City { get; set; }
        [Column("CUSTOMER_STATE")]
        public string State { get; set; }
        [Column("ZIP_CODE")]
        public string Zip { get; set; }
        [Column("AMENDED")]
        public string Amended { get; set; }
        [Column("WDWR")]
        public string Well { get; set; }
        [Column("DIVT")]
        public string Diverted { get; set; }
        [Column("RECV")]
        public string Received { get; set; }
        [Column("DELV")]
        public string Delivered { get; set; }
        [Column("CUSTOMER_UNIT")]
        public string Customer { get; set; }
        [Column("EFFLUENT")]
        public string Treatment { get; set; }
        [Column("STORAGE_FACILITY")]
        public string Storage { get; set; }
        [Column("DAWSPCC")]
        public string DesignatedAdequateWaterSupply { get; set; }
    }
}
