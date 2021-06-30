using GIS_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;


namespace GIS_API.ViewModels
{
    public class ProviderViewModel
    {
        public Report Report { get; set; }
        public List<ReportDetail> ReportDetails { get; set; }
        //public CustomerView CustomerView { get; set; }

        public ReportView ReportView { get; set; }

        public static ProviderViewModel GetData(string PermitCertificateConveyanceNumber, bool isAmended)
        {
            ProviderViewModel reportViewModel = new ProviderViewModel();
            if (PermitCertificateConveyanceNumber.ToUpper().StartsWith("AZ"))
            {
                reportViewModel.Report = Report.GetList(p => p.WaterRightNumber == PermitCertificateConveyanceNumber).OrderByDescending(y => y.FiledDate).ThenByDescending(x => x.Year).FirstOrDefault();
                reportViewModel.ReportDetails = ReportDetail.GetList(x => x.ReportId == reportViewModel.Report.ReportId);
            }
            else if (PermitCertificateConveyanceNumber.Length == 14)
            {
                reportViewModel.Report = Report.Get(p => p.PermitCertificateConveyanceNumber == PermitCertificateConveyanceNumber);
                var waterRightNumber = Int32.Parse(reportViewModel.Report.WaterRightNumber);
                //reportViewModel.CustomerView = CustomerView.Get(p => p.WaterRightNumber == waterRightNumber);
            }
            else
            {
                var id = int.Parse(PermitCertificateConveyanceNumber);
                reportViewModel.Report = Report.Get(p => p.ReportId == id);
                reportViewModel.ReportDetails = ReportDetail.GetList(x => x.ReportId == reportViewModel.Report.ReportId);
                PermitCertificateConveyanceNumber = reportViewModel.Report.PermitCertificateConveyanceNumber;
            }


            return reportViewModel;
        }
    }
}
