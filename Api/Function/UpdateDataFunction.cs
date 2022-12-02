using BlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BlazorApp.Api.Function
{
    public static class UpdateDataFunction
    {
        [FunctionName("UpdateData")]
        public static IActionResult UpdateData([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] SwanShop data, HttpRequest req, ILogger log)
        {
            var sUrl = $"{ApiCommon.URL_SERVER_SITE_MANAGER}/SwanShop/UpdateData";

            var accessToken = req.Query.Where(x => x.Key == "accessToken").FirstOrDefault().Value;

            if (!string.IsNullOrEmpty(accessToken))
            {
                var response = ApiCommon.ExecuteHttpPost(sUrl, data, accessToken);
                if (response != null)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(string.Empty);
            }

            return new BadRequestObjectResult(string.Empty);
        }
    }
}
