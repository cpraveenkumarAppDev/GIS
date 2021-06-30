using HydrographTest.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HydrographTest.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HydrographController : ApiController
    {

        private HydrographManager hManager = new HydrographManager();

        /// <summary>
        /// Get All Hydrograph Objects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/getall")]
        public IEnumerable<Hydrograph> GetAllHydrographs()
        {
            return hManager.Hydrographs;
        }

        /// <summary>
        /// Get Hydrograph object by GWSI Site ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/gethydrograph/{id}")]
        public Hydrograph GetHydrograph(string id)
        {
            return hManager.Hydrographs.FirstOrDefault(h => h.Id == id);
        }

        /// <summary>
        /// Get Hydrograph image by GWSI Site ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/getimage/{id}")]
        public HttpResponseMessage GetImage(string id)
        {
            var hydrograph = hManager.Hydrographs.Single(h => h.Id == id);
            Image img = Image.FromFile(hydrograph.Location);
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(stream.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return result;
            }
        }

        /// <summary>
        /// Get a default image when Hydrograph is unavailable
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/getimageunavailable")]
        public HttpResponseMessage GetImageUnavailable()
        {
            Image img = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images/Image_Unavailable.PNG"));
            //Image img = Image.FromFile(new Uri("~Content/Images/Image_Unavailable.PNG").ToString());
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(stream.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                return result;
            }
        }

        /// <summary>
        /// Get all GWSI Site IDs for which there is a Hydrograph Image
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/getallsiteids")]
        public IEnumerable<string> GetAllSiteIds()
        {
            var test = hManager.Hydrographs.Select(x => x.Id).ToList();
            return test;
        }

        /// <summary>
        /// Used to supply an ESRI query string for selecting all Site IDs for which there are Hydrographs available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/hydrograph/getavailablehydrographquerystring")]
        public string GetAvailableHydrographQueryString()
        {
            List<string> siteIds = GetAllSiteIds().ToList();
            string esriQuery = "";
            foreach(string item in siteIds)
            {
                if (siteIds.IndexOf(item) == siteIds.Count-1)
                {
                    esriQuery += $"SITE_ID = \'{item}\'";
                }
                else
                {
                    esriQuery += $"SITE_ID = \'{item}\' OR ";
                }
            }
            return esriQuery;
        }
    }
}