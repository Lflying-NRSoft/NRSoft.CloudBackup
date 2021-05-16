using NRSoft.WebAssembly.BootstapBlazorTheme.Themes;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Toolbars;

namespace NRSoft.WebAssembly.BootstapBlazorTheme
{
    public class BootstrapBlazorToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }

            return Task.CompletedTask;
        }
    }
}