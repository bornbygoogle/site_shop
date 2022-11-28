using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Api.Function
{
    public static class GetDataFunction
    {
        [FunctionName("GetData")]
        public static IActionResult GetData([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            var response = ApiCommon.ExecuteHttpGet<SwanShopDto>("http://sitemanager.hjb0crb4bmcuawhh.northeurope.azurecontainer.io/SwanShop/GetDataSwanShop");
            if (response != null)
                return new OkObjectResult(response);
            else
                return new BadRequestObjectResult(string.Empty);
        }
    }
}
