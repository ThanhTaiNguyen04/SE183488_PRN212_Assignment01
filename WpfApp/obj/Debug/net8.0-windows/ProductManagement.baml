   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfApp.ViewModelWpfApp.ViewModel  5   	   5clr-namespace:WpfApp.ConvertersWpfApp.Converters  5   	       WpfApp.ProductManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -vmclr-namespace:WpfApp.ViewModel     5   	   0convclr-namespace:WpfApp.Converters     5   	     � Title$  Product Management��5   	   $	��600��5   	   $
��1000��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   ���#f4f7fa � DataContext 5      1   +WpfApp.ViewModel.ProductManagementViewModel  5   
    � 	Resources 5      >   8WpfApp.Converters.StringNullOrEmptyToVisibilityConverter *  &StringNullOrEmptyToVisibilityConverter��%   &	          5   
   66   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Product Management��6   $��24(�5      $
��Bold"�5      ���#2c3e50$��0,0,0,10q�5       $��Center=�5!      �� 5$   
   $��1��6   
������� �� CornerRadius$ 8��5&       �� Padding$ 10q�5'      ���#d0d7de$��1q�5)      ._�5*      �� ��6   �� *
Products+ �� SelectedItem 5+      �� *SelectedProduct+ �� Mode$ TwoWay=�	 �� View	 5,      �� 5-      .P�5.      �� $��	ProductID��6)   
 �� Width$
 80��6g    �� DisplayMemberBinding 6<   �� *	ProductID+6g   �� 5/      $��ProductName��6)   $	
 120��6k    6>   �� *ProductName+6k   �� 50      $��
SupplierID��6)   $
 80��6i    6=   �� *
SupplierID+6i   �� 51      $��
CategoryID��6)   $
 80��6i    6=   �� *
CategoryID+6i   �� 52      $��Quantity/Unit��6)   $	
 100��6q    6@   �� *QuantityPerUnit+6q   �� 53      $��
Unit Price��6)   $
 80��6h    6=   �� *	UnitPrice+6h   �� 54      $��In Stock��6)   $
 70��6i    6;   �� *UnitsInStock+6i   �� 55      $��On Order��6)   $
 80��6i    6;   �� *UnitsOnOrder+6i   �� 56      $��Reorder Level��6)   $	
 100��6n    6@   �� *ReorderLevel+6n   �� 57      $��Discontinued��6)   $
 90��6m    6?   �� *Discontinued+6m   58      5:      5;      �� 5>   
   $��2��6    �� Orientation$ 
Horizontal=�5?      $��0,15,0,0q�5@      $��Center=�5A      $��Center=�5B      .+�5D      �� $��Add Product��6   $	��120��5E      $��35��5F      ���#2980b9
�������$
��Bold"�5I      $	��5,0q�5J      ��5K      �� *
AddCommand+�� 5M      $��Update Product��6   $	��120��5N      $��35��5O      ���#f39c12
�������$
��Bold"�5R      $	��5,0q�5S      ��5T      �� *UpdateCommand+�� 5V      $��Remove Product��6   $	��120��5W      $��35��5X      ���#e74c3c
�������$
��Bold"�5[      $	��5,0q�5\      ��5]      �� *RemoveCommand+� 5_      .+�5`      �� -   5         ��Name$ txtSearchProduct��5e      $	��150��5`      $��30��5a      $	��5,0q�5b      $��Center=�5c      ��5d      �� *SearchProductId+ �� UpdateSourceTrigger$ PropertyChanged=�5e      �� 5f      $#��Enter Product ID to search...��6   
�������$��10,0,0,0q�5h      $��Center=�5i       J� IsHitTestVisible$ False��5j      y�5k      �� *Text+ �� ElementName$ txtSearchProduct�� �� 	Converter# [  5l      �� 5n      $��Search��6   $��80��5o      $��30��5p      $	��5,0q�5q      ���#27ae60
���������5t      �� *SearchCommand+�� 5v      -   5        $
��Back��5v      $��90��6$   $��35��6/   $	��5,0q�6;   ���#cccccc
���   �$
��Bold"�6p   6�   5w      5x      5y      