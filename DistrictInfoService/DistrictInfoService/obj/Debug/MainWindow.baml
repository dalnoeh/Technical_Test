   M S B A M L   `   `   `  ����N  JDistrictInfoService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DistrictInfoServiceDistrictInfoService  5   	   $    DistrictInfoService.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DistrictInfoService     5   	     � Title$  
MainWindow��5   	   $	��800��6   $	��600��6(   $��Segoe UI Light)�65   $��18(�6Q   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��District Info��6   $��26(�6)   $��0��67   $��0��6G   �� 5   
   $��	Districts��6   $��18(�6%   $��0��63   $��1��6C   �� 5!   
   -   5         ��Name$ districtListView��5!      $��0��6-   $��2��6=   ��5"      �� 5#      .R�5$      ��  �� TextAlignment$ Center=�66   ��6    �� *name+66   5%      5'      �� 5+   
   $��Stores��6   $��18(�6"   $��1��60   $��1��6@   $��	10,0,10,0q�6M   �� 5-   
   -   5        $ storeListView��5-      $��1��6*   $��2��6:   $��10,0,0,0q�6G   ��5.      �� 5/      .R�50      �� $ Center=�66   ��6    �� *name+66   51      53      �� 56   
   $��Responsible Salesman��6   $��18(�60   $��2��6>   $��1��6N   $��	10,0,10,0q�6[   �� 58   
   -   5        $! responsibleSalesmanListView��58      $��2��68   $��2��6H   $��10,0,0,0q�6U   ��59      �� 5:      .R�5;      �� $ Center=�66   ��6    �� *name+66   5<      5>      �� 5@   
   $!��Choose Responsible Salesman��6   $��18(�67   $��2��6E   $��3��6U   $��	10,0,10,0q�6b   �� 5B   
   -   5         ��Name$' !ChooseResponsibleSalesmanComboBox��5B      $��2��6>   $��4��6N   $��30��6[   $��10,0,0,0q�6j   $	��Top=�6|   ��5C      �� 5D      .R�5E      �� $ Center=�66   ��6    �� *name+66   5F      5H      �� 5K   
   $��Secondary Salesmen��6   $��18(�6.   $��3��6<   $��1��6L   $��
10,0,100,0q�6Y   �� 5M   
   -   5        $ secondarySalesmanListView��5M      $��3��66   $��2��6F   $��	10,0,10,0q�6S   $	��160��6f   $	��250��6u   $
��Left=�6�   ��5N      �� 5O      .R�5P      �� ��6    �� *name+5Q      5S      �� 5U   
   $��Available Salesmen��6   $��18(�6.   $��3��6<   $��3��6L   $��
10,0,100,0q�6Y   �� 5W   
   -   5        $ availableSalesmanListView��5W      $��3��66   $��4��6F   $��	10,0,10,0q�6S   $	��160��6f   $	��250��6u   $
��Left=�6�   ��5X      �� 5Y      .R�5Z      �� ��6    �� *name+5[      5]      5_      5`      