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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        public string BookName => txtBookName.Text;
        public string Author => txtAuthor.Text;
        public string PublishingHouse => txtPublishingHouse.Text;
        public int NumberOfPages => int.TryParse(txtNumberOfPages.Text, out int pages) ? pages : 0;
        public string Genre => txtGenre.Text;
        public DateTime DateOfPublishing => dpDateOfPublishing.SelectedDate ?? DateTime.Now;
        public decimal PrimeCost => decimal.TryParse(txtPrimeCost.Text, out decimal cost) ? cost : 0;
        public decimal SalePrice => decimal.TryParse(txtSalePrice.Text, out decimal price) ? price : 0;
        public bool IsSequel => chkIsSequel.IsChecked ?? false;
        public bool IsOnSale => chkIsOnSale.IsChecked ?? false;

        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BookName) || string.IsNullOrWhiteSpace(Author))
            {
                MessageBox.Show("Book Name and Author are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true; // Close window and return success
        }
    }
}
