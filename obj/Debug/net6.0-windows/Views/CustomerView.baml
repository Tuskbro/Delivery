   M S B A M L   `   `   `  ����C  ?Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Delivery.ViewsDelivery.Views  5      7 clr-namespace:Delivery.UtilitiesDelivery.Utilities  5	      9!clr-namespace:Delivery.ViewModelsDelivery.ViewModels  5
      !    Delivery.Views.CustomerView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Delivery.Views     5      6	utilities clr-namespace:Delivery.Utilities     5	      8
viewModels!clr-namespace:Delivery.ViewModels     5
        � 	Resources  5      (   "Delivery.ViewModels.CargoViewModel   CargoViewModel+   %Delivery.Utilities.PhoneMaskConverter  PhoneMaskConverter)   #Delivery.Utilities.LettersConverter  LettersConverter��%W   &	        &	      &	 &       5   
   6$     5   
   6'     5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6   $	��300��6       AutoGenerateColumns$ False��6�      CanUserAddRows$ False��6�   ��6-   �� *	Customers+ �� SelectedItem 6O   �� *SelectedCustomer+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	FirstName+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� 	Converter#
 [   5      $ 	Last Name��6%    68   �� *
LastName+$	 PropertyChanged=�#
 [ 4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Phone Number��6)      CellTemplate 5      �� 5      .R�5      �� ��6&   �� *PhoneNumber+$	 PropertyChanged=�#
 [ 5      5         5!      $ Actions��6)    5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6)   .+�5%   "   �� $��Update��6)   ��6:   �� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType UserControl��6�   �� �� 5&   "   $��Delete��6)   ��6:   �� *DataContext.DeleteCommand+ ��  UserControl��6�   �� 5'      5(      5*      5,      �� 5-   
   $��1��6   .+�5.      �� $�� First Name:��6   �� 5/      ��6   �� *FormInput_FirstName+$	 PropertyChanged=�#
 [ �� 51      $�� Last Name:��6   �� 52      ��6   �� *FormInput_LastName+$	 PropertyChanged=�#
 [ �� 54      $�� Phone Number:��6   �� 55      ��6   �� *FormInput_PhoneNumber+$	 PropertyChanged=�#
 [ �� 57      $��Create��6    � Cursor$
 Hand��6H   ��6&   �� *CreateCommand+6H   58      59      5:      