using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorApp.Api.Function
{
    public static class GetDataFunction
    {
        [FunctionName("GetData")]
        public static IActionResult GetData([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var sUrl = $"{ApiCommon.GetUrlServer()}/SwanShop/GetDataSwanShop";

            var bResponse = ApiCommon.ExecuteHttpGetByteArray(sUrl);
            
            SwanShop shopData = null;

            if (bResponse != null && bResponse.Length > 0 && ClsUtil.ByteArrayToStringUnzipIfNedeed(bResponse, System.Text.Encoding.UTF8, out string response, out string msgErr) && !string.IsNullOrEmpty(response) && string.IsNullOrEmpty(msgErr))
                 shopData = JsonConvert.DeserializeObject<SwanShop>(response);

            if (shopData != null)
                return new OkObjectResult(shopData);
            else
                return new BadRequestObjectResult(string.Empty);
        }
    }
}
