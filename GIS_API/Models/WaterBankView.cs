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
    [Table("RGR.AWBA_CREDIT_VIEW1")]
    public partial class WaterBankView : Repository<WaterBankView>
    {

        //[Column("LTSA")]
        //public string LongTermStorageNumber { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ROW_NUM")]
        public int OBJECTID { get; set; }
        [Column("AMA_INA")]
        public string AMA_INA { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Column("WSP_HOLDER")]
        //public string WSP_Holder { get; set; }

        [Column("FACILITY_PC")]
        public string Facility_PCC { get; set; }

        [Column("FACILITY_NAME")]
        public string Facility_Name { get; set; }
        [Column("FACILITY_TYPE")]
        public string Facility_Type { get; set; }

        [Column("FACILITY_CAPACITY")]
        public int? Facility_Capacity { get; set; }

        [Column("LAST_YR_STORED")]
        public int? LastYearStored { get; set; }
        [Column("OTHER_DEBIT")]
        public int? OtherDebit { get; set; }
        [Column("TRANSFER_IN")]
        public int? TransferIn { get; set; }

        [Column("TRANSFER_OUT")]
        public int? TransferOut { get; set; }
        [Column("INTERSTATE_CREDITS")]
        public int? InterstateCredits { get; set; }
        [Column("ARIZONA_CREDITS")]
        public int? ArizonaCredits { get; set; }
    }
}