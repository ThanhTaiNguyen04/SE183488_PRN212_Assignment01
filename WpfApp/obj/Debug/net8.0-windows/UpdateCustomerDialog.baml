   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   !    WpfApp.UpdateCustomerDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  Update Customer��5   	   $	��500��5	   	   $	��550��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#f0f4f8.��5      � .+�5   
   �� 
������� �� Padding$ 30q�5       �� CornerRadius$ 10��5      ���#ccc$��1q�5      $��Center=�5      $��Center=�5      $	��480��5      ._�5      �� .+�5      �� $��Update Customer��6   $��20(�5      $
��Bold"�5      ���#2c3e50$��Center=�5      $��0,0,0,20q�5      �� 5"      .+�5#      ��  �� Orientation$ 
Horizontal=�6!   $	��0,5q�6:   .+�5$      �� $��Mã khách hàng:��6    $	��140��69   $��Center=�6E   �� 5%      -   5         ��Name$ txtCustomerID��5%   "   $	��275��5&   "    �� 
IsReadOnly$
 True��5'   "   ���#e0e0e0���#5555)   "   5*      �� 5,      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5-      �� $��Tên công ty:��6    $	��140��67   $��Center=�6C   �� 5.      -   5        $ 
txtCompany��5.   "   $	��275��66   5/      �� 51      $ 
Horizontal=�6!   $	��0,5q�6:   .+�52      �� $��Tên liên lạc:��6    $	��140��68   $��Center=�6D   �� 53      -   5        $ txtContactName��53   "   $	��275��6:   54      �� 56      $ 
Horizontal=�6!   $	��0,5q�6:   .+�57      �� $��Tiêu đề liên lạc:��6    $	��140��6<   $��Center=�6H   �� 58      -   5        $ txtContactTitle��58   "   $	��275��6;   59      �� 5;      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5<      �� $��Địa chỉ:��6    $	��140��63   $��Center=�6?   �� 5=      -   5        $ 
txtAddress��5=   "   $	��275��66   5>      �� 5@      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5A      �� $��Số điện thoại:��6    $	��140��69   $��Center=�6E   �� 5B      -   5        $ txtPhone��5B   "   $	��275��64   5C      5D      �� 5G      $ 
Horizontal=�6   $��Center=�5H      $��0,30,0,0q�5I      .+�5J      �� -   5         ��Name$ btnSave��5J      $
��Save��5K      $	��110��5L      $��38��5M      $��0,0,20,0q�5N      ���#27ae60
�������$
��Bold"�5Q      5R      �� 5T      -   5        $ 	btnCancel��5T      $��Cancel��5U      $	��110��5V      $��38��5W      ���#c0392b
�������$
��Bold"�5Z      5[      5\      5]      5^      5_      5`      