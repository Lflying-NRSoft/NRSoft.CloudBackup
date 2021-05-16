using Volo.Abp.Bundling;

namespace NRSoft.WebAssembly.BootstapBlazorTheme
{
    public class BootstrapBlazorBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            //context.Add("_content/Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme/libs/abp/css/theme.css");
        }
    }
}
