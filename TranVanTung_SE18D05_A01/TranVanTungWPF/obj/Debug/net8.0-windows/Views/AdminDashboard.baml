   M S B A M L   `   `   `  ����  TranVanTungWPF)    #TranVanTungWPF.Views.AdminDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$,  &Admin Dashboard - FU Mini Hotel System��5   	   $	��700��68   $
��1200��6E    � WindowStartupLocation$ CenterScreen=�5   	   
�������.��5      � .+�5   
   �� $��10q�6   .@�5      �� $��Customer Management��6   .��5	      � $��10q�6    � RowDefinitions 5
      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $
��Auto �6(   .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�6.   $��0,0,0,10q�6G   .+�5      �� $	��300��5   !   $��30��6-   $��5q�69   $��Center=�6E   ��5   "   �� *CustomerSearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5   E   �� 5      $��Search��6!   $��80��5       $��30��6+   $��10,0,0,0q�67   ��5   2   �� *SearchCustomersCommand+5   7   �� 5      $��Add Customer��6!   $	��100��5       $��30��6,   $��10,0,0,0q�68   
��� � �
���������5   8   �� *AddCustomerCommand+5   ]   �� 5      $��Edit Customer��6!   $	��100��5       $��30��6,   $��10,0,0,0q�68   
��� ���
���������5   9   �� *EditCustomerCommand+5   ^   �� 5      $��Delete Customer��6!   $	��110��5       $��30��6,   $��10,0,0,0q�68   
���  ��
���������5   ;   �� *DeleteCustomerCommand+5   [   5      &   System.Windows.Controls.DataGrid  5      $��1��6      AutoGenerateColumns$ False��5!         CanUserAddRows$ False��6:      
IsReadOnly$
 True��6Q   ��5   ,   �� *	Customers+ �� SelectedItem 5       �� *SelectedCustomer+	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
CustomerID+6\     5$      $
 	Full Name��61   $	 200 6i    6D   �� *CustomerFullName+6i     5%      $
 Email��61   $	 250 6a    6@   �� *EmailAddress+6a     5&      $
 	Telephone��61   $	 120 6b    6D   �� *	Telephone+6b     5'      $
 Birthday��61   $	 100 6�    6C   �� *CustomerBirthday+ �� StringFormat$ 
dd/MM/yyyy��6�   5)      5*      5+      �� 5-      $��Room Management��6   .��5.      � $��10q�6    5/      �� 50      $
��Auto �6(   �� 51      $��* �6(   �� 52      $
��Auto �6(   .+�56      �� $��0��6!   $ 
Horizontal=�6.   $��0,0,0,10q�6G   .+�57      �� $	��300��58   !   $��30��6-   $��5q�69   $��Center=�6E   ��57   "   �� *RoomSearchText+$ PropertyChanged=�58   E   �� 59      $��Search��6!   $��80��5:       $��30��6+   $��10,0,0,0q�67   ��59   2   �� *SearchRoomsCommand+5:   7   �� 5;      $��Add Room��6!   $	��100��5<       $��30��6,   $��10,0,0,0q�68   
��� � �
���������5;   4   �� *AddRoomCommand+5<   ]   �� 5=      $��	Edit Room��6!   $	��100��5>       $��30��6,   $��10,0,0,0q�68   
��� ���
���������5=   5   �� *EditRoomCommand+5>   ^   �� 5?      $��Delete Room��6!   $	��110��5@       $��30��6,   $��10,0,0,0q�68   
���  ��
���������5?   7   �� *DeleteRoomCommand+5@   [   5A        5D      
�������$��1��69   $ False��5F      $ False��6:   $
 True��6Q   ��5D   F   �� *Rooms+ 5E      �� *SelectedRoom+	 5G        5H      $
 ID��61   $ 50 6X    6=   �� *RoomID+6X     5I      $
 Room Number��61   $	 100 6e    6F   �� *
RoomNumber+6e     5J      $
 Description��61   $	 250 6j    6F   �� *RoomDescription+6j     5K      $
 Max Capacity��61   $	 100 6k    6G   �� *RoomMaxCapacity+6k     5L      $
 
Price/Date��61   $	 120 6z    6E   �� *RoomPricePerDate+$ C��6z     5M      $
 	Room Type��61   $	 120 6n    6D   �� *RoomType.RoomTypeName+6n   5O      5P      5Q      5R      5S      5T      