   M S B A M L   `   `   `  ����C  ?Delivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Delivery.ViewsDelivery.Views  5      7 clr-namespace:Delivery.UtilitiesDelivery.Utilities  5      9!clr-namespace:Delivery.ViewModelsDelivery.ViewModels  5          Delivery.Views.DriverView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Delivery.Views     5      6	utilities clr-namespace:Delivery.Utilities     5      8
viewModels!clr-namespace:Delivery.ViewModels     5        � 	Resources  5      )   #Delivery.ViewModels.DriverViewModel   DriverViewModel+   %Delivery.Utilities.PhoneMaskConverter  PhoneMaskConverter)   #Delivery.Utilities.LettersConverter  LettersConverter*   $Delivery.Utilities.DateOnlyConverter  DateOnlyConverter-   'Delivery.Utilities.IntegerOnlyConverter  IntegerOnlyConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6%     5   
   6'     5   
   6%     5   
   6&     5   
   6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6   $	��300��6       AutoGenerateColumns$ False��6�      CanUserAddRows$ False��6�   ��6-   �� *	Drivers+ �� SelectedItem 6M   �� *SelectedDriver+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 69   �� *	FirstName+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� 	Converter#
 [   5      $ 	Last Name��6%    68   �� *
LastName+$	 PropertyChanged=�#
 [ 4
  .System.Windows.Controls.DataGridTemplateColumn
  5       $ Date of Birthday��6)    
  CellTemplate 5!      �� 5"      .R�5#      (  "System.Windows.Controls.DatePicker     DisplayDateStart 
1950-01-015$   %      DisplayDateEnd 
2099-12-315%   %      SelectedDateFormat$ Short=�5&   %      SelectedDate 5#   )   �� *DateOfBirthday+$	 PropertyChanged=�5&   %   5(      5*      
  5+      $ 
Experience��6)    5,      �� 5-      .R�5.      &    Delivery.Utilities.NumericUpDown     Value 66   �� *
Experience+$ TwoWay=�$	 PropertyChanged=�50      52        53      $ Phone Number��6%    6;   �� *PhoneNumber+$	 PropertyChanged=�#
 [ 
  55      $ Actions��6)    56      �� 57      .R�58      ��  �� Orientation$ 
Horizontal=�6)   .+�59   "   �� $��Update��6)   ��6:   �� *DataContext.UpdateCommand+ �� RelativeSource ��  �� AncestorType UserControl��6�   �� �� 5:   "   $��Delete��6)   ��6:   �� *DataContext.DeleteCommand+ ��  UserControl��6�   �� 5;      5<      5>      5@      �� 5A   
   $��1��6   .+�5B      �� $�� First Name:��6   �� 5C      ��6   �� *FormInput_FirstName+$	 PropertyChanged=�#
 [ �� 5E      $�� Last Name:��6   �� 5F      ��6   �� *FormInput_LastName+$	 PropertyChanged=�#
 [ �� 5H      $�� Date Of Birthday:��6     5I       
1950-01-015J   %    
2099-12-315K   %   $ Short=�5L   %    5I      �� *FormInput_DateOfBirthday+$	 PropertyChanged=�5L   %   �� 5O      $�� Experience:��6     5P       6&   �� *FormInput_Experience+$ TwoWay=�$	 PropertyChanged=��� 5S      $�� Phone Number:��6   �� 5T      ��6   �� *FormInput_PhoneNumber+$	 PropertyChanged=�#
 [ �� 5V      $��Create��6    � Cursor$
 Hand��6H   ��6&   �� *CreateCommand+6H   5W      5X      5Y      