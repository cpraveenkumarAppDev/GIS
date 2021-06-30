//using Oracle.ManagedDataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GIS_API.Models
//{
//    [Table("RGR.REPORTING")]
//    public partial class Report : Repository<Report>
//    {
//        //[Key]
//        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        //[Column("REPORTID")]
//        //public int? ReportId { get; set; }


//        //[Column("WATERRIGHTNUMBER")]
//        ////[MinLength(10)]
//        //public string WaterRightNumber { get; set; }

//        //[RegularExpression(@"[A-Za-z\-\ ]+", ErrorMessage = "Please enter a valid name that does not include numbers or special characters")]
//        //[Required(ErrorMessage = "Filer Name field is required")]
//        //[StringLength(100, ErrorMessage = "Cannot be longer than 100 characters.")]
//        //[Column("FILERNAME")]
//        //public string FilerName { get; set; }

//        //[Column("EMAIL")]
//        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
//        //[Required(ErrorMessage = "Email field is required")]
//        //[StringLength(100, ErrorMessage = "Cannot be longer than 100 characters.")]
//        //[EmailAddress]
//        //public string Email { get; set; }

//        //[Column("PHONE")]
//        //[Phone]
//        //public string Phone { get; set; }

//        //[Required(ErrorMessage = "Title field is required")]
//        //[StringLength(100, ErrorMessage = "Cannot be longer than 100 characters.")]
//        //[Column("TITLE")]
//        //public string Title { get; set; }

//        //[Column("FILEDDATE")]
//        //public DateTime? FiledDate { get; set; }

//        //[Column("PCC")]
//        //public string PermitCertificateConveyanceNumber { get; set; }

//        //[Column("YR")]
//        //public int? Year { get; set; }

//        //[Column("FEES")]
//        //public string Fees { get; set; }

//        //[Column("CSMT_CODE")]
//        //public string SummarySchedule { get; set; }

//        //[Column("ALLOTMENT")]
//        //public decimal? Allotment { get; set; }

//        //[Column("RIGHT_TYPE")]
//        //public string RightType { get; set; }
//        //[Column("AMA")]
//        //public string ActiveManagementArea { get; set; }
//        //[Column("CAMA_CODE")]
//        //public string Code { get; set; }
//        //[Column("CSMT_DESCR")]
//        //public string FilingType { get; set; }
//        //[Column("ARS_ID")]
//        //public int? AnnualReportSummaryId { get; set; }
//        //[Column("TOTAL_WITHDRAWN_AF")]
//        //public decimal? TotalWithdrawn { get; set; }
//        //[Column("PAYMENTSTATUS")]
//        //public string PaymentStatus { get; set; }

//        //[Column("PRIMARY_IRRIGATION_PCC")]
//        //public string PrimaryIrrigationDistrictNumber { get; set; }

//        //[Column("PRIMARY_IRRIGATION_NAME")]
//        //public string PrimaryIrrigationDistrictName { get; set; }

//        //[Column("CREATEDT")]
//        //public DateTime? CreateDate { get; set; }

//        //[Column("SUBBASIN")]
//        //public string Subbasin { get; set; }

//        //[Column("IN_LIEU_PROVIDER_ID")]
//        //public int? Provider { get; set; }

//        //[Column("LOCATION")]
//        //public string Location { get; set; }

//        //[Column("FACILITY_NAME")]
//        //public string FacilityName { get; set; }
//        //[Column("FACILITY_PCC")]
//        //public string FacilityPermitCertificateConveyanceNumber { get; set; }
//        //[Column("FACILITY_ARS_ID")]
//        //public int? FacilityAnnualReportSummaryId { get; set; }

//        //[Column("IRRIGATION_ACRE")]
//        //public decimal? IrrigationAcres { get; set; }

//        //public static void Test()
//        //{
//        //    Report.Add(new Report
//        //    {
//        //        Email = "Fox@gox.com",
//        //        FiledDate = DateTime.Now,
//        //        FilerName = "Bob",
//        //        PermitCertificateConveyanceNumber = "123",
//        //        Title = "Boss",
//        //        WaterRightNumber = "123"
//        //    });
//        //    var paramaters = new List<OracleParameter>();
//        //    var oracleParamater = new OracleParameter("report_id_in", 9542);
//        //    paramaters.Add(oracleParamater);
//        //    //var result = Report.ExecuteStoredProcedure("BEGIN rgr.spkg_rg_cws_online_ar.spkp_load_online_ar(:report_id_in); end;", oracleParamater);
//        //}

//    }
//}