   M S B A M L   `   `   `  ����E  AMemoryGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MemoryGame.ViewsMemoryGame.Views  5   	   %    MemoryGame.Views.StatisticsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MemoryGame.Views     5   	     � Title$  StatisticsView��5   	   $	��450��6    $	��800��6-   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��← Back��6   $��61��5      $��20��5      $
��Left=�5      $	��Top=�5      ���	#FFDCBDF7��5      �� *BackCommand+5      �� 5   
   $��Help – About��6   $��93��5      $��Right=�5      ���	#FFE4D7FA$��0,0,0,38q�5!      ��5      �� *HelpCommand+5!      �� 5$   
   $��0,29,0,0q�6   $��2��6'   .+�5&      �� $��📊 Your Statistics��6   $��24(�62   $
��Bold"�6@   ���#884488$��0,0,0,20q�6g   $��37��6y   �� 5(      $��Games Played:��6   $��SemiBold"�6-   �� 5)      $��0,0,0,10q�65   ��6   �� *GamesPlayed+65   �� 5+      $��
Games Won:��6   $��SemiBold"�6*   �� 5,      $��0,0,0,10q�62   ��6   �� *
GamesWon+62   �� 5.      $��Games Lost:��6   $��SemiBold"�6+   �� 5/      $��0,0,0,10q�63   ��6   �� *	GamesLost+63   �� 51      $
��0,20q�6   �� 52      $��🏆 Leaderboard��6   $��20(�6.   $
��Bold"�6<   ���#553355$��0,0,0,10q�6c   �� 54      $	��150��6;   ��6   �� *Leaderboard+ �� View 55      �� 56      .P�57      �� $��Username��6)    �� Width$	 120��6e    �� DisplayMemberBinding 6;   �� *
Username+6e   �� 58      $��Played��6)   $ 60��6f    69   �� *GamesPlayed+6f   �� 59      $	��Won��6)   $ 60��6`    66   �� *
GamesWon+6`   �� 5:      $
��Lost��6)   $ 60��6b    67   �� *	GamesLost+6b   5;      5=      �� 5?      $
��Back��6   $	��100��6D   $��30��6P   $��Right=�6\   $��0,20,0,0q�6x   ���	#FFDCBDF7��6$   �� *BackCommand+6�   5@      5A      5B      