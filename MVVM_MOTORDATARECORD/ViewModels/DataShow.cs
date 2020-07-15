using GalaSoft.MvvmLight;
using HslCommunication.BasicFramework;
using LiveCharts.Geared;
using Microsoft.Win32;
using MVVM_MOTORDATARECORD.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace MVVM_MOTORDATARECORD.ViewModels
{
    internal class DataShow : ViewModelBase
    {
        private ISheet recordsheet;

        public DataShow()
        {
            _MyMeter = new Meterdata();
            _Portdata = "time";
            _MyComPort = new SerialPort();
            _MyPortdata = new MySerialPort();
            nRow = 0;
            exelcreated = false;
        }

        private Meterdata _MyMeter;

        public Meterdata MyMeter
        {
            get { return _MyMeter; }
            set { _MyMeter = value; RaisePropertyChanged(() => MyMeter); }
        }

        private MySerialPort _MyPortdata;

        public MySerialPort MyPortdata
        {
            get { return _MyPortdata; }
            set { _MyPortdata = value; RaisePropertyChanged(() => MyPortdata); }
        }

        private SerialPort _MyComPort;

        public SerialPort MyComPort
        {
            get { return _MyComPort; }
            set { _MyComPort = value; RaisePropertyChanged(() => MyComPort); }
        }

        private int _SelectPort;

        public int SelectPort
        {
            get { return _SelectPort; }
            set { _SelectPort = value; RaisePropertyChanged(() => SelectPort); }
        }

        private int _SelectBaudrate;

        public int SelectBaudrate
        {
            get { return _SelectBaudrate; }
            set { _SelectBaudrate = value; RaisePropertyChanged(() => SelectBaudrate); }
        }

        private int _SelectStopits;

        public int SelectStopits
        {
            get { return _SelectStopits; }
            set { _SelectStopits = value; RaisePropertyChanged(() => SelectStopits); }
        }

        private int _SelectParity;

        public int SelectParity
        {
            get { return _SelectParity; }
            set { _SelectParity = value; RaisePropertyChanged(() => SelectParity); }
        }

        public void ConnectComPort()
        {
            if (!_MyComPort.IsOpen)
            {
                try
                {
                    _MyComPort.PortName = _MyPortdata.MyPortname[_SelectPort];
                    _MyComPort.BaudRate = _MyPortdata.MyBaudrate[_SelectBaudrate];
                    _MyComPort.DataBits = 8;
                    _MyComPort.StopBits = _MyPortdata.MyStopbits[_SelectStopits];
                    _MyComPort.Parity = _MyPortdata.MyParity[_SelectParity];
                    _MyComPort.Open();
                    _MyComPort.DataReceived += ComPortdata;
                }
                catch { }
            }
            Creattable();
            th = new Thread(new ThreadStart(sendcmd));
            th.Start();
        }

        private Thread th;

        private void sendcmd()
        {
            while (_MyComPort.IsOpen)
            {
                writedata("FBBFBB0A010B");
                Thread.Sleep(80);
            }
            th.Abort();
        }

        public void writedata(string datastr)
        {
            byte[] array = SoftBasic.HexStringToBytes(datastr);
            try
            {
                _MyComPort.Write(array, 0, array.Length);
            }
            catch { }
        }

        private void ComPortdata(object sender, SerialDataReceivedEventArgs e)
        {
            List<byte> buffer = new List<byte>();
            byte[] data = new byte[1024];
            while (_MyComPort.IsOpen)
            {
                try
                {
                    System.Threading.Thread.Sleep(20);
                    if (_MyComPort.BytesToRead < 1)
                    {
                        break;
                    }

                    int recCount = _MyComPort.Read(data, 0, Math.Min(_MyComPort.BytesToRead, data.Length));

                    byte[] buffer2 = new byte[recCount];
                    Array.Copy(data, 0, buffer2, 0, recCount);
                    buffer.AddRange(buffer2);
                }
                catch
                {
                }
            }

            if (buffer.Count == 0) return;
            if (buffer.Count > 13)
            {
                bool check1 = true, check2 = true, check3 = true;
                _Portdata = string.Empty;

                _Portdata = HslCommunication.BasicFramework.SoftBasic.ByteToHexString(buffer.ToArray(), '/');

                string[] stringarrary = _Portdata.Split('/');
                if (stringarrary[0] == "FA" && stringarrary[1] == "AF" && stringarrary[2] == "AA")
                {
                    float njx = 01;
                    float glx = 01;
                    float zsx = 01;
                    switch (stringarrary[6])
                    {
                        case "01":
                            njx = 1000;
                            break;

                        case "02":
                            njx = 100;
                            break;

                        case "03":
                            njx = 10;
                            break;

                        case "04":
                            njx = 1;
                            break;

                        default:
                            check1 = false;
                            break;
                    }
                    switch (stringarrary[9])
                    {
                        case "01":
                            zsx = 1000;
                            break;

                        case "02":
                            zsx = 100;
                            break;

                        case "03":
                            zsx = 10;
                            break;

                        case "04":
                            zsx = 1;
                            break;

                        default:
                            check2 = false;
                            break;
                    }
                    switch (stringarrary[12])
                    {
                        case "01":
                            glx = 1000;
                            break;

                        case "02":
                            glx = 100;
                            break;

                        case "03":
                            glx = 10;
                            break;

                        case "04":
                            glx = 1;
                            break;

                        default:
                            check3 = false;
                            break;
                    }

                    if (check1 & check2 & check3)
                    {
                        nRow++;
                        float temp = ((float)(Convert.ToInt16("0x" + stringarrary[5], 16) + Convert.ToInt16("0x" + stringarrary[4], 16) * 256)) / njx;
                        if (Math.Abs(temp) < 60)
                        {
                            _MyMeter.MyTroque = temp;
                        }

                        float temp1 = ((float)(Convert.ToInt16("0x" + stringarrary[8], 16) + Convert.ToInt16("0x" + stringarrary[7], 16) * 256)) / zsx;
                        if (Math.Abs(temp1) < 2000)
                        {
                            _MyMeter.MySpeed = temp1;
                        }

                        float temp2 = ((float)(Convert.ToInt16("0x" + stringarrary[11], 16) + Convert.ToInt16("0x" + stringarrary[10], 16) * 256)) / glx;
                        if (Math.Abs(temp2) < 10000)
                        {
                            _MyMeter.MyPower = temp2;
                        }
                        IRow row = recordsheet.CreateRow(nRow);
                        row.CreateCell(0).SetCellValue(DateTime.Now.ToString("yyyy-MM-dd") + "-" + DateTime.Now.ToString("hh:mm:ss"));
                        row.CreateCell(1).SetCellValue(_MyMeter.MyTroque.ToString());
                        row.CreateCell(2).SetCellValue(_MyMeter.MySpeed.ToString());
                        row.CreateCell(3).SetCellValue(_MyMeter.MyPower.ToString());
                    }
                    _MyComPort.DiscardInBuffer();
                }
            }
        }

        private string _Portdata;

        public string Portdata
        {
            get { return _Portdata; }
            set { _Portdata = value; RaisePropertyChanged(() => Portdata); }
        }

        private GearedValues<CustomScatterPoint> _VALUEA;

        public GearedValues<CustomScatterPoint> VALUEA
        {
            get { return _VALUEA; }
            set { _VALUEA = value; RaisePropertyChanged(() => VALUEA); }
        }

        private GearedValues<CustomScatterPoint> _VALUEB;
        public bool exelcreated;
        public bool exelcreated1;
        private int nRow;

        public GearedValues<CustomScatterPoint> VALUEB
        {
            get { return _VALUEB; }
            set { _VALUEB = value; RaisePropertyChanged(() => VALUEB); }
        }

        private FileStream fs;
        private IWorkbook workbook;

        private string strWriteFilePath;

        public void Creattable()
        {
            if (!exelcreated)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.Filter = "xls|*.xls";
                bool? result = dlg.ShowDialog();
                if (result == true)
                    strWriteFilePath = dlg.FileName;
                else
                    return;
                fs = new System.IO.FileStream(strWriteFilePath, System.IO.FileMode.Create);
                if (strWriteFilePath.Contains(".xls"))
                    workbook = new NPOI.HSSF.UserModel.HSSFWorkbook();
                else
                    return;
                recordsheet = workbook.CreateSheet();
                IRow row = recordsheet.CreateRow(nRow);
                row.CreateCell(0).SetCellValue("时间");
                row.CreateCell(1).SetCellValue("扭矩 N/m");
                row.CreateCell(2).SetCellValue("速度 r/min");
                row.CreateCell(3).SetCellValue("功率 W");
                exelcreated = true;
                exelcreated1 = true;
            }
        }

        public void Getrecord()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel 2003(*.xls)|*.xls";
            bool? result = dialog.ShowDialog();
            double[][] v1;
            double[][] v2;
            if ((bool)result)
            {
                string fileName = dialog.FileName;
                if (string.IsNullOrEmpty(fileName))
                {
                    return;
                }
                FileStream fs = null;
                using (fs = File.OpenRead(fileName))
                {
                    IWorkbook workbookread = new HSSFWorkbook(fs);
                    ISheet sheetshow = workbookread.GetSheetAt(0);

                    int rowcount = sheetshow.LastRowNum;
                    v1 = new double[rowcount][];
                    v2 = new double[rowcount][];

                    double a = 0;
                    double b = 0;
                    double c = 0;

                    for (int i = 0; i < rowcount; i++)
                    {
                        IRow nowRow = sheetshow.GetRow(i + 1);
                        ICell njcell = nowRow.GetCell(1);
                        ICell zscell = nowRow.GetCell(2);
                        ICell glcell = nowRow.GetCell(3);
                        try
                        {
                            a = Convert.ToDouble(njcell.StringCellValue);
                            b = Convert.ToDouble(zscell.StringCellValue);
                            c = Convert.ToDouble(glcell.StringCellValue);
                        }
                        catch { }
                        if (zscell != null & njcell != null & glcell != null)
                        {
                            v1[i] = new[] { b, a };
                            v2[i] = new[] { b, c };
                        }
                    }
                }
                VALUEA = v1.Select(x => new CustomScatterPoint(x[0], x[1]))
                        .AsGearedValues()
                        .WithQuality(Quality.Low);

                VALUEB = v2.Select(x => new CustomScatterPoint(x[0], x[1]))
                    .AsGearedValues()
                    .WithQuality(Quality.Low);
            }
        }

        public void Getthisrecord()
        {
            double[][] v1;
            double[][] v2;

            string fileName = strWriteFilePath;
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            FileStream fs = null;
            using (fs = File.OpenRead(fileName))
            {
                IWorkbook workbookread = new HSSFWorkbook(fs);
                ISheet sheetshow = workbookread.GetSheetAt(0);

                int rowcount = sheetshow.LastRowNum;
                v1 = new double[rowcount][];
                v2 = new double[rowcount][];

                double a = 0;
                double b = 0;
                double c = 0;

                for (int i = 0; i < rowcount; i++)
                {
                    IRow nowRow = sheetshow.GetRow(i + 1);
                    ICell njcell = nowRow.GetCell(1);
                    ICell zscell = nowRow.GetCell(2);
                    ICell glcell = nowRow.GetCell(3);
                    try
                    {
                        a = Convert.ToDouble(njcell.StringCellValue);
                        b = Convert.ToDouble(zscell.StringCellValue);
                        c = Convert.ToDouble(glcell.StringCellValue);
                    }
                    catch { }
                    if (zscell != null & njcell != null & glcell != null)
                    {
                        v1[i] = new[] { b, a };
                        v2[i] = new[] { b, c };
                    }
                }
            }
            VALUEA = v1.Select(x => new CustomScatterPoint(x[0], x[1]))
                    .AsGearedValues()
                    .WithQuality(Quality.Low);

            VALUEB = v2.Select(x => new CustomScatterPoint(x[0], x[1]))
                .AsGearedValues()
                .WithQuality(Quality.Low);
        }

        public void Exit()
        {
            if (_MyComPort != null)
            {
                _MyComPort.Close();
            }
            if (exelcreated)
            {
                workbook.Write(fs);
                fs.Close();
                exelcreated = false;
            }
            if (th != null)
            {
                th.Abort();
            }
        }
    }
}