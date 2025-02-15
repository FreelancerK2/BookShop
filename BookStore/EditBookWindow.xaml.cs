using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public Book Book { get; private set; }

        public EditBookWindow(Book book)
        {
            InitializeComponent();
            Book = book;

            // Load existing book details into text fields
            NameBox.Text = book.Name;
            AuthorBox.Text = book.Author;
            PublishingHouseBox.Text = book.PublishingHouse;
            NumberOfPagesBox.Text = book.NumberOfPages.ToString();
            GenreBox.Text = book.Genre;
            DateOfPublishingPicker.SelectedDate = book.DateOfPublishing;
            PrimeCostBox.Text = book.PrimeCost.ToString();
            SalePriceBox.Text = book.SalePrice.ToString();
            IsSequelBox.IsChecked = book.IsSequel;
            IsOnSaleBox.IsChecked = book.IsOnSale;
            DiscountBox.Text = book.Discount.ToString();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book.Name = NameBox.Text;
                Book.Author = AuthorBox.Text;
                Book.PublishingHouse = PublishingHouseBox.Text;
                Book.NumberOfPages = int.Parse(NumberOfPagesBox.Text);
                Book.Genre = GenreBox.Text;
                Book.DateOfPublishing = DateOfPublishingPicker.SelectedDate ?? DateTime.Now;
                Book.PrimeCost = decimal.Parse(PrimeCostBox.Text);
                Book.SalePrice = decimal.Parse(SalePriceBox.Text);
                Book.IsSequel = IsSequelBox.IsChecked ?? false;
                Book.IsOnSale = IsOnSaleBox.IsChecked ?? false;
                Book.Discount = decimal.Parse(DiscountBox.Text);

                this.DialogResult = true; // Close the window and return success
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input. Please check the values.\n" + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            var watermark = (TextBlock)VisualTreeHelper.GetChild(textBox.Parent, 0);
            watermark.Visibility = string.IsNullOrEmpty(textBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}
