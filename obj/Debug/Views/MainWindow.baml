   M S B A M L   `   `   `  ����  StolowkaSQL    StolowkaSQL.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$,  &Stołówka - Zarządzanie bazą danych��5   	   $	��600��64   $	��530��6A   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��48 �6   �� 5	      $��50 �6   �� 5
      $��50 �6   �� 5      $��45 �6   �� 5      $��45 �6   .+�5   
   �� -   5        $��Dania��5      ��6    �� *viewList.View+ �� View 5      �� 5      .P�5      �� $��Id��6&    �� Width$ 40��62    �� DisplayMemberBinding 6=   �� *id+�� 5      $��Nazwa��6%   $	 300��64    �� CellTemplate 5      �� 5      .R�5   "   �� ��6*   �� *nazwa+5      5      �� 5      $��activ��6%   $ 50��64    5      �� 5      .R�5   "   ��  d� 	IsChecked 6+   �� *active+ �� Mode$ TwoWay=�5      5       �� 5!      $��
danie dnia��6%   $ 70��69    5"      �� 5#      .R�5$   "   �� $��Center=�6X    6+   �� *	danieDnia+$ TwoWay=�6X   5%      5'      5(      5+      �� 5-   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5.      �� $��First��6   ��6%   �� *FirstCommand+�� 5/      $��Previous��6   ��6(   �� *PreviousCommand+�� 50      $
��auto��6   ��6%   �� *CurrentPage+�� 51      $��of��6   �� 52      $
��auto��6   ��6%   �� *	TotalPage+�� 53      $
��Next��6   ��6$   �� *NextCommand+�� 54      $
��Last��6   ��6$   �� *LastCommand+55      �� 57   
   $��2��6   $��Aktualizuj bazę danych��6   ��6?   �� *UpdateCommand+�� 58   
   $��3��6   $ ��Wyzeruj wszystkie wartosci��6   ��6C   �� *ResetCommand+�� 59   
   $��4��6   $��Dodaj nowy rekord��6   ��6:   �� *AddWindowCommand+�� 5:   
   -   5        $��5��5:      $��Wyłącz program��6   
���""��6L   5;      5<      