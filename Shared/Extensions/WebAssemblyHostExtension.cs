using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
// ReSharper disable InconsistentNaming

namespace BlazorDeploymentTest.Shared.Extensions
{
    public static class WebAssemblyHostExtension
    {
        private const string DefaultCulture = "en-CA";
        private static IJSObjectReference? s_jsModule;

        public static async Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
            s_jsModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/blazorCulture.js");
            var result = await s_jsModule.InvokeAsync<string>("getBlazorCulture");

            CultureInfo cultureInfo;

            if (result != null)
            {
                cultureInfo = new CultureInfo(result);
            }
            else
            {
                cultureInfo = new CultureInfo(DefaultCulture);
                await s_jsModule.InvokeVoidAsync("setBlazorCulture", DefaultCulture);
            }

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
