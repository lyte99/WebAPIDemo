using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiClassV2.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace WebApiClassV2.Controllers
{
    public class HomeController : Controller
    {

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AFElementSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AFElementSearch(string searchEntry)
        {
            searchEntry = Request.Form["searchEntry"];
    
            //database element search
            string URL = "https://develop2/piwebapi/elements/search?databasewebID=F1RDR7ftT9N1JUm5hpKmIGX_5Q56nxrB6-30CkjGNH9ha9fgREVWRUxPUDJcQU5EWQ&query=Name:=" + searchEntry;

            //not using kerberos authentication
            NetworkCredential credentials = GetNetworkCredentials();

            //element search
            Task<string> task = Task.Run(async () => await GetPIDataAsync(URL, credentials));
            task.Wait();
            string content = task.Result;
            AFElementSearchResults.RootObject searchResults = JsonConvert.DeserializeObject<AFElementSearchResults.RootObject>(content);

            return View(searchResults);
        }

        public IActionResult AttributeView(string elementID)
        {
            //lists attributes of elements
            string URL = "https://develop2/piwebapi/elements/" + elementID + "/attributes";

            //not using kerberos authentication
            NetworkCredential credentials = GetNetworkCredentials();

            //get attributes of submited element
            Task<string> task = Task.Run(async () => await GetPIDataAsync(URL, credentials));
            task.Wait();
            string content = task.Result;
            AFAttributeList.RootObject attributelist = JsonConvert.DeserializeObject<AFAttributeList.RootObject>(content);

            return View(attributelist);
        }


        public IActionResult ViewAttribData(string attribName, string attribWebID, string plotdatalink)
        {
            //link to plot data
            string URL = plotdatalink;

            //not using kerberos authentication
            NetworkCredential credentials = GetNetworkCredentials();

            //get plot data of selected attribute
            Task<string> task = Task.Run(async () => await GetPIDataAsync(URL, credentials));
            task.Wait();
            string content = task.Result;
            AFAttributeRecordedValues.RootObject attributevaluelist = JsonConvert.DeserializeObject<AFAttributeRecordedValues.RootObject>(content);


            ViewBag.attribWebID = attribWebID;
            ViewBag.attribName = attribName;

            return View(attributevaluelist);
        }

        [HttpPost]
        public IActionResult ViewAttribData()
        {
            //form entries
            var startTime = Request.Form["startTime"];
            var endTime = Request.Form["endTime"];
            var attribWebID = Request.Form["AttribWebID"];
            var attribName = Request.Form["AttribName"];

            //get plot data for entered data
            string URL = "https://develop2/piwebapi/streams/" + attribWebID + "/plot?startTime=" + startTime + "&endTime=" + endTime;

            // not using kerberos authentication
             NetworkCredential credentials = GetNetworkCredentials();

            //get plot data of selected attribute for the time range entered.
            Task<string> task = Task.Run(async () => await GetPIDataAsync(URL, credentials));
            task.Wait();
            string content = task.Result;
            AFAttributeRecordedValues.RootObject attributevaluelist = JsonConvert.DeserializeObject<AFAttributeRecordedValues.RootObject>(content);

            ViewBag.attribWebID = attribWebID;
            ViewBag.attribName = attribName;

            return View(attributevaluelist);
        }

        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTag(int? temp)
        {
            //form entries
            string tagName = Request.Form["tagName"];
            string tagValue = Request.Form["tagValue"];
            string descValue = Request.Form["desValue"];

            //batch controller
            string URL = "https://develop2/piwebapi/batch";

            //batch request string to create a tag, get its info(webID) and update its value and change its point description
            string jsonContent = @"{""CreateTag"" :{""Method"":""POST"",""Resource"":""https://develop2/piwebapi/dataservers/F1DSUg9RgGAqQUap9GVsKYIDXwREVWRUxPUDI/points"",""Content"": ""{'Name' : '" + tagName + @"','PointClass': 'classic','PointType': 'Float32','Future': false}'}""},";
            jsonContent = jsonContent + @"""GetTagInfo"":{""Method"":""GET"",""ParentIDs"":[""CreateTag""],""Parameters"":[""$.CreateTag.Headers.Location""],""Resource"":""{0}""},";
            jsonContent = jsonContent + @"""UpdateTagValue"":{""Method"":""POST"",""ParentIDs"":[""GetTagInfo""],""Parameters"":[""$.GetTagInfo.Content.WebId""],""Resource"": ""https://develop2/piwebapi/streams/{0}/value"", ""Content"": ""{ 'Timestamp': '*','Good': true, 'Questionable': false, 'Value': " + tagValue + @"}""},";
            jsonContent = jsonContent + @"""UpdateTagDescription"":{""Method"":""PATCH"",""ParentIDs"":[""GetTagInfo""],""Parameters"":[""$.GetTagInfo.Content.WebId""],""Resource"": ""https://develop2/piwebapi/points/{0}"", ""Content"": ""{ 'Descriptor': '" + descValue + @"'}""}}";

            // not using kerberos authentication
            NetworkCredential credentials = GetNetworkCredentials();

            //post content to run batch commands
            Task<string> task = Task.Run(async () => await PostPIDataAsync(URL, credentials,jsonContent));
            task.Wait();

            return View();
        }

        public static async Task<string> GetPIDataAsync(string url, NetworkCredential credentials)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();

            //ignores SSL errors, we're using a self signed cert in dev.
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.Credentials = credentials;

            HttpClient _client = new HttpClient(clientHandler);


            string content = "";
            try
            {

                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message + ". Inner exception: " + ex.InnerException.Message);
            }

            return content;
        }

        public static async Task<string> PostPIDataAsync(string url, NetworkCredential credentials, string jsonContent)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();

            //ignores SSL errors, we're using a self signed cert in dev.
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            clientHandler.Credentials = credentials;

            HttpClient _client = new HttpClient(clientHandler);

            string content = "";
            try
            {

                var response = await _client.PostAsync(url,new StringContent(jsonContent, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message + ". Inner exception: " + ex.InnerException.Message);
            }

            return content;
        }

        public NetworkCredential GetNetworkCredentials()
        {

            NetworkCredential credentials = new NetworkCredential();

            credentials.UserName = "USERNAME";
            credentials.Password = "PASSWORD";

            return credentials;

        }



    }
}
