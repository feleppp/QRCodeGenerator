   M S B A M L   `   `   `  ����  QRCodeGenerator)    #QRCodeGenerator.AuthorizationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  AuthorizationWindow��5      $	��300��6!   $	��300��6.    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$
 None=�6_    � 
ResizeMode$ NoResize=�6r   .��5	      � .+�5
   
   � -   5         �Name$ DragGrid��5
   H   $	��Top=�6   $��25��6'   ���#1612546{   �� 5   
   -   5         ��Name$ BtnClose��5   U   $	��Top=�6   $��Right=�6)    � ToolTip$ Close��6E    *  &MaterialDesignFloatingActionMiniButton#��[  6g   
�������$��25��6�   $��25��6�   ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6&   
�������63   5      �� 5   
   $��Center=�6   .+�5      �� -   5         ��Name$ textBoxLogin��5      $��25, 15q�6,   $��16(�6<   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 
Логин��6J   �� 5      -   5        $ textBoxPassword��5      $��25, 15q�6/   $��16(�6@   $	 Пароль��6N   �� 5      -   5        $ BtnAuthorization��5      $��40��6N   $	��200��6Z   $��0, 15, 0, 0q�6g   ���#161254���#161254.��5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5        $ Login=�6.   $��0, 0, 10, 0q�6;   $��25��6P   $��25��6[   6i   �� 5      $"��Авторизоваться��6    $��Center=�66   $��16(�6Q   6a   5      5      5      5      5      