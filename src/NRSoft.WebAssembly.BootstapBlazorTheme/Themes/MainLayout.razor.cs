using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.UI.Navigation;

namespace NRSoft.WebAssembly.BootstapBlazorTheme.Themes
{
    public partial class MainLayout : IDisposable
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IMenuManager MenuManager { get; set; }

        [Inject]
        protected IOptions<AbpRouterOptions> RouterOptions { get; set; }

        private List<Assembly> AdditionalAssemblies { get; set; }

        private bool UseTabSet { get; set; } = true;

        [NotNull]
        private RenderFragment? NotAuthorized { get; set; }

        [Inject]
        [NotNull]
        private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

        private string Theme { get; set; } = "color1";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = false;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem> Menus { get; set; }

        public void Dispose()
        {
            //NavigationManager.LocationChanged -= OnLocationChanged;
        }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            NotAuthorized = builder =>
            {
                builder.OpenComponent<RedirectToLogin>(0);
                builder.CloseComponent();
            };
        }

        protected async override Task OnInitializedAsync()
        {
            AdditionalAssemblies = RouterOptions.Value.AdditionalAssemblies.ToList();
            AdditionalAssemblies.Add(RouterOptions.Value.AppAssembly);

            Menus = await GetIconSideMenuItemsAsync();

            //await base.OnInitializedAsync();
            // 通过当前登录名获取显示名称
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            if (state.User.Identity?.IsAuthenticated ?? false)
            {
                //UserName = state.User.Identity.Name;
                //DisplayName = UserHelper.RetrieveUserByUserName(UserName)?.DisplayName;

                // 模拟异步线程切换，正式代码中删除此行代码
                await Task.Yield();

                //// 菜单获取可以通过数据库获取，此处为示例直接拼装的菜单集合
                //TabItemTextDictionary = new()
                //{
                //    [""] = "Index"
                //};

                //// 获取登录用户菜单
                //Menus = GetMenus();
            }
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
