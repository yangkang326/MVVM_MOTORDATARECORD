   M S B A M L   `   `   `  ����O  KMVVM_MOTORDATARECORD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MVVM_MOTORDATARECORD.ModelsMVVM_MOTORDATARECORD.Models  5      U/clr-namespace:MVVM_MOTORDATARECORD.Usercontrols!MVVM_MOTORDATARECORD.Usercontrols  5      Q-clr-namespace:MVVM_MOTORDATARECORD.ViewModelsMVVM_MOTORDATARECORD.ViewModels  5      R NHslControls, Version=2.4.0.0, Culture=neutral, PublicKeyToken=a3ad7c5c937ec0c0F2clr-namespace:HslControls.WPF;assembly=HslControlsHslControls.WPF 5      X TLiveCharts.Geared, Version=1.2.8.2, Culture=neutral, PublicKeyToken=7292f245d14ab8bfP:clr-namespace:LiveCharts.Geared;assembly=LiveCharts.GearedLiveCharts.Geared 5
      fEclr-namespace:LiveCharts.Geared.Geometries;assembly=LiveCharts.GearedLiveCharts.Geared.Geometries 5      ;"clr-namespace:MVVM_MOTORDATARECORDMVVM_MOTORDATARECORD  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      %    MVVM_MOTORDATARECORD.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <Models)clr-namespace:MVVM_MOTORDATARECORD.Models     5      HUsercontrols/clr-namespace:MVVM_MOTORDATARECORD.Usercontrols     5      D
ViewModels-clr-namespace:MVVM_MOTORDATARECORD.ViewModels     5      BWPF2clr-namespace:HslControls.WPF;assembly=HslControls     5      @d2http://schemas.microsoft.com/expression/blend/2008     5	      Mgeared:clr-namespace:LiveCharts.Geared;assembly=LiveCharts.Geared     5
      \
geometriesEclr-namespace:LiveCharts.Geared.Geometries;assembly=LiveCharts.Geared     5      4local"clr-namespace:MVVM_MOTORDATARECORD     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$  mwindows��5       � Title$ 
MainWindow��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6   $��端口号：��6/   �� 5      $	��120��5      $
��Left=�5      $��Center=�5      ��5      �� *MyPortdata.MyPortname+ �� SelectedIndex 5      �� *
SelectPort+�� 5       $��Center=�6   $��波特率：��6/   �� 5!      $	��120��5"      $
��Left=�5#      $��Center=�5$      ��5%      �� *MyPortdata.MyBaudrate+ 5&      �� *SelectBaudrate+�� 5'      $��Center=�6   $��停止位：��6/   �� 5(      $	��120��5)      $
��Left=�5*      $��Center=�5+      ��5,      �� *MyPortdata.MyStopbits+ 5-      �� *SelectStopits+�� 5.      $��Center=�6   $��数据位：��6/   �� 5/      $	��120��50      $
��Left=�51      $��Center=�52      ��53      �� *MyPortdata.MyParity+ 54      �� *SelectParity+�� 55      -   5        $��connect��55   *   �� 56      -   5        $
��Stop��56   ,   57      �� 59   
   $��1��6   .@�5:      �� $��实时数据��6   .��5;      �  5<      �� 5=      $	��300 �6(   �� 5>      $��* �6(    � ColumnDefinitions 5@      �� 5A      $��* �6+   �� 5B      $��* �6+   �� 5C      $��* �6+   .+�5E      �� $��0��5F      $��10q�5G      
���   � �� CornerRadius$ 20��5I      ._�5J      �  5K      �� 5L   "   $
��auto �60   �� 5M   "   $��* �60   .+�5O      �� $��Center=�5P   !   $��Center=�5Q   !   $ 
Horizontal=�5R   !   .+�5S   "   �� $��Center=�5T   %   $��Center=�5U   %   $��扭矩(N.m)��5V   %   $��20(�5W   %   
�������5X   %   �� 5Y   "   $��Center=�5Z   %   $��Center=�5[   %   $��30(�5]   %   
���������5\   %   �� *MyMeter.MyTroque+ �� StringFormat$ 
{0:####.#}��5^   %   5_      !  LiveCharts.Wpf.AngularGauge  5`      $��1��5a   !   $��16(�5b   !   $
��Bold"�5c   !   
�������   	FromValue$ 0Q�5e   !   	   
LabelsStep$	 10Q�5f   !   
   SectionsInnerRadius$
 .5Q�5g   !      TicksForeground
 �����   	TicksStep$ 1Q�5i   !      ToValue$	 100Q�5j   !      Wedge$	 300Q�5k   !      Value 5l   !   �� *MyMeter.MyTroque+   Sections 5n   &   #  LiveCharts.Wpf.AngularSection     Fill
 � � �   	FromValue$ 40Q�5p   )      ToValue$ 60Q�5q   )     5r   &    �#FF3939$ 60Q�5t   )   $ 90Q�5u   )   5w      5x      5y      �� 5z      $��1��5{      $��10q�5|      
���   �$ 20��5~      ._�5      �  5�      �� 5�   "   $
��auto �60   �� 5�   "   $��* �60   .+�5�      �� $��Center=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $��Center=�5�   %   $��Center=�5�   %   $��速度(r/min)��5�   %   $��20(�5�   %   
�������5�   %   �� 5�   "   $��Center=�5�   %   $��Center=�5�   %   $��30(�5�   %   
���������5�   %   �� *MyMeter.MySpeed+5�   %   5�        5�      $��1��5�   !   $��16(�5�   !   $
��Bold"�5�   !   
�������$ 0Q�5�   !   $		 200Q�5�   !   $
 .5Q�5�   !   
 �����$ 20Q�5�   !   $
 2000Q�5�   !   $	 300Q�5�   !    5�   !   �� *MyMeter.MySpeed+ 5�   &     
 � � �$
 1400Q�5�   )   $
 1600Q�5�   )     5�   &    �#FF3939$
 1600Q�5�   )   $
 2000Q�5�   )   5�      5�      5�      �� 5�      $��2��5�      $��10q�5�      
���   �$ 20��5�      ._�5�      �  5�      �� 5�   "   $
��auto �60   �� 5�   "   $��* �60   .+�5�      �� $��Center=�5�   !   $��Center=�5�   !   $ 
Horizontal=�5�   !   .+�5�   "   �� $��Center=�5�   %   $��Center=�5�   %   $��	功率(W)��5�   %   $��20(�5�   %   
�������5�   %   �� 5�   "   $��Center=�5�   %   $��Center=�5�   %   $��30(�5�   %   
���������5�   %   �� *MyMeter.MyPower+5�   %   5�        5�      $��1��5�   !   $��16(�5�   !   $
��Bold"�5�   !   
�������$ 0Q�5�   !   $
	 1000Q�5�   !   $
 .5Q�5�   !   
 �����$	 100Q�5�   !   $ 11000Q�5�   !   $	 300Q�5�   !    5�   !   �� *MyMeter.MyPower+ 5�   &     
 � � �$
 7500Q�5�   )   $
 9000Q�5�   )     5�   &    �#FF3939$
 9500Q�5�   )   $ 11000Q�5�   )   5�      5�      5�      �� 5�      $��1��5�      $��3��5�      $��2q�5�      
���   �$ 10��5�      ._�5�        HslControls.WPF.HslCurve  -   5        $��RealtimeLine��5�         IsRenderRightCoordinate .     ValueMaxLeft$ 10000��5�         ValueMinLeft$ 0��5�      5�      5�      5�      �� 5�      $��数据曲线��6   .��5�      �  5�      �� 5�      $	��14* �6+   �� 5�      $
��579* �6+   �� 5�      $
��593* �6+    5�      �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�      �� $��1��5�      $��2��5�      $ 
Horizontal=�5      .+�5     �� -   5        $	��120��5     $��	Load File��5     �� 5     -   5        $	��120��5     $��this test line��5     5	     �� 5     $��1��5     $��0��5     $��2��5     $��3q�5     
���   �$ 5��5     ._�5     �  5     �� 5  "   $
��auto �60   �� 5  "   $��* �60   .+�5     �� $��Center=�5  !   $��速度功率曲线��5  !   $��20(�5  !   
�������5  !   #  LiveCharts.Wpf.CartesianChart  5     -   5          Name$ SN��5  !   $��1��5  !   $��5q�5  !   &   LiveCharts.Wpf.Charts.Base.Chart   DisableAnimations .    Zoom$ Xy=�5!  !      Series 5#  &   &   LiveCharts.Geared.GScatterSeries    LiveCharts.Wpf.Series   Fill �#EF6C003  -LiveCharts.Geared.Geometries.GearedGeometries   Circle   GearedPointGeometry# Z 5%  )      MaxPointShapeDiameter$ 8Q�5&  )      Values 5'  )   �� *VALUEA+5)     5*     5+     �� 5,     $��1��5-     $��2��5.     $��3q�5/     
���   �$ 5��51     ._�52     �  53     �� 54  "   $
��auto �60   �� 55  "   $��* �60   .+�57     �� $��Center=�58  !   $��速度扭矩曲线��59  !   $��20(�5:  !   
�������5;  !     5<     -   5        $ SP��5=  !   $��1��5>  !   $��5q�5?  !    . $ Xy=�5A  !    5C  &      �#EF6C00# Z 5E  )   $ 8Q�5F  )    5G  )   �� *VALUEB+5I     5J     5K     5L     5M     5N     5O     5P     