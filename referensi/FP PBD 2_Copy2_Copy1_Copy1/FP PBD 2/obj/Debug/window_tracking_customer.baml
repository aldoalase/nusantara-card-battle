   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5       FP PBD 2'   !FP_PBD_2.window_tracking_customer   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  5      Iwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  5      -   5          �Name$  Window��5       � Title$ window_tracking_customer��5      $	��700��5	      $	��480��6   
������� � 	Resources 5
         back_customer �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value  button_home_enter g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  button_home_leave  window_open��%�  &	        &	 �    &	 �    &	 �    �� 5      " ��6    .�5      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� $ 	PsdLayer1��6   $$��button home_Images10\Image.png��6"   �� 5   	   #��z��6   #��z��6]   # z 6�   ��. 6�   5   	   	 5      P� 5   	   
 �@J�	IsFocused . 6&   P� 5   	   
 �@��IsDefaulted . 6(   P� 5   	   
 �@J�IsMouseOver . 6(   P� 5   	   
 � �� . 6&   P� 5   	   
 � {� .  6&   5      5      5      �� 5      .��5      U� $ 00:00:00X�6#   $ button��68   $ (UIElement.Opacity)�6W   .\�5       �� $ 00:00:00.5000000��6   $	 0.5Q�66   5!      5"      �� 5#      .��5$      U� $ 00:00:00X�6#   $ button��68   $ (UIElement.Opacity)�6W   .\�5%      �� $ 00:00:00��6   $	 0.5Q�6.   �� 5&      $ 00:00:00.5000000��6   $ 1Q�66   5'      5(      �� 5)      .��5*      U� $ 00:00:00X�6#   $ (UIElement.Opacity)�6Y    68   Z� .\�5+      �� $ 00:00:00��6   $ 0.495Q�6.   �� 5,      $ 00:00:00.5000000��6   $ 0.745Q�66   �� 5-      $ 00:00:01��6   $ 1Q�6.   5.      5/      50       � Triggers 51      :� 52       :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ button��60   .[�53      �� #��[ 6   54      :� 55      $ Mouse.MouseLeave��6   $ button��60   .[�56      �� -   5         ��Name$' !button_home_leave_BeginStoryboard��56      #��[ 6@   57      :� 58      $ FrameworkElement.Loaded��6   .[�59      �� #��[ 6   5:      .��5=      � -   5         �Name$ 
LayoutRoot��5=      .+�5?   
   �� -   5        $ PsdLayer��5?      $&�� interface dasar_Images\Image.png��6"   $%��-77.179,-44.011,-63.679,-47.011q�6L   �� 5@      -   5        $ Shape_4��5@   
   $	��223��6   $��34.527��6'   $��logo_Images\Shape 4.png��67   $��Right=�6X   $��0,36.599,38,0q�6t   $	��Top=�6�   �� 5A      -   5        $��combo_paket��5A   k   $
��Left=�6   $��	30,96,0,0q�6(   $	��Top=�6;   $	��123��6S   $��24��6_   6k   �� 5B      $
��Left=�6   $��30,75.126,0,0q�6)   $	��Top=�6@   $��92��6X   $��20.874��6c   $��ID Pengiriman��6s   $
��Wrap=�6�   �� 5D      -   5         ��Name$ button_home��5D      }�. $��0,0,-382,-558q�64   .+�5E      �� -   5         ��Name$ button��5E      #���   6   $��50��6D   $��50��6O    �� Left$ 8��6[   
 �� Top$ 28��6k   6{   7  1System.Windows.Forms.Integration.WindowsFormsHost  6�   $��668.5��6�   $��273.5��6�   $ 2��6�   $	 137��6�      Child. 5F      '   !System.Windows.Forms.DataGridView  -	   5        DataGridView��5F      5G      5H      �� 6   -
   5        $��lihat��5H   O   $��23��6   $
��Left=�6    $��
158,96,0,0q�6;   $	��Top=�6\   $��54��6t   .��6�   lihat6�   �� 5I      -   5        $
��Left=�5I   	   $��
226,96,0,0q�6$   $	��Top=�68   $��77��6P   $��23��6[   $��report��6g   6x   5K      5L      