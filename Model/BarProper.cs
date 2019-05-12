using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public abstract class BarProper : INotifyPropertyChanged
    {

        protected int serialNumber;
        protected ExcelReaderConfiguration excelReaderConfiguration = new ExcelReaderConfiguration()
        {

            // Gets or sets the encoding to use when the input XLS lacks a CodePage
            // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
            // Default: cp1252 (XLS BIFF2-5 and CSV only)
            FallbackEncoding = Encoding.GetEncoding(1252),

            // Gets or sets the password used to open password protected workbooks.
            //Password = "password",

            // Gets or sets an array of CSV separator candidates. The reader 
            // autodetects which best fits the input data. Default: , ; TAB | # 
            // (CSV only)
            AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' },

            // Gets or sets a value indicating whether to leave the stream open after
            // the IExcelDataReader object is disposed. Default: false
            LeaveOpen = false,

            // Gets or sets a value indicating the number of rows to analyze for
            // encoding, separator and field count in a CSV. When set, this option
            // causes the IExcelDataReader.RowCount property to throw an exception.
            // Default: 0 - analyzes the entire file (CSV only, has no effect on other
            // formats)
            AnalyzeInitialCsvRows = 0,
        };


        protected ExcelDataSetConfiguration excelDataSetConfiguration = new ExcelDataSetConfiguration()
        {
            // Gets or sets a value indicating whether to set the DataColumn.DataType 
            // property in a second pass.
            UseColumnDataType = true,

            // Gets or sets a callback to determine whether to include the current sheet
            // in the DataSet. Called once per sheet before ConfigureDataTable.
            FilterSheet = (tableReader, sheetIndex) => true,

            // Gets or sets a callback to obtain configuration options for a DataTable. 
            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
            {
                // Gets or sets a value indicating the prefix of generated column names.
                EmptyColumnNamePrefix = "Column",

                // Gets or sets a value indicating whether to use a row from the 
                // data as column names.
                UseHeaderRow = true,

                // Gets or sets a callback to determine which row is the header row. 
                // Only called when UseHeaderRow = true.
                ReadHeaderRow = (rowReader) =>
                {
                    // F.ex skip the first row and use the 2nd row as column headers:
                    rowReader.Read();
                },

                // Gets or sets a callback to determine whether to include the 
                // current row in the DataTable.
                FilterRow = (rowReader) =>
                {
                    return true;
                },

                // Gets or sets a callback to determine whether to include the specific
                // column in the DataTable. Called once per column after reading the 
                // headers.
                FilterColumn = (rowReader, columnIndex) =>
                {
                    return true;
                }
            }
        };


        public BarProper()
        {
            this.serialNumber = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual string GetNewSerialNumberString()
        {
            string sn = this.serialNumber.ToString().PadLeft(5, '0');
            this.serialNumber++;
            return sn;
        }
    }
}
