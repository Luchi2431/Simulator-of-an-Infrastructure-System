   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ViewsNetworkService.Views  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      ;"clr-namespace:NetworkService.ModelNetworkService.Model  5      /    )NetworkService.Views.MeasurementGraphView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NetworkService.Views     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      3data"clr-namespace:NetworkService.Model     5        � 	Resources  5         RoundedButtonTemplate �� 
TargetType ��Name �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%Q  &	        �� 5   
   " ��5      .R�5      �� $ buttonBorder��5      $ 3��5      #��z��5      #��z��5      #��z��5      ._�5      �� $��Center=�5      $��Center=�5      5       5      P� 5       �@J�IsMouseOver . . �5      �� $ buttonBorder��5       � ��
	 ��ح�5       5!      P� 5"       � {� .  . �5%      �� $ buttonBorder��5&       � ��
	 �����5(      �� 5)      $ buttonBorder��5*       � ��
	 �����5,      �� 5-       �@J�Opacity$		 0.5Q�5/      50      52      53      .��55      � .+�56   
   �� $
��Left=�6   
�������$��512,436,0,215q�6�   $	��145��6�   ��6@   �� *ComboBoxItems+
 �� SelectedItem
 6f   �� *SelectedEntity+ �� Mode$ TwoWay=�6�   � 57   
   $��Center=�6   $
��Left=�6*   .+�58      A�  A� Rows$ 11��6    A� Columns$ 1��6$   $
��Left=�60   $��10,-16,0,-16q�6K   .+�59      �� $	��500��6   
�������$��Center=�6=   $
��Left=�6X   �� 5:      $	��450��6   
�������$��Center=�6=   $
��Left=�6X   �� 5;      $	��400��6   
�������$��Center=�6=   $
��Left=�6X   �� 5<      $	��350��6   
�������$��Center=�6=   $
��Left=�6X   �� 5=      $	��300��6   
�������$��Center=�6=   $
��Left=�6X   �� 5>      $	��250��6   
�������$��Center=�6=   $
��Left=�6X   �� 5?      $	��200��6   
�������$��Center=�6=   $
��Left=�6X   �� 5@      $	��150��6   
�������$��Center=�6=   $
��Left=�6X   �� 5A      $	��100��6   
�������$��Center=�6=   $
��Left=�6X   �� 5B      $��50��6   
�������$��Center=�6<   $
��Left=�6W   �� 5C      $��0��6   
�������$��Center=�6;   $
��Left=�6V   5D      �� 5E      $	��350��6   $	��500��6!   
������ $
��Left=�6G   $��60,0,0,0q�6b   .+�5F      �� 	 �� X1$ 0��6   	 �� Y1$	 500��6   	 �� X2$	 350��6'   	 �� Y2$	 500��60   
�������$��3��6K   �� 5H       �� Left$ 19��6   $��30��6-    �� Bottom$ 0��6   ��68   �� 8   2NetworkService.ViewModel.MeasurementGraphViewModel   ElementHeights �� Source# Z  �� Path$ Height1���6�   �� # Z $ Fill1�6   �� 5I      $ 81��6   $��30��6-   $ 0��6   ��68   �� # Z $ Height2���6�   �� # Z $ Fill2�6   �� 5J      $	 143��6   $��30��6.   $ 0��6  ��69   �� # Z $ Height3���6�   �� # Z $ Fill3�6  �� 5K      $	 205��6   $��30��6.   $ 0��6  ��69   �� # Z $ Height4���6�   �� # Z $ Fill4�6  �� 5L      $	 267��6   $��30��6.   $ 0��6  ��69   �� # Z $ Height5���6�   �� # Z $ Fill5�6  5M      5N      �� 5O   
   $��Prikaži��6   $��30��5Q      $	��145��5R      $
��Left=�5S      $	��Top=�5T      ���#fff���#1E1F22
���   �$��512,348,0,0q�5X      #��[  5Y      ��5P      �� *ShowCommand+5Y      �� 5Z   
   $��	81,0,0,69q�6    �� Orientation$ 
Horizontal=�6(   $��Bottom=�6A   $
��Left=�6\   .+�5[      �� $
��Left=�6   $��T1��63   
�������$
��Bold"�6S   �� 5\      $��T2��6   $��50 0 0 0q�6"   
�������$
��Bold"�6J   �� 5]      $��T3��6   $��50 0 0 0q�6"   
�������$
��Bold"�6J   �� 5^      $��T4��6   $��50 0 0 0q�6"   
�������$
��Bold"�6J   �� 5_      $��T5��6   $��50 0 0 0q�6"   
�������$
��Bold"�6J   5`      5a      5b      