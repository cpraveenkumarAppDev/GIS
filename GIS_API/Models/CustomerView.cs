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
    [Table("RGR.AR_CUSTOMER_VIEW")]
    public partial class CustomerView : Repository<CustomerView>
    {
        [Key, Column("WRF_ID", Order = 0)]
        public int WaterRightNumber { get; set; }

        [Key, Column("CUST_NAME", Order = 1)]
        public string CustomerName { get; set; }

        [Key, Column("CUSTOMER_TYPE", Order = 2)]
        public string CustomerType { get; set; }

        [Column("ADDRESS1")]
        public string Address1 { get; set; }

        [Column("ADDRESS2")]
        public string Address2 { get; set; }

        [Column("PHONE")]
        public string Phone { get; set; }

        [Column("CITY_STATE_ZIP")]
        public string CityStateZip { get; set; }

    }
}