   M S B A M L   `   `   `  ����  TranVanTungWPF,    &TranVanTungWPF.Views.CustomerDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Customer Dashboard - FU Mini Hotel System��5   	   $	��500��6;   $	��800��6H    � WindowStartupLocation$ CenterScreen=�5   	   ���#F4F6FB.��5      � $��0q�6   .+�5   
   �� 
������� �� CornerRadius$ 16��6'    �� Padding$ 30q�69   $��30q�6F      DropShadowEffect J� Effect# �   5      ._�5	      �  � RowDefinitions 5
      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0��6   $��0,0,0,20q�6*   .+�5      �� $��28(�5       $
��Bold"�6.   ���#6B73FF$��0,0,0,5q�6U   ��5       �� *Customer.CustomerFullName+ �� StringFormat$ Welcome, {0}!��5   U   �� 5      $��Customer Dashboard��6    $��16(�6:   
�������6H   5      �� 5      $��1��6   
������ $��0q�6C   .@�5      �� $��Profile��6   .��5      �� ���#F8FAFF$ 10��66   $ 20q�6H   ._�5      �  5   "   �� 5   &   $
��Auto �64   �� 5   &   $
��Auto �64   �� 5   &   $
��Auto �64   �� 5   &   $
��Auto �64   �� 5    &   $
��Auto �64   �� 5!   &   $��* �64    � ColumnDefinitions 5#   "   �� 5$   &   $	��150 �67   �� 5%   &   $��* �67   .+�5(   "   �� $��0��6,   $��0��69   $��
Full Name:��6I   $��SemiBold"�6[   $��0,0,0,10q�6q   �� 5)   "   $��0��6,   $��1��69   $��0,0,0,10q�6t   ��6I   �� *Customer.CustomerFullName+6t   �� 5+   "   $��1��6,   $��0��69   $��Email:��6I   $��SemiBold"�6W   $��0,0,0,10q�6m   �� 5,   "   $��1��6,   $��1��69   $��0,0,0,10q�6p   ��6I   �� *Customer.EmailAddress+6p   �� 5.   "   $��2��6,   $��0��69   $��
Telephone:��6I   $��SemiBold"�6[   $��0,0,0,10q�6q   �� 5/   "   $��2��6,   $��1��69   $��0,0,0,10q�6m   ��6I   �� *Customer.Telephone+6m   �� 51   "   $��3��6,   $��0��69   $��	Birthday:��6I   $��SemiBold"�6Z   $��0,0,0,10q�6p   �� 52   "   $��3��6,   $��1��69   $��0,0,0,10q�6�   ��6I   �� *Customer.CustomerBirthday+$ 
dd/MM/yyyy��6�   �� 54   "   $��5��6)   $��0��66   $��Update Profile��6F   $	��140��56   )   $��38��65   $
��Left=�6A   ���#6B73FF
�������$��0,20,0,0q�57   Q   $��SemiBold"�58   )   $��0q�6?    � Cursor$
 Hand��6S   ��55   )   �� *UpdateProfileCommand+58   S   59      5:      5;      �� 5=      $��Booking History��6   .��5>      �� ���#F8FAFF$ 10��66   $ 20q�6H   ._�5?      �� $7��1Booking history feature will be implemented here.��6(   $��16(�5@   (   $��Center=�66   $��Center=�6S   
�������5A   (   5B      5C      5D      5E      5F      5G      	 � 	Resources	 5H      3  -System.Windows.Media.Effects.DropShadowEffect
   
BlurRadius   ShadowDepth   Color��%H   &	          5I   
   $
 16Q�64   $ 0Q�6D   $ 	#33000000��6T   5J      5K      