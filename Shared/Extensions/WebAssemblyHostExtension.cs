using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorDeploymentTest.Shared.Extensions
{
    public static class WebAssemblyHostExtension
    {
        private static string _defaultCulture = "en-CA";
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");

            CultureInfo cultureInfo;

            if (result != null)
            {
                cultureInfo = new CultureInfo(result);
            }
            else
            {
                cultureInfo = new CultureInfo(_defaultCulture);
                await jsInterop.InvokeVoidAsync("blazorCulture.set", _defaultCulture);
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
