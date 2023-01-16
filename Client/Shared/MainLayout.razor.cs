using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System.Net.Http.Json;

namespace BlazorApp.Client.Shared
{
    public partial class MainLayout
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

        [Inject]
        protected HttpClient Http { get; set; }

        private string collapsed = string.Empty;

        private string _currentLogo = @"https://res.cloudinary.com/dob8evuxv/image/upload/v1673762273/logo_j7rfup.png";
        private string _shopName = "SwanShop";
        private string _copyRightDate = $"SwanShop ©2020";

        private SwanShop? Data { get; set; }

        void SidebarToggleClick()
        {
            if (!String.IsNullOrEmpty(collapsed))
                collapsed = string.Empty;
            else
                collapsed = "collapse";
        }

        protected override async Task OnInitializedAsync()
        {
            _copyRightDate = $"©{DateTime.Now.Year.ToString()} by {_shopName}";

            Data = await Http.GetFromJsonAsync<SwanShop>($"/api/GetData");

            if (Data != null && Data.Configs != null && Data.Images != null)
            {
                var tmpLogoId = Data.Configs.Where(x => x.PropertyName == "Logo").FirstOrDefault();

                if (tmpLogoId != null && tmpLogoId.Id.HasValue)
                    _currentLogo = Data.Images.Where(x => x.ConfigId == tmpLogoId.Id.Value).FirstOrDefault().ImageUrl;
            }
        }
    }
}
