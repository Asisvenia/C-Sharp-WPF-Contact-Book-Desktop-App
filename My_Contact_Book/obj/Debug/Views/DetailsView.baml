   M S B A M L   `   `   `  ����J  FMy_Contact_Book, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:My_Contact_Book.ViewsMy_Contact_Book.Views  5      '    !My_Contact_Book.Views.DetailsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:My_Contact_Book.Views     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5      �� $��0��6   $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6   $ 
Horizontal=�6:   .+�5      �� $��	ExtraBold"�6   $��Verdana)�63   $��16(�6H   $��Center=�5   >   ��5   V   �� *SelectedContact.Name+ �� FallbackValue$	 N/A�� �� TargetNullValue$	 N/A��y�5   [   �� *IsDisplayMode+   BoolToVisiblityConverter �� 	Converter# [  �� 5      -   5         ��Name$ nameBox��5      $��5q�6/   $	��160��6�   $��30��6�   $��Center=�6�   $��	ExtraBold"�5      $��Verdana)�65   $��16(�6J   y�5   :   �� *
IsEditMode+# [  ��5   X   �� *SelectedContact.Name+ �� Mode$ TwoWay=���5       ��  �� ElementName$ nameBox��	 �� Path$	 	IsFocused�  BoolToFocusConverter# [ .��6�   
 � 	Resources
 5!       �� 
TargetType �� Property �� Value��%^   '��       �� 5"      " ��6$   .�5#   "   ��  �@��CornerRadius$ 6��6A   5$      5%      .��6-   5&      �� 5(        FavouriteCheckbox#��[ 6K   $��Right=�5)      $��Center=�6;   $��10 2 0 0q�6V   ��5(      �� *UpdateFavouritesCommand+ d� 	IsChecked 6v   �� *SelectedContact.IsFavourite+$ TwoWay=�5)   V   5*      5+      � 5,      $	��110��6   $	��110��6   $
��Left=�6,   .+�5.      �� $	��110��6   $	��110��6$   ��61   �� *SelectedContact.ImagePath+  DefaultContactImg# [ # [ �� 53      $��Browse��6     	BrowseBtn#��[ 6*   $��Right=�54      $��Bottom=�65   y�53   M   �� *
IsEditMode+# [  ��55      �� *BrowseCommand+56      57      �� 5:   
   $��1��6   $ 
Horizontal=�6%   $��Bottom=�6>   $
��Left=�6Y   .+�5;      �� -   5         ��Name$ 	CancelBtn��5;       � Cursor$
 Hand��6(     CancelIconBtn#��[ 66   $
��Left=�5=      $��	-50 0 0 0q�60   y�5<      �� *
IsEditMode+# [  ��5=   C   �� *CancelEditingCommand+��5>      �� 5?      $ 
Horizontal=�6!   .+�5@      �� $6��0pack://siteoforigin:,,,/Resources/cancelIcon.png��6    $��33��6Z   $��33��6e   �� 5A      $��Center=�6    $��	ExtraBold"�6;   $��Cancel��6R   5B      5D      5E      �� 5G   
   $��1��6   $ 
Horizontal=�6%   $��Bottom=�6>   $��Center=�6Y   .+�5H      �� -   5        $ SaveBtn��5H      $
 Hand��6&     SaveIconBtn#��[ 64   y�5I      �� *
IsEditMode+# [  ��5J      �� *SaveCommand+��5K      �� 5L      $ 
Horizontal=�6!   .+�5M      �� $4��.pack://siteoforigin:,,,/Resources/saveIcon.png��6    �� 5N      $��Center=�6    $��	ExtraBold"�6;   $
��Save��6R   5O      5Q      5R      �� 5T   
   $��1��6   $��2��6"   $��4 8 1 1q�66   .+�5U      �� .+�5V      ��   DetailBorder#��[ 6   ._�5W      ��   
DetailHead#��[ 6   $��Phone Numbers:��6@   5X      �� 5Y      .+�5[      ��  	 DetailLabel#��[	 6   $��Home:��6A   �� 5\       
 DetailContent#��[
 6   ��6C   �� *!SelectedContact.PhoneNumbers[0]+$
 None��y�6�   �� *IsDisplayMode+# [  �� 5^      -   5        $ homeNum��5^        DetailBoxContent#��[ 6/   ��6Y   �� *!SelectedContact.PhoneNumbers[0]+y�5_      �� *
IsEditMode+# [  ��5`      �� $ homeNum��$	 	IsFocused�# [ �� 5b      #��[	 6   $��Cell:��6A   �� 5c      #��[
 6   ��6C   �� *!SelectedContact.PhoneNumbers[1]+$
 None��y�6�   �� *IsDisplayMode+# [  �� 5e      -   5        $ bussName��5e      #��[ 60   ��6Z   �� *!SelectedContact.PhoneNumbers[1]+$ TwoWay=�y�5f      �� *
IsEditMode+# [  ��5g      �� $ bussName��$	 	IsFocused�# [ 5h      5i      5j      �� 5l   
   $��2��6   $��2��6"   $��4 8 1 1q�66   .+�5m      �� .+�5n      �� #��[ 6   ._�5o      �� #��[ 6   $��E-Mail:��6@   5p      �� 5q      #��[
 6   ��6?   �� *SelectedContact.Mail+$
 None��y�6|   �� *IsDisplayMode+# [  �� 5s      -   5        $ mailBox��5s      #��[ 6+   $	��225��5t   q   $��5q�6}   ��5s   U   �� *SelectedContact.Mail+$ TwoWay=�y�5t      �� *
IsEditMode+# [  ��5u      �� $ mailBox��$	 	IsFocused�# [ �� 5w      #��[ 6   $��4 8 1 1q�6?   ._�5x      �� #��[ 6   $��Address:��6@   5y      �� 5z      #��[
 6   ��6?   �� *SelectedContact.Address+$
 None��y�6   �� *IsDisplayMode+# [  �� 5|      -   5        $ 
addressBox��5|      #��[ 6.   $	��225��5}   q   $��5q�6}   ��5|   X   �� *SelectedContact.Address+$ TwoWay=�y�5}      �� *
IsEditMode+# [  ��5~      �� $ 
addressBox��$	 	IsFocused�# [ 5      5�      5�      5�      