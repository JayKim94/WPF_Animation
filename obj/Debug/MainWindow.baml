   M S B A M L   `   `   `  ����]  YWPF_Animationen_Steinert_Simon_Kim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WPF_Animationen_Steinert_Simon_Kim"WPF_Animationen_Steinert_Simon_Kim  5   	   3    -WPF_Animationen_Steinert_Simon_Kim.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:WPF_Animationen_Steinert_Simon_Kim     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � SizeToContent$ WidthAndHeight=�5   	    � Title$ 	Animation��5   	   .��5      ]� .+�5   
   �� -   5         ��Name$ 	panelMenu��5      $
��Left=�5      $��0��5      ���#e09f3e � 	Resources 5       �� 
TargetType �� Property	 �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$
	 Bold"�63   �� 5       � ��$	 10 25q�6/   �� 5       � ��$	 Center=�6<   �� 5       � ��
	 �����63   �� 5       � ��$	 20(�61   5      5      .+�5      �� -   5        $ panelMenuButtons��5      $y�Hidden=�5      .+�5      �� -   5        
 ��Name$
 
btnStopuhr��5      ���#9e2a2b � Cursor$
 Hand��5!      ��5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6)   .+�5%   "   �� $��Stopuhr��6,   $��Center=�6;   5&      5'      5)      �� 5*      -   5        $
 	btnWecker��5*      ��5+      �� 5,      .R�5-      �� $ 
Horizontal=�6)   .+�5.   "   �� $��Wecker��6,   $��Center=�6:   5/      50      52      �� 53      -   5        $
 btnTimer��53      ��54      �� 55      .R�56      �� $ 
Horizontal=�6)   .+�57   "   �� $��Timer��6,   $��Center=�69   58      59      5;      5<      5=      �� 5?   
   .+�5A      ]� ���#e09f3e��.  .+�5D      �� -   5        $
 btnMenu��5D      ��5E      �� 5F      .R�5G      � .+�5H   "   �� $	��◀��6,   $��20(�5I   ,   ���#9e2a2b$
 Hand��5K   ,   $��10q�5L   ,   5M      5N      5P      �� 5Q      -   5        $
 btnExit��5S      $��Right=�5R      ��5T      �� 5U      .R�5V      � .+�5W   "   �� $��X��6,   $��20(�5X   ,   ���#9e2a2b$
 Hand��5Z   ,   $��Center=�5[   ,   $��Arial Black)�5\   ,   $��10q�5]   ,   5^      5_      5a      5b      �� 5d      -   5        $ timerBackground��5e      $	��300��5f      ���#9e2a2b 5g      ��%�   '��       �� 5h      " ��6   .�5i      ��  � ��
	 �����67   �� 5j       � ��$	 30(�65   �� 5k       � ��$	 Center=�6@   �� 5l       � ��$	 Center=�6>   5m      5n      .+�5o      �� -	   5         ��Name$ tblZeit��5o      $
��0.00��6-   $��	0 125 0 0q�69   �� 5p      $
��Sek.��6   $��12(�6(   5q      � 5s      -
   5         �Name$ buttonBackground��5t      $	��150��5u      $	��300��6   ���#e09f3e.+�5v      �� -   5        $	��100��5w      $	��100��6!   $��Starten��5x      $��20(�6'   $��Impact)�65   ���#ffffff��5{      �� 5|       �� 
TargetType" ��6*   .R�5}      � .+�5~   "   A� ���#9e2a2b6*   �� 5   "   $��Center=�5�   %   $��Center=�6B   5�      5�      5�      5�      5�      5�      5�      