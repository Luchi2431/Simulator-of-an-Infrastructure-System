   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	       NetworkService.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   4views"clr-namespace:NetworkService.Views     5   	   =
viewModels&clr-namespace:NetworkService.ViewModel     5   	   $	��800��5
   	   $
��1400��6     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   
���iii� � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType7   1NetworkService.ViewModel.NetworkEntitiesViewModel.   (NetworkService.Views.NetworkEntitiesView6   0NetworkService.ViewModel.NetworkDisplayViewModel-   'NetworkService.Views.NetworkDisplayView8   2NetworkService.ViewModel.MeasurementGraphViewModel/   )NetworkService.Views.MeasurementGraphView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5!      �  � ColumnDefinitions 5"   
   �� 5#      $��1* �6   �� 5$      $��1* �6   .+�5&   
   � $��0��6    � RowDefinitions 5'      �� 5(      $
��Auto �6    �� 5)      $��* �6    .+�5,      �� ���#000$��	0 20 0 10q�5.      $��Network Display��5/      $
��Bold"�50      $��24(�51      $��Italic$�52      $��Center=�53      �� 54      $��1��55      $��10q�57      ��56      �� *AlwaysOnViewModel+57      58      � 5:   
   $��1��6    5;      �� 5<      $
��Auto �6    �� 5=      $��* �6    .+�5@      ]� $��0��5A      $��
150 20 0 0q�5B      .+�5C      o� $��Trebuchet MS)�5D      $	��Top=�5E      $
��Left=�5F      
���iii�.@�5I      m�  � Cursor$
 Hand��5J       � ToolTip$ Go to Network Entities��5K      $��0 0 20 0q�5L      $��50��5M      	 m� CommandParameter$	 
1_Entities��5O      $��0q�5P      
 m� Command
 5N      �� *
NavCommand+��5Q      �� 5R      ���#C0C0C0$��50��5T   !   $	��220��5U   !    J� Clip 5V   "   �� 5W   &    �� RadiusX$ 8Q�5X   )    �� RadiusY$ 8Q�5Y   )    �� Rect$ 
0,0,220,50�5Z   )   ._�5\   "   �� ���#000$��20(�5^   %   $
��Bold"�5_   %   $��Network Entities��5`   %    �� TextAlignment$ Center=�5a   %   $��Center=�5b   %   $��Center=�5c   %   5d      5f      m� 5g      $
 Hand��5h      $ Go to Measurement Graph��5i      $��50��5j      $	 2_Graph��5l      $��0q�5m      
 5k      �� *
NavCommand+��5n      �� 5o      ���#C0C0C0$��50��5q   !   $	��220��5r   !    5s   "   �� 5t   &   $ 8Q�5u   )   $ 8Q�5v   )   $ 
0,0,220,50�5w   )   ._�5y   "   �� ���#000$��20(�5{   %   $
��Bold"�5|   %   $��Measurement Graph��5}   %   $ Center=�5~   %   $��Center=�5   %   $��Center=�5�   %   5�      5�      5�      5�      � 5�      $��1��6   .+�5�      �� $��10q�5�      ��5�      �� *CurrentViewModel+5�      5�      5�      5�      5�      