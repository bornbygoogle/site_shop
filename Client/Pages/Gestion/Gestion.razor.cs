using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BlazorApp.Client.Pages.Gestion
{
    public partial class Gestion
    {
        private bool ShowErrors;
        private string Error = "";

        private ClaimsPrincipal _user;

        private SwanShop dataSwanShop { get; set; } = new SwanShop();

        private string _indexPageTitle = string.Empty;
        private string _shopName = string.Empty;
        private string _shopAddress = string.Empty;
        private string _shopTelephone = string.Empty;
        private string _shopMail = string.Empty;

        private string _shopLinkFacebook = string.Empty;
        private string _shopLinkInstagram = string.Empty;
        private string _shopLinkTwitter = string.Empty;
        private string _shopLinkLinkedIn = string.Empty;

        private string _aboutPageTitle = string.Empty;
        private string _aboutSummary = string.Empty;
        private string _aboutServiceSummary = string.Empty;
        private string _aboutBrandsSummary = string.Empty;

        private string _contactPageTitle = string.Empty;
        private string _shopPageTitle = string.Empty;
        private string _shopItemPageTitle = string.Empty;

        private string _carouselStyle = string.Empty;
        private bool _carouselShowArrows = false;
        private bool _carouselShowBullets = false;
        private bool _carouselEnableSwipeGesture = false;
        private bool _carouselAutoCycle = false;

        //protected override async Task OnInitializedAsync()
        //{
        //    var authState = await ((ApiAuthenticationStateProvider)authenticationStateProvider).GetAuthenticationStateAsync();
        //    _user = authState.User;

        //    var refreshToken = await localStorage.GetItemAsync<string>($"refreshToken");

        //    //Si non, redirect user to login
        //    if ((_user == null || _user.Identity == null) && refreshToken == null)
        //        NavigationManager.NavigateTo("/login");
        //    else if (_user != null && _user.Identity != null)
        //    {
        //        //if (_user.Identity.IsAuthenticated)
        //        //{
        //        //    dataSwanShop = await Http.GetFromJsonAsync<SwanShop>($"/api/GetData");

        //        //    if (dataSwanShop != null && dataSwanShop.Configs != null && dataSwanShop.Configs.Count > 0)
        //        //    {
        //        //        var routeConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route));
        //        //        if (routeConfigs.Count() > 0)
        //        //        {
        //        //            foreach (var item in routeConfigs)
        //        //            {
        //        //                if (item != null)
        //        //                {
        //        //                    switch (item.Route)
        //        //                    {
        //        //                        case "Shop":

        //        //                            if (item.Properties != null && item.Properties.Count() > 0)
        //        //                            {
        //        //                                var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //        //                                if (configPageTitle != null)
        //        //                                    _shopPageTitle = configPageTitle.Value;
        //        //                            }

        //        //                            break;
        //        //                        case "ShopItem":

        //        //                            if (item.Properties != null && item.Properties.Count() > 0)
        //        //                            {
        //        //                                var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //        //                                if (configPageTitle != null)
        //        //                                    _shopItemPageTitle = configPageTitle.Value;
        //        //                            }

        //        //                            break;
        //        //                        case "Contact":

        //        //                            if (item.Properties != null && item.Properties.Count() > 0)
        //        //                            {
        //        //                                var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //        //                                if (configPageTitle != null)
        //        //                                    _contactPageTitle = configPageTitle.Value;
        //        //                            }

        //        //                            break;
        //        //                        case "About":

        //        //                            if (item.Properties != null && item.Properties.Count() > 0)
        //        //                            {
        //        //                                var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //        //                                if (configPageTitle != null)
        //        //                                    _aboutPageTitle = configPageTitle.Value;

        //        //                                var configSummary = item.Properties.Where(x => x.Name == "Summary").FirstOrDefault();
        //        //                                if (configSummary != null)
        //        //                                    _aboutSummary = configSummary.Value;
        //        //                            }

        //        //                            if (item.SpecificIdProperties != null && item.SpecificIdProperties.Count() > 0)
        //        //                            {
        //        //                                var configServiceSummary = item.SpecificIdProperties.Where(x => x.Id == "summary-service").FirstOrDefault();
        //        //                                if (configServiceSummary != null && configServiceSummary.Properties != null && configServiceSummary.Properties.Count() > 0)
        //        //                                {
        //        //                                    _aboutServiceSummary = ClsCommon.GetPropertyValue(configServiceSummary.Properties, "Summary");
        //        //                                }

        //        //                                var configBrandsSummary = item.SpecificIdProperties.Where(x => x.Id == "summary-brands").FirstOrDefault();
        //        //                                if (configBrandsSummary != null && configBrandsSummary.Properties != null && configBrandsSummary.Properties.Count() > 0)
        //        //                                {
        //        //                                    _aboutBrandsSummary = ClsCommon.GetPropertyValue(configBrandsSummary.Properties, "Summary");
        //        //                                }
        //        //                            }

        //        //                            break;
        //        //                        default:

        //        //                            if (item.Properties != null && item.Properties.Count() > 0)
        //        //                            {
        //        //                                var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //        //                                if (configPageTitle != null)
        //        //                                    _indexPageTitle = configPageTitle.Value;

        //        //                                var configShopName = item.Properties.Where(x => x.Name == "ShopName").FirstOrDefault();
        //        //                                if (configShopName != null)
        //        //                                    _shopName = configShopName.Value;

        //        //                                var configShopAddress = item.Properties.Where(x => x.Name == "ShopAddress").FirstOrDefault();
        //        //                                if (configShopAddress != null)
        //        //                                    _shopAddress = configShopAddress.Value;

        //        //                                var configShopTel = item.Properties.Where(x => x.Name == "ShopTel").FirstOrDefault();
        //        //                                if (configShopTel != null)
        //        //                                    _shopTelephone = configShopTel.Value;

        //        //                                var configShopMail = item.Properties.Where(x => x.Name == "ShopMail").FirstOrDefault();
        //        //                                if (configShopMail != null)
        //        //                                    _shopMail = configShopMail.Value;

        //        //                                var configShopLinkFacebook = item.Properties.Where(x => x.Name == "ShopLinkFB").FirstOrDefault();
        //        //                                if (configShopLinkFacebook != null)
        //        //                                    _shopLinkFacebook = configShopLinkFacebook.Value;

        //        //                                var configShopLinkInstagram = item.Properties.Where(x => x.Name == "ShopLinkIG").FirstOrDefault();
        //        //                                if (configShopLinkInstagram != null)
        //        //                                    _shopLinkInstagram = configShopLinkInstagram.Value;

        //        //                                var configShopLinkTwitter = item.Properties.Where(x => x.Name == "ShopLinkTW").FirstOrDefault();
        //        //                                if (configShopLinkTwitter != null)
        //        //                                    _shopLinkTwitter = configShopLinkTwitter.Value;

        //        //                                var configShopLinkLinkedIn = item.Properties.Where(x => x.Name == "ShopLinkLI").FirstOrDefault();
        //        //                                if (configShopLinkLinkedIn != null)
        //        //                                    _shopLinkLinkedIn = configShopLinkLinkedIn.Value;
        //        //                            }

        //        //                            if (item.SpecificIdProperties != null && item.SpecificIdProperties.Count() > 0)
        //        //                            {
        //        //                                var configCarousel = item.SpecificIdProperties.Where(x => x.Id == ClsCommon.IndexCarouselId).FirstOrDefault();
        //        //                                if (configCarousel != null && configCarousel.Properties != null && configCarousel.Properties.Count() > 0)
        //        //                                {
        //        //                                    _carouselStyle = ClsCommon.GetPropertyValue(configCarousel.Properties, "Style");

        //        //                                    _carouselShowArrows = ClsCommon.GetPropertyValue(configCarousel.Properties, "ShowArrows") == "1";
        //        //                                    _carouselShowBullets = ClsCommon.GetPropertyValue(configCarousel.Properties, "ShowBullets") == "1";
        //        //                                    _carouselEnableSwipeGesture = ClsCommon.GetPropertyValue(configCarousel.Properties, "EnableSwipeGesture") == "1";
        //        //                                    _carouselAutoCycle = ClsCommon.GetPropertyValue(configCarousel.Properties, "ShoAutoCyclewBullets") == "1";
        //        //                                }
        //        //                            }

        //        //                            break;

        //        //                    }
        //        //                }
        //        //            }
        //        //        }
        //        //    }
        //        //}
        //        //else if (!_user.Identity.IsAuthenticated)
        //        //{
        //        //    if (!string.IsNullOrEmpty(refreshToken))
        //        //    {
        //        //        var claims = ClsCommon.ParseClaimsFromJwt(refreshToken);
        //        //        var valueName = claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
        //        //        var userNameRefreshToken = valueName != null ? valueName.Value : string.Empty;

        //        //        var result = await Http.GetStringAsync($"/api/RefreshToken?userName={userNameRefreshToken}&refreshToken={refreshToken}");

        //        //        if (result.StartsWith("ERR|"))
        //        //        {
        //        //            //Erreur refresh automatique, redirect user to login
        //        //            NavigationManager.NavigateTo("/login");
        //        //        }
        //        //        else
        //        //        {
        //        //            var res = result.Split("||REF||");
        //        //            if (res != null && res.Count() == 2)
        //        //            {
        //        //                await localStorage.SetItemAsync($"accessToken", res[0]);
        //        //                await localStorage.SetItemAsync($"refreshToken", res[1]);

        //        //                ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(userNameRefreshToken);
        //        //            }
        //        //        }
        //        //    }
        //        //    else
        //        //        NavigationManager.NavigateTo("/login");
        //        //}
        //    }
        //}

        //private async void LogOut()
        //{
        //    var authState = await ((ApiAuthenticationStateProvider)authenticationStateProvider).GetAuthenticationStateAsync();
        //    var user = authState.User;

        //    var result = await Http.GetStringAsync($"/api/Logout?userName={user.Identity?.Name}");

        //    ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();

        //    await localStorage.RemoveItemAsync($"accessToken");
        //    await localStorage.RemoveItemAsync($"refreshToken");

        //    NavigationManager.NavigateTo("/");
        //}

        //private async Task HandleGeneral()
        //{
        //    //Message = "Updating general information ...";

        //    var accessToken = await localStorage.GetItemAsync<string>("accessToken");
        //    //if (!string.IsNullOrEmpty(accessToken))
        //    //{
        //    //    if (!string.IsNullOrEmpty(_indexPageTitle))
        //    //    {
        //    //        var indexConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "Index");
        //    //        if (indexConfigs.Count() > 0)
        //    //        {
        //    //            foreach (var item in indexConfigs)
        //    //            {
        //    //                if (item.Properties != null)
        //    //                {
        //    //                    var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //    //                    if (configPageTitle != null && configPageTitle.Value != _indexPageTitle)
        //    //                    {
        //    //                        configPageTitle.HasChange = "1";
        //    //                        configPageTitle.Value = _indexPageTitle;
        //    //                    }

        //    //                    var configShopName = item.Properties.Where(x => x.Name == "ShopName").FirstOrDefault();
        //    //                    if (configShopName != null && configShopName.Value != _shopName)
        //    //                    {
        //    //                        configShopName.HasChange = "1";
        //    //                        configShopName.Value = _shopName;
        //    //                    }

        //    //                    var configShopAddress = item.Properties.Where(x => x.Name == "ShopAddress").FirstOrDefault();
        //    //                    if (configShopAddress != null && configShopAddress.Value != _shopAddress)
        //    //                    {
        //    //                        configShopAddress.HasChange = "1";
        //    //                        configShopAddress.Value = _shopAddress;
        //    //                    }

        //    //                    var configShopTel = item.Properties.Where(x => x.Name == "ShopTel").FirstOrDefault();
        //    //                    if (configShopTel != null && configShopTel.Value != _shopTelephone)
        //    //                    {
        //    //                        configShopTel.HasChange = "1";
        //    //                        configShopTel.Value = _shopTelephone;
        //    //                    }

        //    //                    var configShopMail = item.Properties.Where(x => x.Name == "ShopMail").FirstOrDefault();
        //    //                    if (configShopMail != null && configShopMail.Value != _shopMail)
        //    //                    {
        //    //                        configShopMail.HasChange = "1";
        //    //                        configShopMail.Value = _shopMail;
        //    //                    }

        //    //                    var configShopLinkFacebook = item.Properties.Where(x => x.Name == "ShopLinkFB").FirstOrDefault();
        //    //                    if (configShopLinkFacebook != null && configShopLinkFacebook.Value != _shopLinkFacebook)
        //    //                    {
        //    //                        configShopLinkFacebook.HasChange = "1";
        //    //                        configShopLinkFacebook.Value = _shopLinkFacebook;
        //    //                    }

        //    //                    var configShopLinkInstagram = item.Properties.Where(x => x.Name == "ShopLinkIG").FirstOrDefault();
        //    //                    if (configShopLinkInstagram != null && configShopLinkInstagram.Value != _shopLinkInstagram)
        //    //                    {
        //    //                        configShopLinkInstagram.HasChange = "1";
        //    //                        configShopLinkInstagram.Value = _shopLinkInstagram;
        //    //                    }

        //    //                    var configShopLinkTwitter = item.Properties.Where(x => x.Name == "ShopLinkTW").FirstOrDefault();
        //    //                    if (configShopLinkTwitter != null && configShopLinkTwitter.Value != _shopLinkTwitter)
        //    //                    {
        //    //                        configShopLinkTwitter.HasChange = "1";
        //    //                        configShopLinkTwitter.Value = _shopLinkTwitter;
        //    //                    }

        //    //                    var configShopLinkLinkedIn = item.Properties.Where(x => x.Name == "ShopLinkLI").FirstOrDefault();
        //    //                    if (configShopLinkLinkedIn != null && configShopLinkLinkedIn.Value != _shopLinkLinkedIn)
        //    //                    {
        //    //                        configShopLinkLinkedIn.HasChange = "1";
        //    //                        configShopLinkLinkedIn.Value = _shopLinkLinkedIn;
        //    //                    }
        //    //                }

        //    //                if (item.SpecificIdProperties != null)
        //    //                {
        //    //                    var configCarousel = item.SpecificIdProperties.Where(x => x.Id == ClsCommon.IndexCarouselId).FirstOrDefault();
        //    //                    if (configCarousel != null && configCarousel.Properties != null && configCarousel.Properties.Count() > 0)
        //    //                    {
        //    //                        var configCarouselStyle = configCarousel.Properties.Where(x => x.Name == "Style").FirstOrDefault();
        //    //                        if (configCarouselStyle != null && configCarouselStyle.Value != _carouselStyle)
        //    //                        {
        //    //                            configCarouselStyle.HasChange = "1";
        //    //                            configCarouselStyle.Value = _carouselStyle;
        //    //                        }

        //    //                        var configCarouselShowArrows = configCarousel.Properties.Where(x => x.Name == "ShowArrows").FirstOrDefault();
        //    //                        if (configCarouselShowArrows != null)
        //    //                        {
        //    //                            var tmpValue = _carouselShowArrows ? "1" : "0";

        //    //                            if (configCarouselShowArrows.Value != tmpValue)
        //    //                            {
        //    //                                configCarouselShowArrows.HasChange = "1";
        //    //                                configCarouselShowArrows.Value = tmpValue;
        //    //                            }
        //    //                        }

        //    //                        var configCarouselShowBullets = configCarousel.Properties.Where(x => x.Name == "ShowBullets").FirstOrDefault();
        //    //                        if (configCarouselShowBullets != null)
        //    //                        {
        //    //                            var tmpValue = _carouselShowBullets ? "1" : "0";

        //    //                            if (configCarouselShowBullets.Value != tmpValue)
        //    //                            {
        //    //                                configCarouselShowBullets.HasChange = "1";
        //    //                                configCarouselShowBullets.Value = tmpValue;
        //    //                            }
        //    //                        }

        //    //                        var configCarouselEnableSwipeGesture = configCarousel.Properties.Where(x => x.Name == "EnableSwipeGesture").FirstOrDefault();
        //    //                        if (configCarouselEnableSwipeGesture != null)
        //    //                        {
        //    //                            var tmpValue = _carouselEnableSwipeGesture ? "1" : "0";

        //    //                            if (configCarouselEnableSwipeGesture.Value != tmpValue)
        //    //                            {
        //    //                                configCarouselEnableSwipeGesture.HasChange = "1";
        //    //                                configCarouselEnableSwipeGesture.Value = tmpValue;
        //    //                            }
        //    //                        }

        //    //                        var configCarouselAutoCycle = configCarousel.Properties.Where(x => x.Name == "AutoCycle").FirstOrDefault();
        //    //                        if (configCarouselAutoCycle != null)
        //    //                        {
        //    //                            var tmpValue = _carouselAutoCycle ? "1" : "0";

        //    //                            if (configCarouselAutoCycle.Value != tmpValue)
        //    //                            {
        //    //                                configCarouselAutoCycle.HasChange = "1";
        //    //                                configCarouselAutoCycle.Value = tmpValue;
        //    //                            }
        //    //                        }
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }

        //    //    if (!string.IsNullOrEmpty(_aboutPageTitle))
        //    //    {
        //    //        var aboutConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "About");
        //    //        if (aboutConfigs.Count() > 0)
        //    //        {
        //    //            foreach (var item in aboutConfigs)
        //    //            {
        //    //                if (item.Properties != null)
        //    //                {
        //    //                    var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //    //                    if (configPageTitle != null && configPageTitle.Value != _aboutPageTitle)
        //    //                    {
        //    //                        configPageTitle.HasChange = "1";
        //    //                        configPageTitle.Value = _aboutPageTitle;
        //    //                    }

        //    //                    var configSummary = item.Properties.Where(x => x.Name == "Summary").FirstOrDefault();
        //    //                    if (configSummary != null && configSummary.Value != _aboutSummary)
        //    //                    {
        //    //                        configSummary.HasChange = "1";
        //    //                        configSummary.Value = _aboutSummary;
        //    //                    }
        //    //                }

        //    //                if (item.SpecificIdProperties != null)
        //    //                {
        //    //                    var configSummaryService = item.SpecificIdProperties.Where(x => x.Id == "summary-service").FirstOrDefault();
        //    //                    if (configSummaryService != null && configSummaryService.Properties != null && configSummaryService.Properties.Count() > 0)
        //    //                    {
        //    //                        var configServiceSummary = configSummaryService.Properties.Where(x => x.Name == "Summary").FirstOrDefault();
        //    //                        if (configServiceSummary != null && configServiceSummary.Value != _aboutServiceSummary)
        //    //                        {
        //    //                            configServiceSummary.HasChange = "1";
        //    //                            configServiceSummary.Value = _aboutServiceSummary;
        //    //                        }
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }

        //    //    if (!string.IsNullOrEmpty(_contactPageTitle))
        //    //    {
        //    //        var contactConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "Contact");
        //    //        if (contactConfigs.Count() > 0)
        //    //        {
        //    //            foreach (var item in contactConfigs)
        //    //            {
        //    //                if (item.Properties != null)
        //    //                {
        //    //                    var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //    //                    if (configPageTitle != null && configPageTitle.Value != _contactPageTitle)
        //    //                    {
        //    //                        configPageTitle.HasChange = "1";
        //    //                        configPageTitle.Value = _contactPageTitle;
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }

        //    //    if (!string.IsNullOrEmpty(_shopPageTitle))
        //    //    {
        //    //        var shopConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "Shop");
        //    //        if (shopConfigs.Count() > 0)
        //    //        {
        //    //            foreach (var item in shopConfigs)
        //    //            {
        //    //                if (item.Properties != null)
        //    //                {
        //    //                    var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //    //                    if (configPageTitle != null && configPageTitle.Value != _shopPageTitle)
        //    //                    {
        //    //                        configPageTitle.HasChange = "1";
        //    //                        configPageTitle.Value = _shopPageTitle;
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }

        //    //    if (!string.IsNullOrEmpty(_shopItemPageTitle))
        //    //    {
        //    //        var shopSingleConfigs = dataSwanShop.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "ShopItem");
        //    //        if (shopSingleConfigs.Count() > 0)
        //    //        {
        //    //            foreach (var item in shopSingleConfigs)
        //    //            {
        //    //                if (item.Properties != null)
        //    //                {
        //    //                    var configPageTitle = item.Properties.Where(x => x.Name == nameof(PageTitle)).FirstOrDefault();
        //    //                    if (configPageTitle != null && configPageTitle.Value != _shopItemPageTitle)
        //    //                    {
        //    //                        configPageTitle.HasChange = "1";
        //    //                        configPageTitle.Value = _shopItemPageTitle;
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }

        //    //    try
        //    //    {
        //    //        var result = await Http.PostAsJsonAsync<SwanShop>($"/api/UpdateData?accessToken={accessToken}", dataSwanShop);
        //    //        result.EnsureSuccessStatusCode();

        //    //        var contentResult = result.Content.ReadAsStringAsync().Result;
        //    //        if (contentResult.Contains("Data updated"))
        //    //            NavigationManager.NavigateTo("/gestion");
        //    //    }
        //    //    catch (Exception e) { var test = e.Message; }

        //    //}

        //    //var result = JsonSerializer.Deserialize<BaseResult>(await resultMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    //Message = result.Successful ? "General information updated" : result.Error;
        //}

        //private void AddEmptyCategorie()
        //{
        //    if (dataSwanShop != null)
        //    {
        //        if (dataSwanShop.Categories == null)
        //            dataSwanShop.Categories = new List<SwanShopCategorie>();

        //        dataSwanShop.Categories.Add(new SwanShopCategorie() { HasChange = "1" });
        //    }
        //}

        //private void AddEmptySubCategorie(long? categorieId)
        //{
        //    if (dataSwanShop != null)
        //    {
        //        if (dataSwanShop.SubCategories == null)
        //            dataSwanShop.SubCategories = new List<SwanShopSubCategorie>();

        //        dataSwanShop.SubCategories.Add(new SwanShopSubCategorie() { HasChange = "1" });
        //    }
        //}

        //private void AddEmptyArticle()
        //{
        //    if (dataSwanShop != null)
        //    {
        //        if (dataSwanShop.Articles == null)
        //            dataSwanShop.Articles = new List<SwanShopArticle>();

        //        dataSwanShop.Articles.Add(new SwanShopArticle() { HasChange = "1" });
        //    }
        //}

        //private void AddEmptyData()
        //{
        //    if (dataSwanShop != null)
        //    {
        //        if (dataSwanShop.Datas == null)
        //            dataSwanShop.Datas = new List<SwanShopImages>();

        //        dataSwanShop.Datas.Add(new SwanShopImages() { HasChange = "1" });
        //    }
        //}

        //private async Task UploadFile(InputFileChangeEventArgs e, SwanShopImages item)
        //{
        //    var currentFile = e.File;

        //    //if (currentFile != null)
        //    //{
        //    //    var buffer = new byte[currentFile.Size];

        //    //    var length = await currentFile.OpenReadStream(1024 * 1024 * 15).ReadAsync(buffer);

        //    //    if (length > 0 && item != null)
        //    //    {
        //    //        item.ImageBlob = buffer;
        //    //        item.ImageUrl = "Updating !";

        //    //        item.HasChange = "1";

        //    //        StateHasChanged();
        //    //    }
        //    //}
        //}

        //private void ItemHasChanged(BaseDto item)
        //{
        //    if (item != null)
        //        item.HasChange = "1";
        //}
    }
}
