using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.IO.Ports;

namespace MVVM_MOTORDATARECORD.Models
{
    internal class MySerialPort : ObservableObject
    {
        public MySerialPort()
        {
            _MyPortname = new List<string> { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10" };
            _MyBaudrate = new List<int> { 4800, 9600, 19200 };
            _MyStopbits = new List<StopBits> { StopBits.None, StopBits.One, StopBits.OnePointFive, StopBits.Two };
            _MyParity = new List<Parity> { Parity.Even, Parity.Mark, Parity.None, Parity.Odd, Parity.Space };
        }

        private List<string> _MyPortname;

        public List<string> MyPortname
        {
            get { return _MyPortname; }
            set { _MyPortname = value; RaisePropertyChanged(() => MyPortname); }
        }

        private List<int> _MyBaudrate;

        public List<int> MyBaudrate
        {
            get { return _MyBaudrate; }
            set { _MyBaudrate = value; RaisePropertyChanged(() => MyBaudrate); }
        }

        private List<StopBits> _MyStopbits;

        public List<StopBits> MyStopbits
        {
            get { return _MyStopbits; }
            set { _MyStopbits = value; RaisePropertyChanged(() => MyStopbits); }
        }

        private List<Parity> _MyParity;

        public List<Parity> MyParity
        {
            get { return _MyParity; }
            set { _MyParity = value; RaisePropertyChanged(() => MyParity); }
        }
    }
}