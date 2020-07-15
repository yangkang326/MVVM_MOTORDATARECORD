using MVVM_MOTORDATARECORD.ViewModels;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MVVM_MOTORDATARECORD
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataShow _MyVM;
        private DispatcherTimer t1;

        public MainWindow()
        {
            _MyVM = new DataShow();
            DataContext = _MyVM;
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(200);
            t1.Tick += new EventHandler(Adddataline);
            InitializeComponent();
            RealtimeLine.SetLeftCurve("速度", null, Colors.Red);
            RealtimeLine.SetLeftCurve("扭矩", null, Colors.Green);
            RealtimeLine.SetLeftCurve("功率", null, Colors.Yellow);
        }

        public void Adddataline(object sender, EventArgs e)
        {
            RealtimeLine.AddCurveData(new string[]
                        {
                            "速度",
                            "扭矩",
                            "功率"
                        },
                        new float[]
                        {
                           (float)_MyVM.MyMeter.MySpeed,(float)_MyVM.MyMeter.MyTroque,(float)_MyVM.MyMeter.MyPower
                        }
                        );
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _MyVM.ConnectComPort();
            if (_MyVM.MyComPort.IsOpen)
            {
                t1.Start();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _MyVM.Getrecord();
        }

        private void mwindows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _MyVM.Exit();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _MyVM.Exit();
            t1.Stop();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (_MyVM.exelcreated1)
            {
                try
                {
                    _MyVM.Getthisrecord();
                }
                catch { }
            }
        }
    }
}