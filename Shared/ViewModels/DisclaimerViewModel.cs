using BlazorDeploymentTest.Shared.Enumerations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public partial class DisclaimerViewModel : BaseViewModel
    {
        public DisclaimerViewModel()
        {

        }
        private Languages _selectedLanguage;


        public Languages SelectedLanguage
        {
            get => _selectedLanguage;
            set => SetProperty(ref _selectedLanguage, value);
        }


        public void OnChangeLanguage(ChangeEventArgs e)
        {
            SelectedLanguage = (Languages)Convert.ToInt32(e.Value.ToString());
        }
    }
}
