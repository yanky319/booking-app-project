   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   @ <WpfPL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfPL.windosWpfPL.windos 5   	      WpfPL.windos.Owner_screen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ,localclr-namespace:WpfPL.windos     5   	   -   5          �Name$  
HostWindow��5	   	    � Title$ Vications.com��5
   	    � 
ResizeMode$ NoResize=�6   $	��900��65    � WindowState$ 	Maximized=�6B   $��Segoe UI Semibold)�6Z      main#��[  6z   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      $
��1.6* �6   �� 5      $	��26* �6   .+�5   
   �� -   5         ��Name$ LBHost��5      $��1��6   $��Hosts��6-   $	��150��6=   $��22(�6J   
�������$��5,0,0,0q�6k   $
��Left=�6|   �� 5   
   -   5        $ LBunits��5      $��1��6   $��Hosting units��6.   $	��150��6F   $��22(�6S   ���	#FFC6C2C2$��80,0,0,0q�6x   $
��Left=�6�   �� 5   
   -   5        $ LBOrders��5   (   $��1��6   $��80��6   $��Orders��6:   $��22(�6M   ���	#FFC6C2C2$��	235,0,0,0q�6r   $
��Left=�6�   �� 5   
   -   5        $ 	LBrequsts��5   (   $��1��6   $��90��6   $��Requsts��6;   $��22(�6N   ���	#FFC6C2C2$��	335,0,0,0q�6s   $
��Left=�6�   �� 5   
   -   5        $ logout1��5      $��20(�6#    
 logout#��[ 61   $��2��6S   ���	#FFC6C2C2$��Right=�6�   $	��Top=�6�   $��1��6�   $��8��6�   $��1��6�   $��0,0,40,0q�6�   �� 5   
   -   5         ��Name$ 
tabControl��5   "   $��2��6   $��Stretch=�66   $��Stretch=�6T   $��0q�6p   $��LeftToRight=�6�   -   'MahApps.Metro.Controls.TabControlHelper   IsUnderlined .     UnderlineMouseOverBrush
 ��·�.@�5      �� -   5        	 ��Name$	 HostssMainGrid��5      $��0q�6/   #��[  6C   $	��Top=�6f   .��5      � $��Stretch=�6   #��[  65   $��-2,-2,-2,-12q�6X   
 � ColumnDefinitions
 5      �� 5      $
��713* �6+   �� 5      $	��49* �6+    5       �� 5!      $��70 �6(   �� 5"      $��* �6(   �� 5#      $��50 �6(   .+�5%      � -	   5         �Name$ hostsHeaderGrid��5%      $��2��64    5&      �� 5'      $��30 �6,   �� 5(      $��40 �6,   
 5*      �� 5+      $
��0.2* �6/   �� 5,      $��2* �6/   �� 5-      $
��1.6* �6/   �� 50      $
��0.5* �6/   �� 51      $��* �6/   �� 52      $��* �6/   �� 53      $��5* �6/   .+�58      �� -
   5         ��Name$ searchhostssLabel��58   !     searchLabel#��[ 6=   $��18(�6d   $��Center=�6r   
���   �$	��Top=�6�   $	��Top=�6�   $��Center=�6�   $��1��6�   $��26��6
  $��1q�6  $��87��6"  $��2��6-  $��1��6=  $��1��6R  �� 59      -   5        $ searchMesseg��59         searchMesseg#��[ 67   $
��Left=�6_   $��Center=�6z   $��1��6�   $��0��6�   $��2��6�   
�������6�   �� 5:      -   5        $��searchTextBox��5:   "   ���	#FFF1F1F1$��1��6P   
���   �$	��Top=�6t   $��Stretch=�6�   $��1��6�   $��1��6�    �� AcceptsReturn .  $��1q�6�   5;      &   System.Windows.Controls.DataGrid  5=      -   5          Name$ hostsDataGrid��5=      $��1��66      
IsReadOnly .   AlternatingRowBackground   AlternatingRowBackground# �  6V      AutoGenerateColumns .  $��LeftToRight=�6�   $��Center=�6�   $��2��6�      Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?       
 HostID,  &System.Windows.Controls.DataGridColumn   Header# �  61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *HostID+  5@        PrivateName# �  61    6X   �� *PrivateName+  5A        
FamilyName# �  61    6W   �� *
FamilyName+  5B        CollectionClearance# �  61    6`   �� *CollectionClearance+  5C       	 	numOrders# � 	 61    6V   �� *	numOrders+  5D       
 numUnits# � 
 61    6U   �� *
numUnits+  5E         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 62   4  .System.Windows.Controls.DataGridTemplateColumn  5F      $ 70 65      CellTemplate 5G   "   �� 5H   &   .R�5I   *   �� -   5          details#���  5I   2   #���   6V   6�   5J   '   5L      5N      � 5P      -   5        $ hostssEndingGrid��5P      $��2��65   5Q      5R      5S      �� 5U      -   5        $	 unitsMainGrid��5U      $��0q�6.   #���   6B   $	��Top=�6f   ���	#CCD5E3FF.��5W      � $��Stretch=�6   #��[  65   $��-2,-2,-2,-12q�6X    5Y      �� 5Z      $��70 �6(   �� 5[      $��* �6(   �� 5\      $��50 �6(   .+�5^      � -   5        $ unitsHeaderGrid��5^      $��2��64    5_      �� 5`      $��25 �6,   �� 5a      $��40 �6,   
 5c      �� 5d      $
��0.3* �6/   �� 5e      $��2* �6/   �� 5f      $��2* �6/   �� 5g      $��2* �6/   �� 5h      $��2* �6/   �� 5i      $��2* �6/   �� 5j      $
��2.2* �6/   �� 5k      $��3* �6/   �� 5l      $��5* �6/   .+�5q      �� -   5        $ ResetUnitFiltersLabel��5q   !   $��1q�6A     ResetFiltersLabel#��[ 6M   $��18(�6z   $
��Left=�6�   
���   �$	��Top=�6�   $��7��6�   $��1��6�   $	��133��6�   $��26��6�   $��	-20,2,0,0q�6  �� 5r      -   5        $ searchUnitsLabel��5r   #   #��[ 6>   $��18(�6e   $
��Left=�6s   
���   �$	��Top=�6�   $	��Top=�6�   $��Center=�6�   $��1��6�   $��26��6	  $��1q�6  $��87��6!  $��6��6,  $��1��6<  $��1��6Q  $��15,2,0,0q�6b  �� 5t      -   5        $ searchMesseg1��5t       
�������#��[ 6J   $��Bottom=�6r   $
��Left=�6�   $��4��6�   $��0��6�   $��2��6�   �� 5u      -   5        $��searchTextBox3��5u   %   ���	#FFF1F1F1$��4��6T   
���   �$	��Top=�6x   $��Stretch=�6�   $��1��6�   $��2��6�    .  $��1q�6�   �� 5w      -   5        $ 	AreaLabel��5w   "   
�������  Area#��[ 6I   $��1��6i   $��Bottom=�6y   $
��Left=�6�   $��0��6�   �� 5x      -   5         ��Name$ AreaComboBox��5x   #   $��1q�6:    �� SelectedIndex$ 0��6F   
���   �$��1��6m   $��1��6~   $	��Top=�6�   ���	#FFF1F1F16�   �� 5y      -   5        $ SubAreaLabel��5y       
�������$
��Left=�6K     SubArea#��[ 6m   $
��Left=�6�   $��Bottom=�6�   #���   6�   
���   �$��2��6  $��0��6  $��1��6"  $��Bottom=�66  �� 5z      -   5        $ SubAreaComboBox��5z   .   $��1q�6#   $��2��6G   ���	#FFF1F1F1 �� StaysOpenOnEdit .  
���   �$��1��6�   $	��Top=�6�   $��1��6�   6�   �� 5{      -   5        $ 	TypeLabel��5{   !   
�������  Type#��[ 6H   $
��Left=�6h   $��Bottom=�6�   $��3��6�   $��0��6�   �� 5|      -   5        $ TypeComboBox��5|   .   $��1q�6#   $��3��6D   ���	#FFF1F1F1
���   �$��1��6�   $	��Top=�6�   5~        5�      -   5        $ UnitsDataGrid��5�      $��1��66    . # �  6V    .  $��LeftToRight=�6�   $��Center=�6�   $��2��6�    5�        5�        HostingUnitKey# �  61    6[   �� *HostingUnitKey+  5�        HostingUnitName# �  61    6\   �� *HostingUnitName+  5�      # �  61    6Q   �� *Area+  5�      # �  61    6T   �� *	SubArea+  5�      # �  61    6Q   �� *Type+  5�        num_beds# �  61    6U   �� *
num_beds+  5�        accessibility# �  61    6Z   �� *accessibility+  5�       
 Garden# �  61    6S   �� *Garden+  5�        Pool# �  61    6Q   �� *Pool+  5�        Jacuzzi# �  61    6T   �� *	Jacuzzi+  5�        wifi# �  61    6Q   �� *wifi+  5�        ChildrensAttractions# �  61    6a   �� *ChildrensAttractions+  5�      $ * 62   5�      � 5�      -   5        $ unitsEndingGrid��5�      $��2��64   5�      5�      5�      �� 5�      -   5        $	 ordersMainGrid��5�      $��0q�60   #��[  6D   $	��Top=�6g   .��5�      � $��Stretch=�6   #��[  65   $��-2,-2,-2,-12q�6X   
 5�      �� 5�      $
��713* �6+   �� 5�      $	��49* �6+    5�      �� 5�      $��70 �6(   �� 5�      $��* �6(   �� 5�      $��50 �6(   .+�5�      � -   5        $ ordersHeaderGrid��5�      $��2��65    5�      �� 5�      $��30 �6,   �� 5�      $��40 �6,   
 5�      �� 5�      $
��0.3* �6/   �� 5�      $
��1.4* �6/   �� 5�      $��2* �6/   �� 5�      $��2* �6/   �� 5�      $
��2.6* �6/   �� 5�      $��6* �6/   .+�5�      �� -    5        $ ResetorderFiltersLabel��5�   !   $��1q�6B   #��[ 6N   $��18(�6{   $
��Left=�6�   
���   �$	��Top=�6�   $��8��6�   $��1��6�   $	��133��6�   $��26��6�   $��
-150,2,0,0q�6  �� 5�      -!   5        $ searchordersLabel��5�   #   #��[ 6?   $��18(�6f   $��Center=�6t   
���   �$	��Top=�6�   $	��Top=�6�   $��Center=�6�   $��1��6�   $��26��6  $��1q�6  $��87��6$  $��4��6/  $��1��6?  $��1��6T  $��
-170,2,0,0q�6e  �� 5�      -"   5        $ statusLabel��5�        
 status#��[ 66   $��1��6X   $��0��6h   
�������$��Bottom=�6�   $
��Left=�6�   �� 5�      -#   5        $ statusComboBox��5�   #   $
��Left=�6;   $��0,2,2,2q�6V   ���	#FFF1F1F1
���   �
���   �$��1��6�   $��1��6�   $	��Top=�6�   $��90��6�   �� 5�      -$   5        $ 	fromLabel��5�         	fromLabel#��[ 64   
�������$��Bottom=�6m   $
��Left=�6�   #���   6�   
���   �$��2��6�   $��0��6�   6�   (  "System.Windows.Controls.DatePicker  5�      -%   5          Name$ fromdatePicker��5�   %   $��25��6=   $��	-40,2,3,3q�6I   ���	#FFF1F1F1$��20(�6t   $��0q�6�   $��Center=�6�   $	��Top=�6�   $��2��6�   $��3��6   � 	Resources 5�      :	  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value��%�   '	        �� 5�   "   " 	 6(   .�5�   &   ��  � ��$ Select date��6=   �� 5�   &    � �� 6C   Z� �� 5�   &    � {� .  6B   �� 5�   &    � ��$ Segoe UI Semibold)�6C   5�   #   5�         CalendarStyle 5�      �� 5�   "     �� ResourceKey$  resizedCalendarItem��61   5�      �� 5�      -&   5        $ toLabel��5�         toLabel#��[ 62   
�������$��Bottom=�6i   $
��Left=�6�   $��3��6�   $��0��6�     5�      -'   5        $ todatePicker��5�   %   $��	-40,2,3,3q�6;   $��25��6N   ���	#FFF1F1F1$��20(�6q   $��3��6   $��2��6�   $��0q�6�   $��Center=�6�   $	��Top=�6�   $��Center=�5�   %    5�      ��%�   '	        �� 5�   "   " 	 6)   .�5�   &   ��  � ��$ Select date��6=   �� 5�   &    � ��$ 15(�6A   �� 5�   &    � ��$ Segoe UI Semibold)�6C   �� 5�   &    � �� 6C   Z� �� 5�   &    � {� .  6B   5�   #   5�       5�      �� 5�   "   $  resizedCalendarItem��61   5�      5�        5�      -(   5        $ ordersDataGrid��5�      $��1��67    . # �  6W    .  $��LeftToRight=�6�   $��Center=�6�   $��2��6�    5�        5�        OrderKey# �  61    6U   �� *
OrderKey+  5�      # �  61    6[   �� *HostingUnitKey+  5�        GuestRequestKey# �  61    6\   �� *GuestRequestKey+  5�       
 Status# �  61    6S   �� *Status+  5�        
CreateDate# �  61    6W   �� *
CreateDate+! �� StringFormat$! 
dd/MM/yyyy��  5�      $ * 62   5�      � 5�      -)   5        $ ordersEndingGrid��5�      $��2��65   6D   5�      5�      �� 5�      -*   5        $	 RequestsMainGrid��5�      $��0q�60   #��[  6D   $	��Top=�6g   .��5�      � $��Stretch=�6   #��[  65   $��-2,-2,-2,-12q�6X   
 5�      �� 5�      $
��713* �6+   �� 5�      $	��49* �6+    5�      �� 5�      $��70 �6(   �� 5�      $��* �6(   �� 5�      $��50 �6(   .+�5�      � -+   5        $ RequestHeaderGrid��5�      $��2��66    5�      �� 5�      $��30 �6,   �� 5�      $��40 �6,   
 5�      �� 5�      $
��0.2* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5�      $��* �6/   �� 5      $
��1.2* �6/   �� 5     $
��1.5* �6/   �� 5     $
��1.2* �6/   �� 5     $
��1.2* �6/   �� 5     $
��2.5* �6/   .+�5     �� -,   5        $ ResetRequestFiltersLabel��5  !   $��1q�6D   #��[ 6P   $��18(�6}   $
��Left=�6�   
���   �$	��Top=�6�   $��8��6�   $��1��6�   $	��133��6�   $��26��6�   $��
-150,2,0,0q�6	  �� 5	     --   5        $ searchRequestsLabel��5	  !   #��[ 6?   $��18(�6f   $
��Left=�6t   
���   �$	��Top=�6�   $	��Top=�6�   $��Center=�6�   $��1��6�   $��26��6
  $��1q�6  $��87��6"  $��6��6-  $��1��6=  $��1��6R  �� 5     -.   5        $ 
AreaLabel2��5      
�������#��[ 6H   $��1��6h   $��Bottom=�6x   $
��Left=�6�   $��0��6�   �� 5     -/   5        $ AreaComboBox2��5  #   $��1q�6;   $ 0��6G   
���   �$��1��6n   $��1��6   $	��Top=�6�   ���	#FFF1F1F16�   �� 5     -0   5        $ SubAreaLabel2��5      
�������$
��Left=�6M   #��[ 6o   $
��Left=�6�   $��Bottom=�6�   #���   6�   
���   �$��2��6  $��0��6  $��1��6$  $��Bottom=�68  �� 5     -1   5        $ SubAreaComboBox2��5  #   $��1q�6>   $ 0��6J   
���   �$��2��6q   $��1��6�   $	��Top=�6�   ���	#FFF1F1F16�   �� 5     -2   5        $ 
TypeLabel2��5      
�������#��[ 6H   $
��Left=�6h   $��Bottom=�6�   $��3��6�   $��0��6�   �� 5     -3   5        $ TypeComboBox2��5  #   $��1q�6;   $ 0��6G   
���   �$��3��6n   $��1��6   $	��Top=�6�   ���	#FFF1F1F16�   �� 5     -4   5        $ 
fromLabel2��5      #��[ 65   
�������$��Bottom=�6n   $
��Left=�6�   #���   6�   
���   �$��4��6�   $��0��6�   $��0q�6�   6    5     -5   5        $ fromdatePicker2��5  &   $��25��6@   $��3,1,3,3q�6L   ���	#FFF1F1F1$��20(�6u   $��0q�6�   $
��Left=�6�   $	��Top=�6�   $��4��6�   $��3��6   5     ��%�   '	        �� 5  "   " 	 6(   .�5  &   ��  � ��$ Select date��6=   �� 5  &    � �� 6C   Z� �� 5  &    � {� .  6B   �� 5  &    � ��$ Segoe UI Semibold)�6C   5  #   5      5     �� 5  "   $  resizedCalendarItem��61   5      �� 5"     -6   5        $ toLabel2��5"      #��[ 63   
�������$��Bottom=�6j   $
��Left=�6�   $��5��6�   $��0��6�     5#     -7   5        $ todatePicker2��5#  %   $��2,1,3,3q�6<   $��25��6M   ���	#FFF1F1F1$��20(�6p   $��5��6~   $��2��6�   $��0q�6�   $
��Left=�6�   $	��Top=�6�    5$     ��%�   '	        �� 5%  "   " 	 6)   .�5&  &   ��  � ��$ Select date��6=   �� 5'  &    � ��$ 15(�6A   �� 5(  &    � ��$ Segoe UI Semibold)�6C   �� 5)  &    � �� 6C   Z� �� 5*  &    � {� .  6B   5+  #   5,      5-     �� 5.  "   $  resizedCalendarItem��61   50     51       53     -8   5        $ RequestsDataGrid��53     $��1��69    . # �  6Y    .  $��LeftToRight=�6�   $��Center=�6�   $��2��6�    54       56     # �  61    6\   �� *GuestRequestKey+  57     # �  61    6S   �� *Status+  58     # �  61    6Q   �� *Area+  59     # �  61    6T   �� *	SubArea+  5:     # �  61    6Q   �� *Type+  5;        	EntryDate# �   61    6V   �� *	EntryDate+$! 
dd/MM/yyyy��  5<      ! ReleaseDate# � ! 61    6X   �� *ReleaseDate+$! 
dd/MM/yyyy��  5=     # �  61    6Z   �� *accessibility+  5>     # �  61    6S   �� *Garden+  5?     # �  61    6Q   �� *Pool+  5@     # �  61    6T   �� *	Jacuzzi+  5A     # �  61    6Q   �� *wifi+  5B     # �  61    6a   �� *ChildrensAttractions+  5C      	" Meals# � " 61    6R   �� *Meals+  5D      # specialMmeal# � # 61    6Y   �� *specialMmeal+  5E     $ * 62   5H     � 5J     -9   5        $ RequestndingGrid��5J     $��2��65   5L     5M     5N     5P     5Q     5R     