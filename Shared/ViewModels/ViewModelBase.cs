using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace BlazorDeploymentTest.Shared.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        #region Fields    

        private string _title;
        private string _subtitle;
        //private Storage _storage;


        //private ObservableCollection<Farm> _copiedFarmsUsedForSimulation;
        //private EmissionDisplayUnits _selectedEmissionDisplayUnits;

        #endregion

        #region Constructors

        protected ViewModelBase()
        {
            this.Construct();
        }

        //protected ViewModelBase(Storage storage)
        //{
        //    if (storage != null)
        //    {
        //        this.Storage = storage;
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException(nameof(storage));
        //    }

        //    this.Construct();
        //}


        #endregion

        #region Properties

        //public Storage Storage
        //{
        //    get { return _storage; }
        //    set { SetProperty(ref _storage, value); }
        //}

        //public IEventAggregator EventAggregator { get; set; }

        //public DelegateCommand<object> OkCommand { get; set; }
        //public DelegateCommand<object> CancelCommand { get; set; }
        //public DelegateCommand NextCommand { get; set; }
        //public DelegateCommand BackCommand { get; set; }
        //public DelegateCommand ResultsCommand { get; set; }
        //public DelegateCommand ResetStageState { get; set; }

        /// <summary>
        /// The title of the view.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { this.SetProperty(ref _title, value); }
        }

        /// <summary>
        /// The subtitle of the view.
        /// </summary>
        public string Subtitle
        {
            get { return _subtitle; }
            set { this.SetProperty(ref _subtitle, value); }
        }

        // Active farm property must be readonly so that all views and view models get the same instance of the ActiveFarm property from the GlobalSettings instance. 
        // If this isn't readonly, then each view model will get a different instance of this property and the instances will be out of sync when one copy of the active farm is updated.
        // The issue is that an instance of this class 'ViewModelBase' is created for each class that inherits from it which is pretty much all view models - therefore unless this property
        // is readonly (returns same object each time), then all view models will get different copies of the ActiveFarm which is not what we want.
        //public Farm ActiveFarm
        //{
        //    get { return this.Storage.ApplicationData.GlobalSettings.ActiveFarm; }
        //}

        public bool WindowWasCancelled { get; set; }

//        public ObservableCollection<Farm> CopiedFarmsUsedForSimulation
//        {
//            get { return _copiedFarmsUsedForSimulation; }
//            set { SetProperty(ref _copiedFarmsUsedForSimulation, value); }
//        }

//        public EmissionDisplayUnits SelectedEmissionDisplayUnits
//        {
//            get { return _selectedEmissionDisplayUnits; }
//            set { SetProperty(ref _selectedEmissionDisplayUnits, value); }
//}

//        public UnitsOfMeasurementCalculator UnitCalculator { get; set; }

        #endregion

        #region Public Methods

        public void Construct()
        {
            //HTraceListener.AddTraceListener();

            //this.CopiedFarmsUsedForSimulation = new ObservableCollection<Farm>();

            //this.ResultsCommand = new DelegateCommand(this.OnResults);

            //this.UnitCalculator = new UnitsOfMeasurementCalculator();
        }

        private void GlobalSettingsOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            // ActiveFarm property on this class is readonly - but ActiveFarm on GlobalSettings class can change if user set farm to another farm. This property
            // will then need to be updated and listeners need to know.
            //if (propertyChangedEventArgs.PropertyName.Equals(nameof(ActiveFarm)))
            //{
            //    this.RaisePropertyChanged(nameof(ActiveFarm));
            //}
        }

        /// <summary>
        /// A place for view model initialization.
        /// </summary>
        public virtual void InitializeViewModel()
        {
        }

        /// <summary>
        /// used for farm comparison while in the results
        /// </summary>
        //public virtual void InitializeViewModel(FarmEmissionResults activeFarmEmissionResults,
        //    List<FarmEmissionResults> selectedFarmEmissionResultsList)
        //{

        //}

        public virtual void InitializeViewModel(ComponentBase component)
        {

        }

        //public void InvokeOnUiThread(Action action)
        //{
        //    if (Application.Current.Dispatcher.CheckAccess())
        //    {
        //        action();
        //    }
        //    else
        //    {
        //        Application.Current.Dispatcher.Invoke(action);
        //    }
        //}

        //public double GetBindingValueFromSystem(MetricUnitsOfMeasurement metricUnit, double value)
        //{
        //    var farmUnits = this.ActiveFarm.MeasurementSystemType;
        //    if (farmUnits == MeasurementSystemType.Imperial)
        //        return this.UnitCalculator.GetUnitValueFromHolos(farmUnits, metricUnit, value);
        //    return value;
        //}

        //public void ConvertDefaultDiets()
        //{
        //    if (this.ActiveFarm.MeasurementSystemType != MeasurementSystemType.Imperial) return;

        //    foreach (var diet in this.ActiveFarm.Diets.Where(x => x.IsDefaultDiet && x.IsConverted == false))
        //    {
        //        diet.MetabolizableEnergy = Math.Round(
        //            this.UnitCalculator.ConvertValueToImperialFromMetric(
        //                MetricUnitsOfMeasurement.MegaCaloriePerKilogram, diet.MetabolizableEnergy), 1);

        //        if (diet.AnimalType.IsSwineType())
        //        {
        //            diet.De1X = Math.Round(this.UnitCalculator.ConvertValueToImperialFromMetric(
        //                MetricUnitsOfMeasurement.KiloCaloriePerKilogram, diet.De1X), 1);
        //        }
        //        else
        //        {
        //            diet.De1X = Math.Round(this.UnitCalculator.ConvertValueToImperialFromMetric(
        //                MetricUnitsOfMeasurement.MegaCaloriePerKilogram, diet.De1X), 1);
        //        }

        //        diet.Nel3X = Math.Round(
        //            this.UnitCalculator.ConvertValueToImperialFromMetric(
        //                MetricUnitsOfMeasurement.MegaCaloriePerKilogram, diet.Nel3X), 1);

        //        diet.NetEnergy = Math.Round(
        //            this.UnitCalculator.ConvertValueToImperialFromMetric(
        //                MetricUnitsOfMeasurement.KiloCaloriePerKilogram, diet.NetEnergy), 1);

        //        diet.IsConverted = true;
        //    }

        //}
        #endregion

        #region Private Methods

        protected void CloseRadWindow(object o)
        {
            //if (o is Window window)
            //{
            //    window.Close();

            //    return;
            //}

            //if (o is UIElement uiElement)
            //{
            //    var radWindow = uiElement.GetVisualParent<RadWindow>();
            //    radWindow.Close();
            //    radWindow.Show();
            //}
        }

        public void SetSelectedDisplayUnits()
        {
            //if (this.ActiveFarm.MeasurementSystemType == MeasurementSystemType.Imperial)
            //{
            //    this.SelectedEmissionDisplayUnits = EmissionDisplayUnits.PoundsGhgs;
            //}
        }
        #endregion

        #region Event Handlers

        private void OnResults()
        {
            //if (this.ActiveFarm.ShowSimplifiedResults)
            //{
            //    this.RegionManager.RequestNavigate(Regions.ContentRegion, nameof(SimplifiedResultsView));
            //}
            //else
            //{
            //    this.RegionManager.RequestNavigate(Regions.ContentRegion, nameof(ResultsCompositeView));
            //}
        }

        #endregion

    }
}
