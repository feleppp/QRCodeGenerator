   M S B A M L   `   `   `  ����  QRCodeGenerator     QRCodeGenerator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  
MainWindow��5      $	��450��6   $
��1050��6%    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ NoResize=�6j   .��5	      � -   5        .+�5
   
   � -   5         �Name$ DragGrid��5
   H   $	��Top=�6   $��26��6'   ���#1612546{   � 5   
   $	��Top=�6   $
��Left=�6'   $	��425��6B   $	��275��6O   $��0, 25, 0, 0q�6[   ���#161254.+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitionContentSlide��5   2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6R   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      � -   5        $ TransitionGrid��5      $	��Top=�6/   $��70��6G   $��10��6S   
�������$
��Left=�6q   $��0, 70q�6�   5      5      �� 5      -   5         ��Name$ ListViewMenu��5      $	��Top=�6Z   $��0, 70q�6r   .@�5      �� $��70��6   
�������.��5      �� $��15, 0q�6!   	 �� Orientation$	 
Horizontal=�60   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 
QrcodeEdit=�62   $��30��6D   $��30��6P   �� 5      $*��$Сгенерировать QR-код��6$   $��Center=�6@   $��10, 0q�6[   $��16(�6j   5      5      �� 5      $��70��6   
�������.��5      �� $��15, 0q�6!   $	 
Horizontal=�60   .+�5        $
 
QrcodeScan=�62   $��30��6D   $��30��6P   �� 5      $&�� Сканировать QR-код��6$   $��Center=�6>   $��10, 0q�6Y   $��16(�6h   5      5       �� 5"      $��70��6   
�������.��5#      �� $��15, 0q�6!   $	 
Horizontal=�60   .+�5$        $
 History=�62   $��30��6A   $��30��6M   �� 5%      $��История��6$   $��Center=�63   $��10, 0q�6N   $��16(�6]   5&      5'      �� 5)      -   5         ��Name$ LVUsers��5)      $��70��60   
�������.��5*      �� $��15, 0q�6!   $	 
Horizontal=�60   .+�5+        $

 User=�62   $��30��6>   $��30��6J   �� 5,      $��Пользователи��6$   $��Center=�68   $��10, 0q�6S   $��16(�6b   5-      5.      50      51      � 53   
   -   5        $ GridContent��53      $��Bottom=�6$   $��Right=�6?   $��	0,0,10,10q�6[   $	��754��6n   $	��400��6z   55      �� 57   
   -   5         ��Name$ BtnClose��57   U   $	��Top=�6   $��Right=�6)    � ToolTip$ Close��6E    *  &MaterialDesignFloatingActionMiniButton#��[  6g   
�������$��25��6�   $��25��6�   ��6�   Z� .��58        $
 Close=�6&   
�������63   59      5;      5<      