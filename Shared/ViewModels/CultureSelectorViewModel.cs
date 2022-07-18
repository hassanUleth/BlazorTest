using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;
using BlazorDeploymentTest.Shared.Enumerations;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public class CultureSelectorViewModel
    {

        public NavigationManager? NavManager { get; set; }


        public IJSRuntime? JSRuntime { get; set; }

        /// <summary>
        /// Tuple of Language Enumeration and CultureInfo. This tuple is initialized with languages currently available in the program. The list is created as a
        /// tuple to associate a localized language enumeration with the cultureinto set by the user.
        /// </summary>
        public List<(Languages Language, CultureInfo CultureType)> AvailableCultures { get;} = new List<(Languages, CultureInfo)>
        {
            (Languages.English, new CultureInfo("en-CA")),
            (Languages.French, new CultureInfo("fr-CA"))
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
