using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;

namespace BlazorApp.Api
{
    public class ApiCommon
    {
        public static string URL_SERVER_SITE_MANAGER = "http://site-manager.minhan-tran.fr";
        //public static string URL_SERVER_SITE_MANAGER_2 = "https://sitemanager.hjb0crb4bmcuawhh.northeurope.azurecontainer.io";
        public static string URL_DEV = "https://localhost:7132";
        public const bool USE_LOCAL_SERVER = false;

        private static HttpClient _httpClient;

        //public static List<LogInfoItemDto> GetLogs(string sMethod, string accType, string accHolder, string symbol = null)
        //{
        //    List<LogInfoItemDto> listSymbol = new List<LogInfoItemDto>();

        //    string sUrl = $"{ClsCommon.URL_SERVER}/Server/{sMethod}?accType={accType}&accHolder={accHolder}";

        //    if (!string.IsNullOrEmpty(symbol))
        //        sUrl += $"&symbol={symbol}";

        //    listSymbol = ExecuteHttpGet<List<LogInfoItemDto>>(sUrl);

        //    return listSymbol;
        //}

        public static string GetUrlServer()
        {
            if (USE_LOCAL_SERVER)
                return URL_DEV.EndsWith("/") ? URL_DEV.TrimEnd('/') : URL_DEV;
            else
                return URL_SERVER_SITE_MANAGER.EndsWith("/") ? URL_SERVER_SITE_MANAGER.TrimEnd('/') : URL_SERVER_SITE_MANAGER;
        }

        #region Http

        private static HttpClient GetHttpClient(string accessToken = null)
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();

                _httpClient.Timeout = TimeSpan.FromSeconds(5);
            }

            _httpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(accessToken))
                _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            return _httpClient;
        }

        public static string ExecuteHttpGet(string sUrl)
        {
            var nbr = 0;
            var result = string.Empty;

            try
            {
                do
                {
                    try
                    {
                        var res = GetHttpClient().GetAsync(sUrl).Result;

                        res.EnsureSuccessStatusCode();

                        nbr = 11;

                        result = res.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception e)
                    {
                        if (nbr >= 10)
                            throw;
                    }

                    Thread.Sleep(1000);

                    nbr++;
                }
                while (nbr < 10);
            }
            catch
            {
                //var res = GetHttpClient().GetAsync("https://black-bay-0e87ebf03.1.azurestaticapps.net/").Result; 
            }

            return result;
        }

        public static T ExecuteHttpGet<T>(string sUrl)
        {
            var nbr = 0;
            T result = default(T);

            try
            {
                do
                {
                    try
                    {
                        var res = GetHttpClient().GetAsync(sUrl).Result;

                        res.EnsureSuccessStatusCode();

                        nbr = 11;

                        result = res.Content.ReadFromJsonAsync<T>().Result;
                    }
                    catch (Exception e)
                    {
                        if (nbr >= 10)
                            throw;
                    }

                    Thread.Sleep(1000);

                    nbr++;
                }
                while (nbr < 10);
            }
            catch
            {
                /*var res = GetHttpClient().GetAsync("https://black-bay-0e87ebf03.1.azurestaticapps.net/").Result;*/
            }

            return result;
        }

        public static T ExecuteHttpPost<T>(string sUrl, object oObject, string accessToken = null)
        {
            var nbr = 0;
            T result = default(T);

            try
            {
                do
                {
                    try
                    {
                        var httpClient = GetHttpClient(accessToken);

                        var res = httpClient.PostAsync(sUrl, new StringContent(Serialize(oObject), Encoding.UTF8, "application/json")).Result;

                        res.EnsureSuccessStatusCode();

                        nbr = 11;

                        var resultString = res.Content.ReadAsStringAsync().Result;

                        if (!string.IsNullOrEmpty(resultString))
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(resultString);
                    }
                    catch (Exception e)
                    {
                        if (nbr >= 10)
                            throw;
                    }

                    Thread.Sleep(1000);

                    nbr++;
                }
                while (nbr < 10);
            }
            catch
            {
                //var res = GetHttpClient().GetAsync("https://black-bay-0e87ebf03.1.azurestaticapps.net/").Result; 
            }

            return result;
        }

        public static string ExecuteHttpPost(string sUrl, object oObject, string accessToken = null)
        {
            var nbr = 0;
            string result = string.Empty;

            try
            {
                do
                {
                    try
                    {
                        var httpClient = GetHttpClient(accessToken);

                        var res = httpClient.PostAsync(sUrl, new StringContent(Serialize(oObject), Encoding.UTF8, "application/json")).Result;

                        res.EnsureSuccessStatusCode();

                        nbr = 11;

                        result = res.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception e)
                    {
                        if (nbr >= 10)
                            throw;
                    }

                    Thread.Sleep(1000);

                    nbr++;
                }
                while (nbr < 10);
            }
            catch
            {
                //var res = GetHttpClient().GetAsync("https://black-bay-0e87ebf03.1.azurestaticapps.net/").Result; 
            }

            return result;
        }

        public static string Serialize(object oObject, bool ignoreNullOrDefault = true)
        {
            if (ignoreNullOrDefault)
                return Newtonsoft.Json.JsonConvert.SerializeObject(oObject, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            else
                return Newtonsoft.Json.JsonConvert.SerializeObject(oObject);
        }

        #endregion Http

    }
}
