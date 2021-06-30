using GIS_API.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using GIS_API.Models;
using System.Diagnostics;
using System.Data.Entity;

namespace GIS_API.Controllers
{
    public class AnalyticsController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/analytics/getdailygisdata")]
        public IHttpActionResult GetDailyGISData(string appName, string dateRange, string environment)
        {
            using (var context = new OracleDataCollectionContext())
            {
                //    var test = GISWebData.GetAllGISData();
                //    return Ok();
                //}
                if (appName != null && dateRange == null)
                {
                    var data = GISWebData.GetGISList(p => p.APPLICATION_NAME == appName.ToUpper() && p.ENVIRONMENT == environment);
                    return Json(data.OrderBy(p => p.LOGGED_DATE));
                }
                else if (appName == null && dateRange != null)
                {
                    string[] dates = dateRange.Split(',');
                    DateTime startDate = Convert.ToDateTime(dates[0]);
                    DateTime endDate = Convert.ToDateTime(dates[1]).AddDays(1);
                    var data = GISWebData.GetGISList(p => p.LOGGED_DATE >= startDate && p.LOGGED_DATE <= endDate && p.ENVIRONMENT == environment);
                    return Ok(data.OrderBy(p => p.LOGGED_DATE));
                }
                else if (appName != null && dateRange != null)
                {
                    string[] dates = dateRange.Split(',');
                    DateTime startDate = Convert.ToDateTime(dates[0]);
                    DateTime endDate = Convert.ToDateTime(dates[1]).AddDays(1);
                    var data = GISWebData.GetGISList(p => p.APPLICATION_NAME == appName && p.LOGGED_DATE >= startDate && p.LOGGED_DATE <= endDate && p.ENVIRONMENT == environment);
                    return Ok(data.OrderBy(p => p.LOGGED_DATE));
                }
                else if (appName == null && dateRange == null && environment != null)
                {
                    var data = GISWebData.GetGISList(p => p.ENVIRONMENT == environment);
                    return Ok(data.OrderBy(p => p.LOGGED_DATE));
                }
                else
                {
                    var allData = GISWebData.GetAllGISData();
                    var usersGroupedByDate = allData.GroupBy(user => user.LOGGED_DATE.Date);
                    return Json(allData.OrderBy(p => p.LOGGED_DATE));
                }
            }
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/analytics/getardata")]
        public IHttpActionResult GetArData()
        {
            var data = AnnualReportData.GetAll();
            return Json(data);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/analytics/annualreport")]
        public IHttpActionResult AnnualReportByYear(int year)
        {

            //using (var ctx = new OracleSdeContext())
            //{
            // var qryString = "select * from ADWR_ADMIN.ANNUAL_REPORT_DATA_VIEW";// t where t.yr = "+year;


            var qryString = "select extract(year from t.FILING_DATE) as LOGGED_DATE, count(*) as reports from ADWR_ADMIN.ANNUAL_REPORT_DATA_VIEW t GROUP BY extract(year from t.FILING_DATE) order BY extract(year from t.FILING_DATE)";
            //var recoveryData = ctx.RecoveryWell.SqlQuery(qryString).ToList();
            var arYealyData = Models.AdminQueryResult.RunAnyQuery(qryString);
            return Ok(arYealyData);
            //}
        }
    }
}