   M S B A M L   `   `   `  ����I  ESzinkronstudio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SzinkronstudioSzinkronstudio  5   	        Szinkronstudio.MovieWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Szinkronstudio     5   	     � Title$  Adatok megadása��5   	   $	��300��6!   $	��500��6.   $��16(�6:    � 
ResizeMode$ NoResize=�6H   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $��8 �6   .+�5   
   �� $��Azonosító:��6   $��0��6%   $��Center=�62   �� 5   
   $��Cím:��6   $��1��6   $��Center=�6,   �� 5   
   $��Kategória:��6   $��2��6%   $��Center=�62   �� 5   
   $��Hossz percben:��6   $��3��6)   $��Center=�66   �� 5   
   $��Szinkronrendező:��6   $��4��6+   $��Center=�68   �� 5   
   $"��Megjelenés Magyarországon:��6   $��5��65   $��Center=�6B   �� 5   
   -   5        $��txtId��5      $��1��6   $��0��6/   $��28��6<   $	��100��6H   $
��Left=�6T   ��5       �� *Id+�� 5!   
   $��1��6   $��1��6"   $��28��6/   ��5"      �� *Title+�� 5#   
   -   5        $��cboCategory��5#      $��1��6&   $��2��66   $��28��6C    �� SelectedValue 5$      �� *
CategoryId+�� 5%   
   $��1��6   $��3��6"   $��28��6/   $	��100��6;   $
��Left=�6G   ��5&      �� *Length+�� 5'   
   $��1��6   $��4��6"   $��28��6/   ��5(      �� *DubProducer+(  "System.Windows.Controls.DatePicker  5)   
   $��1��6   $��5��6%   $��28��62   $	��130��6>   $
��Left=�6J      SelectedDate 5*      �� *AnnouncedInHungary+� 5,   
   $��5q�6   $��6��6   $��3��6,   $��Center=�6@   $��Center=�6]   .+�5-      �� -   5        $��Mentés��5-      $	��120��6&   $��30��62   $��0 0 20 0q�6>   6P   �� 5.      -   5        $��Mégsem��5.      $	��120��6&   $��30��62   $��20 0 0 0q�6>   6P   5/      50      51      