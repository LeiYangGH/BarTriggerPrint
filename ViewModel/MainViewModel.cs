using BarTriggerPrint.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //this.BarcodeGeneratorViewModel = new Barcode1GeneratorViewModel();
            this.ObsBarcodeGeneratorVMs = new ObservableCollection<BarcodeGeneratorViewModel>()
            {
                new Barcode1GeneratorViewModel(),
                new Barcode2GeneratorViewModel()
            };
        }

        private BarcodeGeneratorViewModel barcodeGeneratorViewModel;
        public BarcodeGeneratorViewModel BarcodeGeneratorViewModel
        {
            get
            {
                return this.barcodeGeneratorViewModel;
            }
            set
            {
                if (this.barcodeGeneratorViewModel != value)
                {
                    this.barcodeGeneratorViewModel = value;
                    this.RaisePropertyChanged(nameof(BarcodeGeneratorViewModel));
                }
            }
        }


        private ObservableCollection<BarcodeGeneratorViewModel> obsBarcodeGeneratorVMs;
        public ObservableCollection<BarcodeGeneratorViewModel> ObsBarcodeGeneratorVMs
        {
            get
            {
                return this.obsBarcodeGeneratorVMs;
            }
            set
            {
                if (this.obsBarcodeGeneratorVMs != value)
                {
                    this.obsBarcodeGeneratorVMs = value;
                    this.RaisePropertyChanged(nameof(ObsBarcodeGeneratorVMs));
                }
            }
        }



        private bool isExporting;
        private RelayCommand exportCommand;

        public RelayCommand ExportCommand
        {
            get
            {
                return exportCommand
                  ?? (exportCommand = new RelayCommand(
                    async () =>
                    {
                        if (isExporting)
                        {
                            return;
                        }

                        isExporting = true;
                        ExportCommand.RaiseCanExecuteChanged();

                        await Export();

                        isExporting = false;
                        ExportCommand.RaiseCanExecuteChanged();
                    },
                    () => !isExporting));
            }
        }

        
        private async Task Export()
        {
            await Task.Run(() =>
            {
                if (this.BarcodeGeneratorViewModel != null)
                //this.Message = this.BarcodeGeneratorViewModel.Name;
                this.Message = this.BarcodeGeneratorViewModel.GenerateBarcode();
            });
        }

        private string message;
        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    this.RaisePropertyChanged(nameof(Message));
                }
            }
        }


    }
}