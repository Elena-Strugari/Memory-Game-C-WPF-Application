   M S B A M L   `   `   `  ����  
MemoryGame    MemoryGame.Views.GameView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Memory Game��5   	   $	��500��6   $	��850��6*   .��5      ]� 
�������.+�5   
   o� $	��Top=�6   .@�5      m� $��⚙ Settings��6   .@�5	      m� $��	⏸ Pause��6    m� Command 6,   �� *PauseCommand+m� 5
      $��💾 Save Game��6    61   �� *SaveGameCommand+m� 5      $��▶ Continue��6    6/   �� *ContinueCommand+�� 5      m� 5      $��	🚪 Exit��6    6,   �� *ExitCommand+5      5      � 5   
   $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��Center=�6&   .+�5      �� $��⏱ Time Left:��6   $��18(�60   $
��Bold"�6>   ���#8844886P   �� 5      $��24(�6=   $
��Bold"�6K   ���#884488��6   �� *TimeLeftDisplay+6]   5      (� 5      $��1��6    (� Stretch$ Uniform=�6#    (� StretchDirection$
 Both=�65   .��5       �� ��6   �� *Tiles+��5!      �� 5"      .R�5#      A�  A� Rows 6*   �� *
GameRows+ A� Columns 6D   �� *GameColumns+5$      ��5&      �� 5'      .R�5(      �� $��0q�5)   &   $��2q�62   ��5(   %   �� *DataContext.FlipTileCommand+ �� RelativeSource ��  �� AncestorType
 Window��5)   	   �� .��5*   "   �� $��Uniform=�6(   ��5+   &   �� 5,   *   	 �� 
TargetType"	 ��60   .�5-   .   �� 
 �� Property
 � �� �� Value 6G   �� *BackImagePath+ �� Triggers 5.   .   �� 5/   2    �� Binding 6>   �� *	IsFlipped+ �� Value True6\   .a�50   6   �� 
 � �� 6O   �� *	ImagePath+51   3   53   +   55   #   56      58      5:      5;      5<      5=      5>      