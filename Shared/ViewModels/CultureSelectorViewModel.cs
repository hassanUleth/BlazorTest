using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public class CultureSelectorViewModel
    {

        public NavigationManager? NavManager { get; set; }


        public IJSRuntime? JSRuntime { get; set; }

        public List<CultureInfo> AvailableCultures { get;} = new List<CultureInfo>
        {
            new CultureInfo("en-CA"),
            new CultureInfo("fr-CA")
        };

        public CultureSelectorViewModel(NavigationManager? navManager, IJSRuntime? jSRuntime)
        {
            NavManager = navManager;
            JSRuntime = jSRuntime;
        }

        public CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var js = JSRuntime as IJSInProcessRuntime;
                    js?.InvokeVoid("blazorCulture.set", value.Name);
                    NavManager?.NavigateTo(NavManager.Uri, forceLoad: true);
                }
            }
        }
    }
}
