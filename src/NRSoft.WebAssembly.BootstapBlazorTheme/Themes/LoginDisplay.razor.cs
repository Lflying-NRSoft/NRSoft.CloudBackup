using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace NRSoft.WebAssembly.BootstapBlazorTheme.Themes
{
    public partial class LoginDisplay : IDisposable
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }

        protected ApplicationMenu Menu { get; set; }

        private IReadOnlyList<SelectedItem> UserMenus { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);
            UserMenus = Menu.Items.Select(m => new SelectedItem { Text=m.DisplayName }).ToImmutableList(); 
            Navigation.LocationChanged += OnLocationChanged;
        }

        protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            StateHasChanged();
        }
        public void Dispose()
        {
            Navigation.LocationChanged -= OnLocationChanged;
        }
    }
}
