   M S B A M L   `   `   `  ����M  IGeoLib.WindowsHost, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GeoLib.WindowsHostGeoLib.WindowsHost  5   	   #    GeoLib.WindowsHost.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:GeoLib.WindowsHost     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
   
   �� -   5         ��Name$ btnStart��5
      $��Start Service��6#   $��
50,20,50,0q�6;   $��18(�6O   6v   �� 5   
   -   5        $ btnStop��5      $��Stop Service��6"   $��50,20,50,20q�69   $��18(�6N   6t   �� 5   
   -   5        $ 	btnInProc��5      $��In-Proc Service��6$   $��50,0,300,20q�6>   $��18(�6S   6a   �� 5   
   -   5         ��Name$ 
lblMessage��5      $��
50,20,50,0q�6$   $��Center=�68   5      5      