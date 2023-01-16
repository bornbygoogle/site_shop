using BlazorApp.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BlazorApp.Client.Pages.Shop
{
    public partial class Index
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [CascadingParameter(Name = "DataSwanShop")]
        protected SwanShop? Data { get; set; }

        private string _pageTitle = string.Empty;

        private Random _randNum;
        private List<string> _banners;
        private List<string> products;

        private List<SwanShopArticle> _last3Articles = new List<SwanShopArticle>();
        private List<SwanShopImage> _last3ArticlesImages = new List<SwanShopImage>();

        private List<SwanShopArticle> _bestSellers3Articles = new List<SwanShopArticle>();
        private List<SwanShopImage> _bestSellers3ArticlesImages = new List<SwanShopImage>();

        private System.Threading.Timer _timerBanner;

        private string _currentImageBanner = @"https://res.cloudinary.com/dob8evuxv/image/upload/v1673197774/banner_1_ntcsoq.png";

        protected override void OnParametersSet()
        {
            if (Data != null && Data.Configs != null && Data.Configs.Count > 0)
            {
                var indexConfigs = Data.Configs.Where(x => !string.IsNullOrEmpty(x.Route) && x.Route == "Index");
                if (indexConfigs.Count() > 0)
                {
                    _pageTitle = indexConfigs.Where(x => x.PropertyName == nameof(PageTitle)).FirstOrDefault()?.PropertyValue;

                    var configIdBanner = indexConfigs.Where(x => x.PropertyName == "Banner").FirstOrDefault();
                    if (configIdBanner != null)
                    {
                        _banners.Clear();
                        _banners.AddRange(Data.Images.Where(x => x.ConfigId == configIdBanner.Id).Select(x => x.ImageUrl).ToList());
                    }
                }

                if (Data.Articles != null)
                {
                    var last3Articles = Data.Articles.OrderByDescending(x => x.Id).Take(3).ToList();
                    if (last3Articles != null)
                    {
                        _last3Articles.Clear();
                        _last3Articles.AddRange(last3Articles);

                        _last3ArticlesImages.Clear();
                        foreach (var item in last3Articles)
                        {
                            var articleImage = Data.Images.Where(x => x.ArticleId == item.Id && !string.IsNullOrEmpty(x.ImageUrl)).FirstOrDefault();
                            if (articleImage != null)
                                _last3ArticlesImages.Add(articleImage);
                        }
                    }

                    var bestSellers3Articles = Data.Articles.OrderByDescending(x => x.NbrSold).Take(3).ToList();
                    if (bestSellers3Articles != null)
                    {
                        _bestSellers3Articles.Clear();
                        _bestSellers3Articles.AddRange(bestSellers3Articles);

                        _bestSellers3ArticlesImages.Clear();
                        foreach (var item in bestSellers3Articles)
                        {
                            var articleImage = Data.Images.Where(x => x.ArticleId == item.Id && !string.IsNullOrEmpty(x.ImageUrl)).FirstOrDefault();
                            if (articleImage != null)
                                _bestSellers3ArticlesImages.Add(articleImage);
                        }
                    }
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (_randNum == null)
                _randNum = new Random();

            if (_banners == null)
                _banners = new List<string>();

            if (products == null)
                products = new List<string>();

            products.Add("test");
            products.Add("test0");
            products.Add("test1");

            if (_timerBanner == null)
                _timerBanner = new System.Threading.Timer(async _ =>  // async void
                {
                    _currentImageBanner = await GetImageBanner();
                    // we need StateHasChanged() because this is an async void handler
                    // we need to Invoke it because we could be on the wrong Thread          
                    await InvokeAsync(StateHasChanged);
                }, null, 0, 3000);
        }

        public void Dispose()
        {
            _timerBanner?.Dispose();
        }

        private async Task<string> GetImageBanner()
        {
            if (_randNum != null && _banners != null && _banners.Count > 0)
            {
                int aRandomPos = _randNum.Next(_banners.Count);//Returns a nonnegative random number less than the specified maximum

                return _banners[aRandomPos];
            }
            else
                return string.Empty;
        }
    }
}
