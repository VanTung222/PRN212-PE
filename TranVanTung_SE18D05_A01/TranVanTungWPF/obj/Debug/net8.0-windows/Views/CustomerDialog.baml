   M S B A M L   `   `   `  ����  TranVanTungWPF)    #TranVanTungWPF.Views.CustomerDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Customer Information��5   	   $	��557��6&   $	��500��63    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Customer Information��6!   $��18(�6=   $
��Bold"�6K   $��Center=�5      $��0,0,0,20q�60   �� 5   
   $��1��6   $��0,0,0,15q�6"   .+�5      �� $��
Full Name:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5      -   5         ��Name$ FullNameTextBox��5      $��30��6/   $��5q�6;   5      �� 5   
   $��2��6   $��0,0,0,15q�6"   .+�5      �� $��Email Address:��6   $��SemiBold"�6.   $��0,0,0,5q�6D   �� 5      -   5        $ EmailTextBox��5      $��30��6,   $��5q�68   5      �� 5   
   $��3��6   $��0,0,0,15q�6"   .+�5       �� $��
Telephone:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5!      -   5        $ TelephoneTextBox��5!      $��30��60   $��5q�6<   5"      �� 5$   
   $��4��6   $��0,0,0,15q�6"   .+�5%      �� $��	Birthday:��6   $��SemiBold"�6)   $��0,0,0,5q�6?   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$ BirthdayDatePicker��5&      $��30��65   5'      �� 5)   
   $��5��6   $��0,0,0,15q�6"   .+�5*      �� $��	Password:��6   $��SemiBold"�6)   $��0,0,0,5q�6?   G� 5+      -   5         G�Name$ PasswordBox��5+      $��30��6/   $��5q�6;   5,      �� 5.   
   $��7��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5/      �� -   5        $
��Save��5/      $��80��6$   $��35��6/   $��0,0,10,0q�6;   
��� � �
�������50   :   �� 51      -   5        $��Cancel��51      $��80��6&   $��35��61   
�������
�������52   9   53      54      55      