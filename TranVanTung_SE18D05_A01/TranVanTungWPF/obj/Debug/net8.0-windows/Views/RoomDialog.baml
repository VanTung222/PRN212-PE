   M S B A M L   `   `   `  ����  TranVanTungWPF%    TranVanTungWPF.Views.RoomDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Room Information��5   	   $	��603��6"   $	��500��6/    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Room Information��6!   $��18(�69   $
��Bold"�6G   $��Center=�5      $��0,0,0,20q�60   �� 5   
   $��1��6   $��0,0,0,15q�6"   .+�5      �� $��Room Number:��6   $��SemiBold"�6,   $��0,0,0,5q�6B   �� 5      -   5         ��Name$ RoomNumberTextBox��5      $��30��61   $��5q�6=   5      �� 5   
   $��2��6   $��0,0,0,15q�6"   .+�5      �� $��Room Description:��6   $��SemiBold"�61   $��0,0,0,5q�6G   �� 5      -   5        $ RoomDescriptionTextBox��5      $��60��66   $��5q�6B    �� TextWrapping$
 Wrap=�5       �� AcceptsReturn$
 True��6)   5      �� 5!   
   $��3��6   $��0,0,0,15q�6"   .+�5"      �� $��Max Capacity:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   �� 5#      -   5        $ MaxCapacityTextBox��5#      $��30��62   $��5q�6>   5$      �� 5&   
   $��4��6   $��0,0,0,15q�6"   .+�5'      �� $��Price Per Date:��6   $��SemiBold"�6/   $��0,0,0,5q�6E   �� 5(      -   5        $ PriceTextBox��5(      $��30��6,   $��5q�68   5)      �� 5+   
   $��5��6   $��0,0,0,15q�6"   .+�5,      �� $��
Room Type:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5-      -   5         ��Name$ RoomTypeComboBox��5-      $��30��61    �� DisplayMemberPath$ RoomTypeName��5.      	 �� SelectedValuePath$	 
RoomTypeID��67   5/      �� 51   
   $��8��6   
 �� Orientation$
 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�52      �� -   5        $
��Save��52      $��80��6$   $��36��6/   $��0,0,10,0q�6;   
��� � �
�������53   :   �� 54      -   5        $��Cancel��54      $��80��6&   $��35��61   
�������
�������55   9   56      57      58      