   M S B A M L   `   `   `  ����Y  UAirConditionerShop_TranVanTung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AirConditionerShop_TranVanTungAirConditionerShop_TranVanTung  5   	   /    )AirConditionerShop_TranVanTung.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:AirConditionerShop_TranVanTung     5   	   -   5          � Title$2  ,Thế Giới Điện Tử Xứ F - ver.24-SU��5   	   $	��685��63   $
��1265��6@   ���#ff2800 � WindowStartupLocation$ CenterScreen=�6b    � 
ResizeMode$ NoResize=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��305* �6   �� 5      $	��44* �6   �� 5      $
��320* �6   .+�5   
   �� $&�� Thế Giới Điện Tử Xứ F��6   $
��Left=�60   $��80��6K   $��	31,20,0,0q�6W   $	��Top=�6j   $	��569��6�   $��Heavy"�6�   $��50(�6�   $��Italic$�6�   
��� ���6�   �� 5   
   $��
ver. 24-SU��6   $
��Left=�6%   $��50��6@   $��
598,40,0,0q�6L   $	��Top=�6`   $	��275��6x   $��30(�6�   
��� ���$��Italic$�6�   �� 5   
   -   5         ��Name$ HelloMsgLabel��5      $��Hello, Administrator��6'   $
��Left=�6F   $��50��6a   $��	929,6,0,0q�6m   $	��Top=�6�   $	��315��6�   $��25(�6�   $��Italic$�6�      YellowLabelStyle#��[  6�   $��Right=�6�   �� 5   
   $
��Left=�6   $��95��6/   $��
39,140,0,0q�6;   
���   �$	��Top=�6^   $
��1171��6v   ���#ffff00 �� RadiusX$ 10��6�    �� RadiusY$ 10��6�   �� 5   
   -   5         ��Name$ SearchButton��5      $��Search Air Conditioner��6'   $
��Left=�6H   $��50��6c   $��
75,162,0,0q�6o   $	��Top=�6�   $	��262��6�   $��2��6�     RedButtonStyle#��[ 6�   6�   �� 5   
   $��Feature Function��6   $
��Left=�6+   $��45��6F   $��388,169,0,0q�6R   $	��Top=�6g   $	��152��6   ���#ff45006�   �� 5   
   -   5         ��Name$ FeatureFunctionTextBox��5      $
��Left=�62   $��45��6M   $��547,165,0,0q�6Y   	 �� TextWrapping$
	 Wrap=�6n   $	��Top=�6�   $	��303��6�   $��0��6�   �� 5   
   $��Quantity��6   $
��Left=�6#   $��45��6>   $��905,169,0,0q�6J   $	��Top=�6_   $	��108��6w   ���#ff45006�   �� 5   
   -   5        $ QuantityTextBox��5      $
��Left=�6+   $��45��6F   $��1003,165,0,0q�6R   $
	 Wrap=�6h   $	��Top=�6}   $	��185��6�   $��1��6�   �� 5   
   -   5        $ CreateButton��5      $��Create Air Con��6'   $
��Left=�6@   $��50��6[   $��1003,294,0,0q�6g   $	��Top=�6}   $	��185��6�   $��3��6�   $��2��6�   �� 5   
   -   5        $ UpdateButton��5      $��Update Air Con��6'   $
��Left=�6@   $��50��6[   $��1003,18,0,0q�6g   $	��Top=�6|   $��185                 ��6�   $��4��5      $��2��6    6-   �� 5   
   -   5        $ DeleteButton��5      $��Delete Air Con��6'   $
��Left=�6@   $��50��6[   $��1003,95,0,0q�6g   $	��Top=�6|   $��185                 ��6�   $��5��5      $��2��6    6-   �� 5    
   -	   5        $ 
QuitButton��5       $
��Quit��6%   $
��Left=�64   $��50��6O   $��1003,191,0,0q�6[   $	��Top=�6q   $	��185��6�   $��6��6�   $��2��6�   6�   &   System.Windows.Controls.DataGrid  5"   
   -
   5        
  Name$
 AirConsDataGrid��5"      $
��Left=�6,   $	��310��6G   $��
40,289,0,0q�6T   $	��Top=�6h   $	��930��6�      AutoGenerateColumns$ False��6�   $��7��6�   $��3��6�      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *AirConditionerId+  5%      $ Air Con Name��6%   $	 200 6;    6G   �� *AirConditionerName+  5&      $ Warranty��6%   $ 70 67    6B   �� *
Warranty+  5'      $ Sound Level��6%   $	 100 6:    6F   �� *SoundPressureLevel+  5(      $ Feature Function��6%   $	 200 6?    6K   �� *FeatureFunction+  5)      $ Quantity��6%   $ 70 67    6B   �� *
Quantity+  5*      $ 	Price ($)��6%   $	 100 68    6D   �� *DollarPrice+  5+      $ Supplier ID��6%   $ 70 6:    6E   �� *
SupplierId+  5,      $ Supplier Name��6%   $	 140 6<    6H   �� *Supplier.SupplierName+5.      �� 50   
   $��© 2025 VanTung��6   $
��Left=�6)   $��45��6D   $��
34,256,0,0q�6P   $	��Top=�6d   $	��182��6|   ���#ffff00$��2��6�   52      53      