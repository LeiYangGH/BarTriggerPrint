using BarTriggerPrint.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Seagull.BarTender.Print;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        private Engine m_engine = null;
        private LabelOperator labelOperator;
        private static int currentSN = 0;
        private SerialPort serialPort;// = new SerialPort(Constants.SerialPortComName, 9600);

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
            }
            else
            {
                Task.Run(() => this.InitComponents());
            }
        }

        private void InitComponents()
        {
            this.labelOperator = new LabelOperator(this.BtEngine);
            this.ListBtwDirs();
            this.CreateShifts();
            this.ObsPrintHistoryVMs = new ObservableCollection<PrintHistoryViewModel>();
            this.SelectedDate = DateTime.Today;
            this.StartingNumberString = "0001";
            this.ReadFieldsAliasXml();
            SqliteHistory.CreateDb();
            try
            {
                this.serialPort = new SerialPort(Constants.SerialPortComName, 9600);
                this.serialPort.DataReceived += SerialPort_DataReceived;
                this.serialPort.Open();
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Error($"初始化串口出错{ex.Message}");
            }
        }

        private static object obj = new object();
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!this.serialPort.IsOpen)
                return;
            int bytes = this.serialPort.BytesToRead;
            byte[] buffer = new byte[bytes];
            this.serialPort.Read(buffer, 0, bytes);
            //string recieved = this.serialPort.ReadExisting();
            string bytesString = BitConverter.ToString(buffer);
            Log.Instance.Logger.Info($"收到串口{Constants.SerialPortComName}数据:{bytesString}.");
            this.Message = $"收到串口{Constants.SerialPortComName}数据:{bytesString}.";
            lock (obj)
            {
                Task.Run(() => this.Print());
            }
        }

        private void ReadFieldsAliasXml()
        {
            try
            {
                XElement rules = XElement.Load(Constants.FieldsAliasXmlFile);
                foreach (var standardName in rules.Elements())
                {
                    var t2s = new List<string>();
                    foreach (var t2 in standardName.Elements())
                    {
                        t2s.Add(t2.Name.LocalName);
                    }
                    Constants.FieldsAliasDict.Add(standardName.Name.LocalName, t2s.ToArray());
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Logger.Info($"读取字段别名出错{Constants.FieldsAliasXmlFile}:{ex.Message}");
            }

        }


        private void SetFieldsEnabled()
        {
            this.LabelHasShift = this.labelOperator.IsFieldInLabelFile(Constants.FieldShift, this.SelectedBtwFile);
            this.LabelHasDate = this.labelOperator.IsFieldInLabelFile(Constants.FieldDate, this.SelectedBtwFile);
            this.LabelHasSN = this.labelOperator.IsFieldInLabelFile(Constants.FieldSN, this.SelectedBtwFile);
        }

        private void CreateShifts()
        {
            this.ObsShifts = new ObservableCollection<Shift>()
            {
                new Shift(1),
                new Shift(2),
                new Shift(3),
            };
        }


        private Engine BtEngine
        {
            get
            {
                if (m_engine == null)
                {
                    try
                    {
                        m_engine = new Engine(true);
                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Logger.Error($"初始化调用bartender出错:{ex.Message}");
                    }
                }
                return m_engine;
            }
        }

        private void ListBtwDirs()
        {
            Log.Instance.Logger.Info($"开始查找模板,路径{Constants.btwTopDir}");

            string[] dirs = Directory.GetDirectories(Constants.btwTopDir);
            this.ObsBtwDirs = new ObservableCollection<string>(dirs);
            Log.Instance.Logger.Info($"结束查找模板，找到品类数量={this.ObsBtwDirs.Count}");
        }

        private void ListBtwFilesInDir(string dir)
        {
            Log.Instance.Logger.Info($"开始查找btw模板,路径{dir}");
            string[] files = Directory.GetFiles(dir, "*.btw");
            this.ObsBtwFiles = new ObservableCollection<string>(files);
            Log.Instance.Logger.Info($"结查找btw模板,找到模板数量={this.ObsBtwFiles.Count}");
        }

        private ObservableCollection<string> obsBtwDirs;
        public ObservableCollection<string> ObsBtwDirs
        {
            get
            {
                return this.obsBtwDirs;
            }
            set
            {
                if (this.obsBtwDirs != value)
                {
                    this.obsBtwDirs = value;
                    this.RaisePropertyChanged(nameof(ObsBtwDirs));
                }
            }
        }


        private ObservableCollection<Shift> obsShifts;
        public ObservableCollection<Shift> ObsShifts
        {
            get
            {
                return this.obsShifts;
            }
            set
            {
                if (this.obsShifts != value)
                {
                    this.obsShifts = value;
                    this.RaisePropertyChanged(nameof(ObsShifts));
                }
            }
        }


        private bool labelHasShift;
        public bool LabelHasShift
        {
            get
            {
                return this.labelHasShift;
            }
            set
            {
                if (this.labelHasShift != value)
                {
                    this.labelHasShift = value;
                    this.RaisePropertyChanged(nameof(LabelHasShift));
                }
            }
        }

        private bool labelHasDate;
        public bool LabelHasDate
        {
            get
            {
                return this.labelHasDate;
            }
            set
            {
                if (this.labelHasDate != value)
                {
                    this.labelHasDate = value;
                    this.RaisePropertyChanged(nameof(LabelHasDate));
                }
            }
        }


        private bool labelHasSN;
        public bool LabelHasSN
        {
            get
            {
                return this.labelHasSN;
            }
            set
            {
                if (this.labelHasSN != value)
                {
                    this.labelHasSN = value;
                    this.RaisePropertyChanged(nameof(LabelHasSN));
                }
            }
        }

        private string selectedBtwDir;
        public string SelectedBtwDir
        {
            get
            {
                return this.selectedBtwDir;
            }
            set
            {
                if (this.selectedBtwDir != value)
                {
                    this.selectedBtwDir = value;
                    this.ListBtwFilesInDir(value);
                    this.RaisePropertyChanged(nameof(SelectedBtwDir));
                }
            }
        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }
            set
            {
                if (this.selectedDate != value)
                {
                    this.selectedDate = value;
                    this.RaisePropertyChanged(nameof(SelectedDate));
                }
            }
        }

        private string startingNumberString;
        public string StartingNumberString
        {
            get
            {
                return this.startingNumberString;
            }
            set
            {
                if (this.startingNumberString != value)
                {
                    this.startingNumberString = value;
                    this.RaisePropertyChanged(nameof(StartingNumberString));
                }
            }
        }

        private ObservableCollection<PrintHistoryViewModel> obsPrintHistoryVMs;
        public ObservableCollection<PrintHistoryViewModel> ObsPrintHistoryVMs
        {
            get
            {
                return this.obsPrintHistoryVMs;
            }
            set
            {
                if (this.obsPrintHistoryVMs != value)
                {
                    this.obsPrintHistoryVMs = value;
                    this.RaisePropertyChanged(nameof(ObsPrintHistoryVMs));
                }
            }
        }


        private ObservableCollection<string> obsBtwFiles;
        public ObservableCollection<string> ObsBtwFiles
        {
            get
            {
                return this.obsBtwFiles;
            }
            set
            {
                if (this.obsBtwFiles != value)
                {
                    this.obsBtwFiles = value;
                    this.RaisePropertyChanged(nameof(ObsBtwFiles));
                }
            }
        }


        private string selectedShift;
        public string SelectedShift
        {
            get
            {
                return this.selectedShift;
            }
            set
            {
                if (this.selectedShift != value)
                {
                    this.selectedShift = value;
                    this.RaisePropertyChanged(nameof(SelectedShift));
                }
            }
        }



        private string selectedBtwFile;
        public string SelectedBtwFile
        {
            get
            {
                return this.selectedBtwFile;
            }
            set
            {
                if (this.selectedBtwFile != value)
                {
                    this.selectedBtwFile = value;
                    this.RaisePropertyChanged(nameof(SelectedBtwFile));
                    this.SetFieldsEnabled();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        Task.Run(() =>
                        this.LoadPrintHistory(value)
                        );
                    }
                }
            }
        }


        private void LoadPrintHistory(string file)
        {

            string BtwTemplate = this.SelectedBtwFile.Replace(
                      Constants.btwTopDir, "");

            DataTable dt = SqliteHistory.QueryRecent(BtwTemplate, 1000);
            this.ObsPrintHistoryVMs = new ObservableCollection<PrintHistoryViewModel>(
                dt.Rows.OfType<DataRow>()
                .Select(r => new PrintHistoryViewModel(
                    BtwTemplate,
                    r[0].ToString(),
                    r[1].ToString()
                    ))
                );


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



        private bool isPrinting;
        private RelayCommand printCommand;

        public RelayCommand PrintCommand
        {
            get
            {
                return printCommand
                  ?? (printCommand = new RelayCommand(
                    async () =>
                    {
                        if (isPrinting)
                        {
                            return;
                        }

                        isPrinting = true;
                        PrintCommand.RaiseCanExecuteChanged();

                        await Print();

                        isPrinting = false;
                        PrintCommand.RaiseCanExecuteChanged();
                    },
                    () => !isPrinting));
            }
        }

        private LabelFormatDocument SetLabelValues(string file, out string obarcodeHistroySuffix)
        {
            Log.Instance.Logger.Info($"开始设置标签字段值,文件{file}");
            string barcodeHistroySuffix = "";
            LabelFormatDocument label = this.labelOperator.OpenLabel(file);
            string[] fieldsIn = this.labelOperator.GetLabelFields(file);
            if (this.LabelHasShift)
            {
                string shiftValue = this.SelectedShift;
                foreach (string field in fieldsIn.Intersect(
                    Constants.FieldsAliasDict[Constants.FieldShift]
                    .Union(new string[] { Constants.FieldShift })).Distinct())
                {
                    label.SubStrings[field].Value = shiftValue;
                    Log.Instance.Logger.Info($"设置{field}={shiftValue}");
                }
                barcodeHistroySuffix += shiftValue;
            }
            if (this.LabelHasDate)
            {
                string dateValue = this.SelectedDate.ToString("yyMMdd");
                foreach (string field in fieldsIn.Intersect(
                    Constants.FieldsAliasDict[Constants.FieldDate]
                    .Union(new string[] { Constants.FieldDate })).Distinct())
                {
                    label.SubStrings[field].Value = dateValue;
                    Log.Instance.Logger.Info($"设置{field}={dateValue}");
                }
                barcodeHistroySuffix += dateValue;
            }

            if (this.LabelHasSN)
            {
                string snValue = currentSN.ToString().PadLeft(4, '0');
                foreach (string field in fieldsIn.Intersect(
                    Constants.FieldsAliasDict[Constants.FieldSN]
                    .Union(new string[] { Constants.FieldSN })).Distinct())
                {
                    label.SubStrings[field].Value = snValue;
                    Log.Instance.Logger.Info($"设置{field}={snValue}");
                }
                barcodeHistroySuffix += snValue;
            }
            Log.Instance.Logger.Info($"结束设置标签字段值,文件{file}");
            obarcodeHistroySuffix = barcodeHistroySuffix;
            return label;
        }

        private async Task Print()
        {
            await Task.Run(() =>
            {
                Log.Instance.Logger.Info($"触发打印!");

                if (!string.IsNullOrWhiteSpace(this.SelectedBtwFile)
                && File.Exists(this.SelectedBtwFile))
                {
                    if (this.BtEngine == null)
                    {
                        Log.Instance.Logger.Error($"bartender未正确初始化，无法打印!");
                        return;
                    }
                    Log.Instance.Logger.Info($"准备打印{this.SelectedBtwFile}!");
#if DEBUG
                    string obarcodeHistroySuffix;
                    LabelFormatDocument label =
                    this.SetLabelValues(this.SelectedBtwFile, out obarcodeHistroySuffix);
                    string BtwTemplate = this.SelectedBtwFile.Replace(
                        Constants.btwTopDir, "");
                    SqliteHistory.InsertPrintHistroy(
                        BtwTemplate,
                        obarcodeHistroySuffix);
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        this.ObsPrintHistoryVMs.Add(
                            new PrintHistoryViewModel(BtwTemplate, obarcodeHistroySuffix,
                                DateTime.Now.ToString()
               ));
                    });

                    this.Message = "DEBUG跳过真实打印";

#else
                    string msg = BtwPrintWrapper.PrintBtwFile(label, this.BtEngine);
                    BtwPrintWrapper.PrintPreviewLabel2File(label, this.BtEngine);
                    this.Message = msg.Trim();
#endif
                }
                else
                {
                    Log.Instance.Logger.Error($"无法打印，文件不存在：{this.SelectedBtwFile}!");
                }
            });
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    try
                    {
                        if (this.serialPort.IsOpen)
                            this.serialPort.Close();
                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Logger.Error($"关闭串口出现问题:{ex.Message}");
                    }


                    try
                    {
                        if (this.m_engine != null)
                            this.m_engine.Stop(Seagull.BarTender.Print.SaveOptions.DoNotSaveChanges);
                        this.m_engine.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Log.Instance.Logger.Error($"释放Bartender出现问题:{ex.Message}");
                    }


                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~MainViewModel() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion



    }
}