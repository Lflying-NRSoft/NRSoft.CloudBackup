using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace NRSoft.CloudBackup.Blazor.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public SignOutSessionStateManager SignOutManager { get; set; }

        private async Task NavigateToAsync(string uri, string target = null)
        {
            if (target == "_blank")
            {
                await JsRuntime.InvokeVoidAsync("open", uri, target);
            }
            else
            {
                Navigation.NavigateTo(uri);
            }
        }

        private async Task BeginSignOut()
        {
            await SignOutManager.SetSignOutState();
            await NavigateToAsync("authentication/logout");
        }
    }
}
