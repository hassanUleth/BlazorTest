using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;
using BlazorDeploymentTest.Shared.Enumerations;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public class CultureSelectorViewModel
    {
        private readonly NavigationManager? _navManager;

        private readonly IJSRuntime? _jsRuntime;

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
            _navManager = navManager;
            _jsRuntime = jSRuntime;
        }

        /// <summary>
        /// Creates a culture property. The culture property is set to user selection using a javascript script that stores
        /// the culture in localstorage. The set method then reloads the page to apply the new culture.
        /// </summary>
        public CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture == value)
                {
                    return;
                }
                _ = SetCultureValue(value);
                _navManager?.NavigateTo(_navManager.Uri, forceLoad: true);
            }
        }

        /// <summary>
        /// Loads a javascript module and uses InvokeVoidAsync to set the value of the culture.
        /// </summary>
        /// <param name="cultureValue"></param>
        /// <returns></returns>
        private async Task SetCultureValue(CultureInfo cultureValue)
        {
            if (_jsRuntime != null)
            {
                var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/blazorCulture.js");
                await jsModule.InvokeVoidAsync("setBlazorCulture", cultureValue.Name);
            }
        }
    }
}
