using BlazorApp.Shared;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace BlazorApp.Api.Function
{
    public static class UpdateDataFunction
    {
        private static bool _onWork = false;

        [FunctionName("UpdateData")]
        public static IActionResult UpdateData([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] SwanShop data, HttpRequest req, ILogger log)
        {
            string response = string.Empty;

            Account account = new Account("dob8evuxv", "983938571661586", "zBTZOB98ull4do3fjFYVWNtD-Yk");

            Cloudinary cloudinary = new Cloudinary(account);

            var sUrl = $"{ApiCommon.GetUrlServer()}/SwanShop/UpdateData";

            var accessToken = req.Query.Where(x => x.Key == "accessToken").FirstOrDefault().Value;

            if (!string.IsNullOrEmpty(accessToken))
            {
                if (data != null && data.HasDataChanged())
                {
                    //Clear all DATA blob 
                    if (data.Images != null && data.Images.Count > 0)
                    {
                        var listDataChanged = data.Images.Where(x => x.HasDataChanged()).ToList();

                        data.Images.Clear();
                        data.Images.AddRange(listDataChanged);

                        if (data.Images.Count > 0)
                        {
                            //foreach (var item in data.Datas)
                            //{
                            //    if (item.HasDataChanged())
                            //    {
                            //        if (!string.IsNullOrEmpty(item.ImageUrl))
                            //        {
                            //            var deleteImage = cloudinary.Destroy(new DeletionParams(Path.GetFileNameWithoutExtension(item.ImageUrl)));
                            //        }

                            //        if (item.ImageBlob != null && item.ImageBlob.Length > 0)
                            //        {
                            //            var currentArticle = data.Articles.Where(x => x.Id == item.ArticleId).FirstOrDefault();
                            //            if (currentArticle != null)
                            //            {
                            //                var fileName = Guid.NewGuid().ToString();

                            //                var uploadParams = new ImageUploadParams()
                            //                {
                            //                    File = new FileDescription(fileName, new MemoryStream(item.ImageBlob)),
                            //                    PublicId = fileName
                            //                };

                            //                var uploadResult = cloudinary.Upload(uploadParams);

                            //                if (uploadResult != null)
                            //                {
                            //                    item.ImageUrl = uploadResult.SecureUrl.AbsoluteUri;
                            //                    item.ImageBlob = null;
                            //                }
                            //            }
                            //        }
                            //    }
                            //    else
                            //        item.ImageBlob = null;                                   
                            //}
                        }
                        else
                            data.Images = null;
                    }

                    if (!_onWork)
                    {
                        _onWork = true;

                        response = ApiCommon.ExecuteHttpPost(sUrl, data, accessToken);

                        _onWork = false;
                    }
                }
                else
                    response = "Data updated !";
            }

            if (!string.IsNullOrEmpty(response))
                return new OkObjectResult(response);
            else
                return new BadRequestObjectResult(string.Empty);
        }
    }
}
