using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public partial class TasksViewModel : ViewModelBase
    {
        [ObservableProperty] 
        private string buttonText = "Click here to add task";

        [ObservableProperty]
        private int count;

        [ObservableProperty]
        private string currentTask;

        [ObservableProperty]
        private List<string> tasks = new List<string>();

        [RelayCommand]
        public void AddTask()
        {
            this.Tasks.Add(currentTask);
            currentTask = string.Empty;
            Count++;
        }
    }
}
