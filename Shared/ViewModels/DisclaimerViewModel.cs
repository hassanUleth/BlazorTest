using BlazorDeploymentTest.Shared.Enumerations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public partial class DisclaimerViewModel : ViewModelBase
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

        public ObservableCollection<Languages> Languages { get; set; } = new ObservableCollection<Languages>(Enum.GetValues(typeof(Languages)).Cast<Languages>());



        public void OnChangeLanguage(ChangeEventArgs e)
        {
            SelectedLanguage = (Languages)Convert.ToInt32(e.Value.ToString());
        }
    }
}
