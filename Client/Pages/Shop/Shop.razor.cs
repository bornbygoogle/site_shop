using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace BlazorApp.Client.Pages.Shop
{
    public partial class Shop
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

        public async void OpenOrder(long itemId)
        {
            NavigationManager.NavigateTo($"/shop-item-page/{itemId}");
            //await DialogService.OpenAsync<ShopItemPage>(string.Empty,
            //    new Dictionary<string, object>() { { "OrderID", 1 } },
            //    new DialogOptions() { Width = "900px", Height = "512px", Resizable = true, Draggable = true });
        }
    }
}
