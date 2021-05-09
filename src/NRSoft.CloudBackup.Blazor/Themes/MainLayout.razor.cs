using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace NRSoft.CloudBackup.Blazor.Themes
{
    public partial class MainLayout : IDisposable
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IMenuManager MenuManager { get; set; }

        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "color1";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem> Menus { get; set; }

        public void Dispose()
        {
            //NavigationManager.LocationChanged -= OnLocationChanged;
        }

        protected async override Task OnInitializedAsync()
        {
            Menus = await GetIconSideMenuItemsAsync();
        }

        private async Task<List<MenuItem>> GetIconSideMenuItemsAsync()
        {
            var rootMenu = await MenuManager.GetAsync(StandardMenus.Main);
            if (rootMenu != null)
            {
                //var elementId = MenuItem.ElementId ?? "MenuItem_" + MenuItem.Name.Replace(".", "_");
                //var cssClass = string.IsNullOrEmpty(MenuItem.CssClass) ? string.Empty : MenuItem.CssClass;
                //var disabled = MenuItem.IsDisabled ? "disabled" : string.Empty;
                //var url = MenuItem.Url == null ? "#" : MenuItem.Url.TrimStart('/');

                return rootMenu.Items.Select(m => new MenuItem
                {
                    Text = m.DisplayName,
                    Icon = m.Icon,
                    Url = m.Url == null ? "#" : m.Url.TrimStart('/')
                }).ToList();
            }

            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "返回组件库", Icon = "fa fa-fw fa-home", Url = "https://www.blazor.zone/components" },
                new MenuItem() { Text = "Index", Icon = "fa fa-fw fa-fa", Url = "" },
                new MenuItem() { Text = "Counter", Icon = "fa fa-fw fa-check-square-o", Url = "counter" },
                new MenuItem() { Text = "FetchData", Icon = "fa fa-fw fa-database", Url = "fetchdata" },
                new MenuItem() { Text = "Table", Icon = "fa fa-fw fa-table", Url = "table" },
                new MenuItem() { Text = "待办列表", Icon = "fa fa-fw fa-drivers-license-o", Url = "todolist" }
            };

            return menus;
        }
    }
}
