   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   3clr-namespace:WpfApp.ViewModelWpfApp.ViewModel  5   	       WpfApp.CustomerManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   -vmclr-namespace:WpfApp.ViewModel     5   	     � Title$  CustomerManagement��5	   	   $	��500��5
   	   $	��900��5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#f0f4f8 � DataContext 5      2   ,WpfApp.ViewModel.CustomerManagementViewModel  5   
   .��5      � $��20q�6   .+�5   
   �� 
������� �� CornerRadius$ 10��5       �� Padding$ 20q�5      ���#ccc$��1q�5      $��Stretch=�5      $��Stretch=�5      ._�5      �  � RowDefinitions 5      �� 5      $��* �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   .+�5$      �� $��0��6   $��0,0,0,20q�5'      $	��220��5(      ��5%      �� *	Customers+ �� SelectedItem 5&      �� *SelectedCustomer+ �� Mode$ TwoWay=� �� View 5)      �� 5*      .P�5+      �� $��Customer ID��6-   	 �� Width$		 100��6n   
 �� DisplayMemberBinding
 6B   �� *
CustomerID+6n   �� 5,      $��Company Name��6-   $		 150��6p   
 6C   �� *CompanyName+6p   �� 5-      $��Contact Name��6-   $		 130��6p   
 6C   �� *ContactName+6p   �� 5.      $��Contact Title��6-   $		 130��6r   
 6D   �� *ContactTitle+6r   �� 5/      $��Address��6-   $		 150��6g   
 6>   �� *	Address+6g   �� 50      $��Phone��6-   $		 100��6c   
 6<   �� *Phone+6c   51      53      �� 55      $��1��6    �� Orientation$ 
Horizontal=�6*   $
��Left=�6C   $��0,0,0,15q�6^   .+�56      �� -   5        $
��Back��56      $��90��57      $��35��6(   $��0,0,10,0q�58      $
��Left=�5:      ���#cccccc
���   �5<      �� 5=      $��Add Customer��6   $	��120��5>      $��35��6)   $��0,0,10,0q�5?      ���#2ecc71
�������$
��Bold"�5B      ��5C      �� *
AddCommand+�� 5E      $��Update Customer��6   $	��120��5F      $��35��6)   $��0,0,10,0q�5G      ���#2980b9
�������$
��Bold"�5J      ��5K      �� *UpdateCommand+�� 5M      $��Remove Customer��6   $	��140��5N      $��35��6)   ���#c0392b
�������$
��Bold"�5Q      ��5R      �� *RemoveCommand+5S      �� 5U      $��2��6   $ 
Horizontal=�6*   $
��Left=�6C   .+�5V      �� $��Search by ID:��6   $��Center=�5W      $
��Bold"�5X      $��0,0,10,0q�5Y      �� 5[      $	��150��6   $��0,0,10,0q�5\      ��5]      �� *SearchCustomerId+ �� UpdateSourceTrigger$ PropertyChanged=��� 5_      $��Search��6   $��80��5`      $��30��6(   ���#f39c12
�������$
��Bold"�5c      ��5d      �� *SearchCommand+5e      5f      5g      5h      5i      