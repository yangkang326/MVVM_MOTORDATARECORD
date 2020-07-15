using GalaSoft.MvvmLight;

namespace MVVM_MOTORDATARECORD.Models
{
    internal class Meterdata : ObservableObject
    {
        private double _MyTroque;

        public double MyTroque
        {
            get { return _MyTroque; }
            set { _MyTroque = value; RaisePropertyChanged(() => MyTroque); }
        }

        private double _MySpeed;

        public double MySpeed
        {
            get { return _MySpeed; }
            set { _MySpeed = value; RaisePropertyChanged(() => MySpeed); }
        }

        private double _MyPower;

        public double MyPower
        {
            get { return _MyPower; }
            set { _MyPower = value; RaisePropertyChanged(() => MyPower); }
        }
    }
}