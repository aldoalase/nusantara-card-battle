   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   �    FP PBD 2   FP_PBD_2.window_tracking   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      :Custom-http://schemas.microsoft.com/wpf/2008/toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  6?   [System_Windows_Forms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  6�   -   5          �Name$  Window��5       � Title$ window_tracking��5      $	��640��5	      $	��480��6   ��6   Z�  � 	Resources 5
         back_pegawai �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value  button_home_enter g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  button_home_leave  window_open��%�  &	        &	 �    &	 �    &	 �    �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� $ 	PsdLayer1��6   $#��button home_Images7\Image.png��6"   �� 5   	   #��z��6   #��z��6]   # z 6�   ��. 6�   5   	   	 5      P� 5   	   
 �@J�	IsFocused . 6&   P� 5   	   
 �@��IsDefaulted . 6(   P� 5   	   
 �@J�IsMouseOver . 6(   P� 5   	   
 � �� . 6&   P� 5   	   
 � {� .  6&   5      5      5      �� 5      .��5      U� $ 00:00:00X�6#   $ button��68   $ (UIElement.Opacity)�6W   .\�5       �� $ 00:00:00.5000000��6   $	 0.5Q�66   5!      5"      �� 5#      .��5$      U� $ 00:00:00X�6#   $ button��68   $ (UIElement.Opacity)�6W   .\�5%      �� $ 00:00:00��6   $ 0.495Q�6.   �� 5&      $ 00:00:00.5000000��6   $ 1Q�66   5'      5(      �� 5)      .��5*      U� $ 00:00:00X�6#   $ (UIElement.Opacity)�6Y    68   Z� .\�5+      �� $ 00:00:00��6   $ 0.495Q�6.   �� 5,      $ 00:00:00.5000000��6   $
 0.75Q�66   �� 5-      $ 00:00:01��6   $ 1Q�6.   5.      5/      50       � Triggers 51      :� 52       :� RoutedEvent$ Mouse.MouseEnter��6    :� 
SourceName$ button��60   .[�53      �� #��[ 6   54      :� 55      $ Mouse.MouseLeave��6   $ button��60   .[�56      �� -   5         ��Name$' !button_home_leave_BeginStoryboard��56      #��[ 6@   57      :� 58      $ FrameworkElement.Loaded��6   .[�59      �� #��[ 6   5:      .��5=      � -   5         �Name$ 
LayoutRoot��5=      $��0,0,-16.5,-31.5q�6   .+�5>      �� -   5        $ PsdLayer��5>   
   $&�� interface dasar_Images\Image.png��6   $#��-27.882,-23.562,-23.558,6.938q�6F   �� 5?      -   5        $ Shape_4��5?   
   $	��223��6   $��34.527��6'   $��logo_Images\Shape 4.png��67   $��Right=�6X   $��0,36.599,54.5,0q�6t   $	��Top=�6�   �� 5@      -   5         ��Name$ button_home��5@      $
��Left=�6    $	��Top=�6;   $
��1000��6S   $
��1000��6`   }�. .+�5A      �� -   5         ��Name$ button��5A      #���   6   $��50��6C   $��50��6N    �� Left$ 8��6Z   
 �� Top$ 32��6j   6z   5B      �� 5C      -   5        $ b_insert��5C   �   $��Right=�6   $��0,0,86.5,86.666q�6'   $��Bottom=�6@   $��79��6[   $��62.334��6f   $��insert��6v   6�   �� 5D      -	   5         ��Name$ idpengiriman��5D   w   $
��Left=�6   $��44.5,0,0,177.833q�6(   $��Bottom=�6B   $��152.5��6]   $��24��6k   6w   �� 5E      $
��Left=�6   $��44.5,0,0,201.833q�6)   $��Bottom=�6C   $��151.5��6^   $��17.667��6l   $��daftar kiriman��6|   $
��Wrap=�6�   �� 5F      $��48.5,0,0,150q�6   $��Bottom=�6$   $��17.667��6?   $��alat angkut��6O   $
��Wrap=�6b   $
��Left=�6v   $
��98.5��6�   �� 5G      -
   5        $ 
alatangkut��5G   J   $��44.5,0,0,125q�6   $��Bottom=�6#   $��24��6>   $
��Left=�6^   $��151.5��6y   7  1System.Windows.Forms.Integration.WindowsFormsHost  5H      $��46.5,92,81.5,233q�6      Child. 5I      '   !System.Windows.Forms.DataGridView  -   5        DataGridView��5I   '   5J      �� 5K      $��218.5,0,301.5,148.667q�6   $��Bottom=�6-   $��17.667��6H   $��lokasi��6X   $
��Wrap=�6f   �� 5L      $��0,0,228.5,146.667q�6   $��Bottom=�6)   $��17.667��6D   $��
keterangan��6T   $
��Wrap=�6f   $��Right=�6z   $
��76.5��6�   �� 5N      -   5         ��Name$ lokasi��5N   7   $��23��6   $��216.5,0,313.5,123.667q�6   $��Bottom=�6G   �� 6e   -   5         ��Name$ 
idtracking��5N   �   $��28��6k   $
��Left=�6w   $��46.5,68,0,0q�6�   $	��Top=�6�   $	��120��6�   $��Label��6�   �� 6�   -   5        $ tanggal��5N   5  $��28��6�   $��Right=�6  $��0,71,191.5,0q�6  $	��Top=�6F  $	��120��6^  $��Label��6j  �� 6|  -   5        $ 
keterangan��5N   �  $��23��6�  $��0,0,177.5,123.667q�6�  $��Bottom=�6�  $��Right=�6�  $��126.5��6�  �� 6  -   5        $ lihat��5N   M  $��21��6  $
��Left=�6  $��131,0,0,202.5q�66  $��Bottom=�6\  $��66��6w  $��lihat��6�  �� 6�  -   5        $ button1��5N   �  $��39��6�  $��239.5,0,262.5,69.667q�6�  $��Bottom=�6�  $��List Tracking Pegawai��6  �� 6=  -   5        $ tujuan��5N   f  $��28��6C  $��210,0,0,195.5q�6O  $��Bottom=�6v  $
��Left=�6�  $��111.5��6�  $��Tujuan Paket��6�  �� 6�  -   5        $ Layanan��5N      $��28��6�  $��325,0,211.5,195.5q�6�  $��Bottom=�6  $��Layanan Paket��6,  �� 6F  -   5        $ deadline��5N   �  $��28��6L  $��Right=�6X  $��0,0,86.5,195.5q�6t  $��Bottom=�6�  $	��120��6�  $��Deadline Pengiriman��6�   J� RenderTransformOrigin$ 
0.208,0.75&�6�  5O      5P      