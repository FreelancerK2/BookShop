   M S B A M L   `   `   `  ����D  @BookStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BookStore	BookStore  5   	       BookStore.AddBookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BookStore     5   	     � Title$  AddBookWindow��5   	   $	��650��6   $	��350��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      � .+�5
   
   �� $��20q�6   .+�5      �� $��	Book Name��6   
�������$��5q�6;   �� 5      -   5        $��txtBookName��5      $	��5,0q�6)   �� 5      $��Author��6   
�������$��5q�68   �� 5      -   5        $��	txtAuthor��5      $	��5,0q�6'   �� 5      $��Publishing House��6   
�������$��5q�6B   �� 5      -   5        $��txtPublishingHouse��5      $	��5,0q�60   �� 5      $��Number of Pages��6   
�������$��5q�6A   �� 5      -   5        $��txtNumberOfPages��5      $	��5,0q�6.   �� 5      $��Genre��6   
�������$��5q�67   �� 5      -   5        $��txtGenre��5      $	��5,0q�6&   �� 5      $��Date of Publishing��6   
�������$��5q�6D   (  "System.Windows.Controls.DatePicker  5       -   5        $��dpDateOfPublishing��5       $	��5,0q�63   �� 5#      $��
Prime Cost��6   
�������$��5q�6<   �� 5$      -   5        $��txtPrimeCost��5$      $	��5,0q�6*   �� 5'      $��
Sale Price��6   
�������$��5q�6<   �� 5(      -   5        $��txtSalePrice��5(      $	��5,0q�6*   �� 5+      -	   5        $��chkIsSequel��5+      $��
Is Sequel?��6*   $��5q�6?   �� 5.      -
   5        $��chkIsOnSale��5.      $��Is On Sale?��6*   $��5q�6@   �� 51      $��Discount (%)��6   
�������$��5q�6>   �� 52      -   5        $��DiscountBox��52      $	��5,0q�6)   �� 54      -   5        $��Add Book��54      $��10q�6>   55      56      57      