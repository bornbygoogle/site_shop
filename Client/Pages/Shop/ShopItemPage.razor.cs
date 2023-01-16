using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorApp.Client.Pages.Shop
{
    public partial class ShopItemPage
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

        [Parameter] public int OrderID { get; set; }

        private SwanShopArticle _currentArticle { get; set; }
        private List<SwanShopImage> _currentArticleImages = new List<SwanShopImage>();

        private long? _imagePrincipalId = null;
        private string _imagePrincipalUrl = @"\images\item-19.png";

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (Data != null && Data.Articles != null)
            {
                _currentArticle = Data.Articles.Where(x => x.Id == OrderID).FirstOrDefault();
                _currentArticleImages = Data.Images.Where(x => x.ArticleId == OrderID).ToList();
            }

            if (_currentArticleImages != null && _currentArticleImages.Count > 0)
                _imagePrincipalUrl = _currentArticleImages.First().ImageUrl;
        }

        public async void OpenPrincipalImage()
        {
            await DialogService.OpenAsync<ShopItemImageContentPage>(string.Empty,
                                                                    new Dictionary<string, object>() { { "ImageUrl", _imagePrincipalUrl } },
                                                                    new DialogOptions() { Resizable = true, Draggable = true });
        }

        private async void ChangeImagePrincipal(long? imageId)
        {
            _imagePrincipalId = imageId;

            if (imageId.HasValue)
                _imagePrincipalUrl = _currentArticleImages.Where(x => x.Id == imageId).FirstOrDefault()?.ImageUrl;
        }
    }
}
