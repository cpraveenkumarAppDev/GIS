using GIS_API.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using GIS_API.Utils;
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
using System.Drawing;
using System.IO;
using System.Web;
using System.Net.Http.Headers;
using System.Text;

namespace GIS_API.Controllers
{
    //[EnableCors(origins: "", headers: "http://localhost:3000", methods: "*")]
    public class MappingController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/mapping/config/{id}")]
        public HttpResponseMessage Config(string id)
        {
            var json = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/MapConfig/" + id + ".json"));

            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/mapping/image/{id}")]
        public HttpResponseMessage Image(string id)
        {
            var json = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/Content/Images/" + id));

            return new HttpResponseMessage()
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/waterbankdetails")]
        public IHttpActionResult WaterBankDetails(string ama_ina)
        {
            return Json(WaterbankViewModel.GetData(ama_ina));
        }

        [System.Web.Http.HttpGet]
        [OutputCache(Duration = 2419200, VaryByParam = "none")]
        [System.Web.Http.Route("api/mapping/waterbankAll")]
        public IHttpActionResult WaterbankAll()
        {
            var data = WaterbankViewModel.GetAll();
            //var dataGrouped = data.GroupBy(p => p.AMA_INA);
            return Json(data);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/lookupdata")]
        public IHttpActionResult LookupData(string id)
        {
            return Json(ProviderViewModel.GetData(id, false));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/wellshub")]
        //[System.Web.Http.Authorize]
        public IHttpActionResult WellsHubUpdates(WellsHubRecordUpdates wellsHubRecordUpdates)
        {
            try
            {
                if (wellsHubRecordUpdates.IDENTIFIED_BY.Contains("AZWATER0"))
                {
                    dynamic dataUpdate = wellsHubRecordUpdates;
                    dataUpdate.IDENTIFIED_BY = wellsHubRecordUpdates.IDENTIFIED_BY;
                    dataUpdate.ISSUE_DATE = DateTime.Now;
                    WellsHubRecordUpdates.Add(dataUpdate);
                    var data = WellsHubRecordUpdates.GetList(p => p.LOCATION != null, new OracleContext());
                    return Ok("Submitted");
                }
                else
                {
                    return Ok("Invalid user!");
                }
            }
            catch
            {
                return Ok("ERROR!");
            };
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetWellsHub()
        {
            var data = WellsHubRecordUpdates.GetList(p => p.LOCATION != null, new OracleContext());
            return Ok(data);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/wellonparcelsearch")]
        public IHttpActionResult WellOnParcelSearch(string book, string map, string parcel, string county)
        {
            var parcelModified = parcel;
            if (!Char.IsDigit(parcel[parcel.Length - 1]))
            {
                parcelModified = parcelModified.Substring(0, 3);
            };
            var results = WellRegistry.GetList(p => p.Book == book && p.Map == map && p.Parcel.Contains(parcelModified) && p.County == county, new OracleReportContext());
            return Json(results);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/error")]
        public IHttpActionResult Error(ErrorNotification Error)
        {
            var jsonString = JsonConvert.SerializeObject(Error);
            //Attachment attachment = new Attachment(jsonString);
            MailMessage mailMessage = new MailMessage(ConfigurationManager.AppSettings["noreplyEmailAccount"].ToString(),
                       ConfigurationManager.AppSettings["ErrorEmailAccount"].ToString(),
                     JsonConvert.SerializeObject(Error.environment) + "WEBMAP ERROR!!! " + JsonConvert.SerializeObject(Error.message) + " in " + JsonConvert.SerializeObject(Error.fileName),
                       jsonString);
            //EmailUtil.Message(mailMessage);
            return Json(Error);

        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/mapping/wellshubAuthentication")]
        [System.Web.Http.Authorize]
        public IHttpActionResult wellshubAuthentication()
        {

            //To autmoatically login -> http://www.scip.be/index.php?Page=ArticlesNET38&Lang=EN
            var user = User.Identity.Name;
            if (user.Equals(""))
            {
                return Unauthorized();
            }
            else
            {
                return Ok(user);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/mapstatus")]
        public IHttpActionResult MapStatus(string mapName)
        {
            var map = ConfigurationManager.AppSettings[mapName + "Status"].ToString();
            return Ok(map);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/userscount")]
        public IHttpActionResult UsersCount(string appName, string appUrl, string appEnv)
        {
            DateTime todaysDate = System.DateTime.Now;
            var dataExists = GISWebData.GetDataCollection(p => DbFunctions.TruncateTime(p.LOGGED_DATE) == DbFunctions.TruncateTime(todaysDate) && p.APPLICATION_NAME == appName.ToUpper() && p.APPLICATION_URL == appUrl && p.ENVIRONMENT == appEnv, new OracleDataCollectionContext());
            if (dataExists == null)
            {
                using (var myDb = new OracleDataCollectionContext())
                {
                    var newRecord = new GISWebData
                    {
                        APPLICATION_NAME = appName.ToUpper(),
                        APPLICATION_URL = appUrl,
                        ENVIRONMENT = appEnv
                    };
                    myDb.GISWebData.Add(newRecord);
                    myDb.Entry(newRecord).State = EntityState.Added; //this is for modiying/update existing entry
                    myDb.SaveChanges();
                };
                var recordAdded = GISWebData.GetDataCollection(p => DbFunctions.TruncateTime(p.LOGGED_DATE) == DbFunctions.TruncateTime(todaysDate), new OracleDataCollectionContext());
                return Ok(recordAdded);
            }
            else
            {
                using (var myDb = new OracleDataCollectionContext())
                {
                    dataExists.USERS_COUNT = dataExists.USERS_COUNT + 1;
                    myDb.GISWebData.Add(dataExists);
                    myDb.Entry(dataExists).State = EntityState.Modified; //this is for modiying/update existing entry
                    myDb.SaveChanges();
                };
                var dataUpdated = GISWebData.GetDataCollection(p => DbFunctions.TruncateTime(p.LOGGED_DATE) == DbFunctions.TruncateTime(todaysDate) && p.APPLICATION_NAME == appName.ToUpper() && p.APPLICATION_URL == appUrl, new OracleDataCollectionContext());
                return Ok(dataUpdated);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/mapping/recoverybuffer/{id}")]
        public IHttpActionResult RecoveryBuffer(string id)
        {
            var qryString = "select OBJECTID, WATER_NAME, IRRI_NAME, FILENO from " +
            "(select distinct irri.OBJECTID, null as WATER_NAME, LONG_NAME as IRRI_NAME, FILENO from wells.wellregistry t, rgr.irrigationdistrict_dissolve irri where t.registry_id in (" + id + ") and sde.st_intersects(sde.st_buffer(t.shape, 3, 'mile'), irri.shape) = 1 " +
            " union select distinct muni.OBJECTID as ID, NAME as WATER_NAME, null, FILENO from wells.wellregistry t, rgr.muniserviceareas muni where t.registry_id in (" + id + ") and sde.st_intersects(sde.st_buffer(t.shape, 3, 'mile'), muni.shape) = 1) ";

            var recoveryData = Models.QueryResult.RunAnyQuery(qryString);
            return Ok(recoveryData);
        }

    }
}
