   M S B A M L   `   `   `  ����  TranVanTungWPF&     TranVanTungWPF.Views.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  FU Mini Hotel System - Login��5   
   $	��600��6/   $	��450��6<    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   ���	#FFF5F7FA.��5      � ��5   
   �� 5	       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5
      �  � Color$ 	#FF6B73FF��6    � Offset$ 0Q�61   � 5      $ 	#FF9DD5FF��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� 
������� �� CornerRadius$ 10��6$   $��50q�66   
�������$��1q�6Z   ._�5      �� $��40q�6   $��Center=�6%   .+�5      �� $��FU Mini Hotel System��6   $��26(�68   $
��Bold"�6F   
����  �5      �� 5      
�������$ 35��6,   $��70��6>   $��70��6I   $��0,0,0,20q�6U   ._�5      �� $
��🏨��6    $��35(�6*   $��Center=�68   $��Center=�5   '   ���	#FF4A90E26B   5      �� 5      $��Email:��6   $��SemiBold"�6*   $��0,0,0,5q�6@   �� 5      -   5        	 ��Name$	 EmailTextBox��5      $��35��5       $
��10,8q�6&   $��14(�65   $��0,0,0,15q�6C   ��5   0   �� *Email+
 �� UpdateSourceTrigger$
 PropertyChanged=�5    C   �� 5"      $��	Password:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   G� 5#      -   5         G�Name$ PasswordBox��5#      $��35��63   $
��10,8q�6?   $��14(�6N   $��0,0,0,20q�5$   K   �� 5&      $��Login��6   $��40��6)   $��16(�65   $��SemiBold"�6C   ���	#FF6B73FF
�������$��0q�5'   C   $��0,0,0,15q�5)      ��5(      �� *LoginCommand+��6:   ��  �� RelativeSource ��  �� AncestorType
 Window��5*      �� 5+       �� 
TargetType" ��6    .�5,      ��  �� Property � �� �� Value 5-   "   �� 5.   &    �� 
TargetType" ��66   .R�5/   *   �� #��z��61   $ 5��50   1   #��z��6B   ._�51   .   �� $��Center=�6?   $��Center=�6\   52   +   53   '   55       �� Triggers 56      P� 57   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �58   &   ��  � �� �	#FF5A64E66C   59   #   5;      5=      �� 5?      
���  ��$��Center=�6K   $��0,0,0,15q�5A      ��5?      �� *ErrorMessage+y�5@      �� *ErrorMessage+   StringToVisibilityConverter �� 	Converter# [  5A      �� 5C       �� Orientation$ 
Horizontal=�6   $��Center=�66   $��0,20,0,0q�6S   5D      5E      5F      5H      5I      