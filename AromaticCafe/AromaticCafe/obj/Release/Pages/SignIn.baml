   M S B A M L   `   `   `  ���� G  CAromaticCafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AromaticCafe.PagesAromaticCafe.Pages      AromaticCafe.Pages.SignIn   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:AromaticCafe.Pages     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     V RMaterialDesignThemes.Wpf, Version=3.1.0.1244, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  SignIn�� N� 
Background
 �����.��� ����    
Background �� ImageSource# [   � RowDefinitions �� $��90 ��� $��50 ��� $��* �.+��� $��0��$��Center=�$��Aromatic��$��Algerian)�$��82(����	#FFFF0035 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 5Q�   	Direction$	 315Q�   Opacity$ .3Q�   ShadowDepth$ 10Q��� $��1��$��Center=�$
��cafe��$��Algerian)�$��36(����	#FFFF0035   $ 5Q�$	 315Q�$ .3Q�$ 10Q�	   Color$	 Black��� $��2��$	��400��$	��400��$��0,20,0,0q�$	��Top=�.+��� ���	#F2FFFFFF
 �� CornerRadius$
 50��   $ 5Q�$	 315Q�$ .3Q�$ 10Q�$	 Black���  �� $��40 ��� $��* ��� $��40 �.+��� $��0��$��40��$��0,0,0,0q�$��Center=�$��sign in��$��Algerian)�$��26(����	#FF007FFD� $��1�� �� $��* ��� $��* ��� $��* �.+��� $��0��$��Bottom=�.+��� $	��320��$��35�� �� Orientation$ 
Horizontal=�.+��� $��0q�$��Email��$��Algerian)�$��22(����#543116� $��30��$��30��$��	225,0,0,0q�.+��� ���	#FF916E50$
 50���� -    ��Name$ ButtonSignInOpenEmailInfo��$��20��$��20��$��0q���Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  $��20��$��20��$��Center=�$��Center=����#FFDDC2   Kind$ InfoVariant=��� -    ��Name$ TextBoxSignInEmail��$	��320��$��25��  baseTextBox#��[ � -    �Name$ GridSignInEmailInfo��$��0��$	��150��$��80��$��Center=�$��100,-25,0,0q�$y�	Collapsed=�.+��� ���	#FF916E50$
 15���  �� $��20 ��� $��* �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��35 �.+��� $��0��$��Center=�$��Center=�$��35,0,0,0q�$��Arial)�$��14(����#FFDDC2
Warning!�� -   $  ButtonSignInCloseEmailInfo��$��1��$��20��$��20��$��0q���Z� ��Z� .��  $ Close=�$��20��$��20�����#FFDDC2�� $��1��$	��140��$��50��$
��Wrap=� �� TextAlignment$ Center=�$��Arial)�
�������$��12(�;9E-mail must have symbol "@" and appropriate domen adress.�� $��1��$��Bottom=�.+��� $	��320��$��35��$ 
Horizontal=�.+��� $��0q�$��	Telephone��$��Algerian)�$��22(����#543116� $��30��$��30��$��	170,0,0,0q�.+��� ���	#FF916E50$
 50���� -   $# ButtonSignInOpenTelephoneInfo��$��20��$��20��$��0q���Z� ��Z� .��  $��20��$��20��$��Center=�$��Center=����#FFDDC2$ InfoVariant=��� -   $ TextBoxSignInTelephone��$	��320��$��25��#��[ � -   $ GridSignInTelephoneInfo��$��1��$	��150��$��80��$��Center=�$��100,-25,0,0q�$y�	Collapsed=�.+��� ���	#FF916E50$
 15���  �� $��20 ��� $��* �.+�� $��0�� �� $��* ��� $��35 �.+��� $��0��$��Center=�$��Center=�$��35,0,0,0q�$��Arial)�$��14(����#FFDDC2
Warning!�� -   $$ ButtonSignInCloseTelephoneInfo��$��1��$��20��$��20��$��0q���Z� ��Z� .��  $ Close=�$��20��$��20�����#FFDDC2�� $��1��$	��140��$��35��$
��Wrap=�$ Center=�$��Arial)�
�������$��12(�,*Enter your number in international format.�� $��2��$��Bottom=�.+��� -	   $ ButtonSignIn��$	��100��$��30��$��Center=�$��Submit��$��Arial)�$��12(�$
��Bold"�
���   �  
baseButton#��[ �� -
    ��Name$ TextBlockError��$��Center=�$��0,10,0,0q�$��12(�
���  ���� -   $ ButtonHeperlinkSignIn��$��2��$��Center=�$��Center=�$��sign up��$��Algerian)�$��16(����	#FFFF5050  TransparentButton#��[ 