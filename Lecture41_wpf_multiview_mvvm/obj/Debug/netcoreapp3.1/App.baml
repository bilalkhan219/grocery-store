   M S B A M L   `   `   `  ����E  Awpfproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Lecture41_wpf_multiview_mvvmLecture41_wpf_multiview_mvvm  5      3clr-namespace:wpfproject.Viewswpfproject.Views  5      =#clr-namespace:wpfproject.ViewModelswpfproject.ViewModels  5      &     Lecture41_wpf_multiview_mvvm.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      <local*clr-namespace:Lecture41_wpf_multiview_mvvm     5      0viewsclr-namespace:wpfproject.Views     5      :
viewmodels#clr-namespace:wpfproject.ViewModels     5        �� 	Resources  5       �� DataType*  $wpfproject.ViewModels.adminviewmodel    wpfproject.Views.adminview-  'wpfproject.ViewModels.customerviewmodel#   wpfproject.Views.customerview/  )wpfproject.ViewModels.addproductviewmodel%   wpfproject.Views.addproductview2  ,wpfproject.ViewModels.deleteproductviewmodel(   "wpfproject.Views.deleteproductview0	  *wpfproject.ViewModels.showproductviewmodel'
   !wpfproject.Views.showproductsview)  #wpfproject.ViewModels.userviewmodel   wpfproject.Views.userview+  %wpfproject.ViewModels.reciptviewmodel!   wpfproject.Views.reciptview �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding ��Name��%H  (��       5	      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,	 +)(�� 	    5      *, +)(�� @    5      *, +)'�� w    'G� ~    �� 5	   
   "  6   .R�5
        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        6%   5      �� 5   
   "  6   .R�5        6(   5      �� 5   
   " 	 6   .R�5      
  6'   5      �� 5   
   "  6   .R�5        6   5      �� 5   
   "  6   .R�5        6!   5      �� 5   
   " ��6   .�5      ��  � �� 5       �� 5!      " ��6&   .R�5"      �� $ 5��6!   $ 2q�62   
���   �$��1q�6R   
�������._�5#      �� $ PART_ContentHost��66   $��0q�6+   66   5$      5%      5'      5(      �� 5)   
   " G�6   .�5*      ��  � �� 5+      �� 5,      " G�6&   .R�5-      �� $ 5��6!   $ 2q�62   
���   �$��1q�6R   
�������._�5.      �� $ PART_ContentHost��66   $��0q�6+   66   5/      50      52      53      54      55      