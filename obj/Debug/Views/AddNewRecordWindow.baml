   M S B A M L   `   `   `  ����  StolowkaSQL*    $StolowkaSQL.Views.AddNewRecordWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Dodaj nowy rekord��5   	   $	��240��6#   $	��300��60   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6    � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $
��Id: ��6!   �� 5   
   $��0��6   $��1��6   ��6/   �� *Id+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��Grupa: ��6!   �� 5   
   $��1��6   $��1��6     �� DisplayMemberPath$
 Opis��6R   ��60   �� *	grupyList+ �� SelectedItem 6k   �� *SelectedGroup+�� 5   
   $��2��6   $��	Pozycja: ��6!   �� 5   
   $��2��6   $��1��6   ��6/   �� *	Pozycja+$ PropertyChanged=��� 5   
   $��3��6   $��Nazwa potrawy: ��6!   �� 5   
   $��3��6   $��1��6   ��6/   �� *Nazwa+$ PropertyChanged=��� 5   
   $��4��6   $��0��6   $��Dodaj do bazy danych��6.   $��2��6M   ��6a   �� *
AddCommand+5      5      