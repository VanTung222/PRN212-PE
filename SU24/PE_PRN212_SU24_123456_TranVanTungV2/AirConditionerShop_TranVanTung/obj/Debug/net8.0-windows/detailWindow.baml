   M S B A M L   `   `   `  ����Y  UAirConditionerShop_TranVanTung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AirConditionerShop_TranVanTungAirConditionerShop_TranVanTung  5   	   1    +AirConditionerShop_TranVanTung.detailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:AirConditionerShop_TranVanTung     5   	   -   5          � Title$  Air Conditioner Detail��5   	   $	��755��6(   $
��1150��65   ���#ff2800 � 
ResizeMode$ NoResize=�6W    � WindowStartupLocation$ CenterScreen=�6m   .��5	      � .+�5
   
   �� -   5         ��Name$ DetailWindowModeLble��5
      $%��Create | Update Air Conditioner��6.   $
��Left=�6X   $��80��6s   $��	38,20,0,0q�6   $	��Top=�6�   $	��814��6�   $��Heavy"�6�   $��40(�6�   $��Italic$�6�   
��� ���6�   �� 5   
   $
��Left=�6   $	��565��6/   $��
38,128,0,0q�6<   
���   �$	��Top=�6_   $	��875��6w   ���#ffff00 �� RadiusX$ 10��6�    �� RadiusY$ 10��6�   �� 5   
   $��
Air Con ID��6   $
��Left=�6%   $��45��6@   $��
58,155,0,0q�6L   $	��Top=�6`   $	��107��6x   ���#ff45006�   �� 5   
   -   5         ��Name$ AirConditionerIdTextBox��5      $
��Left=�63   $��45��6N   $��223,153,0,0q�6Z    �� TextWrapping$
 Wrap=�6o   $	��Top=�6�   $	��275��6�   $��0��6�   �� 5   
   $��Air Con Name��6   $
��Left=�6'   $��45��6B   $��
58,218,0,0q�6N   $	��Top=�6b   $	��147��6z   ���#ff45006�   �� 5   
   -   5        $ AirConditionerNameTextBox��5      $
��Left=�65   $��45��6P   $��223,216,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $	��635��6�   $��1��6�   �� 5   
   $��Warranty��6   $
��Left=�6#   $��45��6>   $��
58,284,0,0q�6J   $	��Top=�6^   $	��107��6v   ���#ff45006�   �� 5   
   -   5        $ WarrantyTextBox��5      $
��Left=�6+   $��45��6F   $��223,283,0,0q�6R   $
 Wrap=�6g   $	��Top=�6|   $	��635��6�   $��2��6�   �� 5   
   $��Sound Level��6   $
��Left=�6&   $��45��6A   $��
58,351,0,0q�6M   $	��Top=�6a   $	��128��6y   ���#ff45006�   �� 5   
   -   5        $ SoundPressureLevelTextBox��5      $
��Left=�65   $��45��6P   $��223,351,0,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $	��635��6�   $��3��6�   �� 5   
   $��Feature Function��6   $
��Left=�6+   $��45��6F   $��
58,422,0,0q�6R   $	��Top=�6f   $	��157��6~   ���#ff45006�   �� 5   
   -   5        $ FeatureFunctionTextBox��5      $
��Left=�62   $	��105��6M   $��223,421,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��637��6�   $��4��6�    �� AcceptsReturn$
 True��6�   "	 �� VerticalScrollBarVisibility$	 Visible=�6�   $	��Top=�6�   �� 5   
   $��Quantity��6   $
��Left=�6#   $��45��6>   $��
58,550,0,0q�6J   $	��Top=�6^   $	��140��6v   ���#ff45006�   �� 5   
   -   5        $ QuantityTextBox��5      $
��Left=�6+   $��45��6F   $��223,547,0,0q�6R   $
 Wrap=�6g   $	��Top=�6|   $	��227��6�   $��5��6�   �� 5    
   $��	Price ($)��6   $
��Left=�6$   $��45��6?   $��516,552,0,0q�6K   $	��Top=�6`   $	��107��6x   ���#ff45006�   �� 5!   
   -	   5        $ DollarPriceTextBox��5!      $
��Left=�6.   $��45��6I   $��615,549,0,0q�6U   $
 Wrap=�6j   $	��Top=�6   $	��244��6�   $��6��6�   �� 5#   
   $��Supplier ID��6   $
��Left=�6&   $��45��6A   $��
58,615,0,0q�6M   $	��Top=�6a   $	��147��6y   ���#ff45006�   �� 5$   
   -
   5        
 ��Name$
 SupplierIdComboBox��5$      $
��Left=�6/   $��45��6J   $��223,613,0,0q�6V   $	��Top=�6k   $	��290��6�   ���#ff4500$��7��6�   $
��Bold"�6�   $��18(�6�   �� 5&   
   -   5         ��Name$ 
SaveButton��5&      $��Save Air Con��6%   $
��Left=�6<   $��50��6W   $��945,128,0,0q�6c   $	��Top=�6x   $	��165��6�   $��8��6�   6�   �� 5'   
   -   5        $ CloseButton��5'      $��Close��6&   $
��Left=�66   $��50��6Q   $��945,208,0,0q�6]   $	��Top=�6r   $	��165��6�   $��9��6�   6�   5)      5*      