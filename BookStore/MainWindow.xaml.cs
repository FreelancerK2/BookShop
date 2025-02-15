using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookstoreDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new BookstoreDbContext();
            LoadBooks();
        }

        private void LoadBooks()
        {
            BooksList.ItemsSource = _context.Books.ToList();
        }

        private void SearchBooks(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text?.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                // If search box is empty, reload all books
                LoadBooks();
                return;
            }

            BooksList.ItemsSource = _context.Books
                .Where(b =>
                    (b.Name != null && b.Name.ToLower().Contains(query)) ||
                    (b.Author != null && b.Author.ToLower().Contains(query)) ||
                    (b.Genre != null && b.Genre.ToLower().Contains(query)))
                .ToList();
        }


        private void AddBook(object sender, RoutedEventArgs e)
        {
            // Open a dialog window or prompt user for book details
            var newBookWindow = new AddBookWindow();
            if (newBookWindow.ShowDialog() == true)
            {
                var book = new Book
                {
                    Name = newBookWindow.BookName,
                    Author = newBookWindow.Author,
                    PublishingHouse = newBookWindow.PublishingHouse,
                    NumberOfPages = newBookWindow.NumberOfPages,
                    Genre = newBookWindow.Genre,
                    DateOfPublishing = newBookWindow.DateOfPublishing,
                    PrimeCost = newBookWindow.PrimeCost,
                    SalePrice = newBookWindow.SalePrice,
                    IsSequel = newBookWindow.IsSequel,
                    IsOnSale = newBookWindow.IsOnSale
                };

                _context.Books.Add(book);
                _context.SaveChanges();
                LoadBooks(); // Refresh the book list
            }
        }


        private void EditBook(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book selectedBook)
            {
                EditBookWindow editWindow = new EditBookWindow(selectedBook);
                editWindow.Owner = this; // Set owner window

                if (editWindow.ShowDialog() == true) // If user clicked "Save Changes"
                {
                    _context.Books.Update(selectedBook);
                    _context.SaveChanges();
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "Edit Book",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book book)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                LoadBooks();
            }
        }

        private void SellBook(object sender, RoutedEventArgs e)
        {
            if (BooksList.SelectedItem is Book book)
            {
                int quantity = 1; // Default quantity to 1 (or get from user input)

                // Show an input box for quantity (Optional)
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter quantity:", "Sell Book", "1");
                if (int.TryParse(input, out int userQuantity) && userQuantity > 0)
                {
                    quantity = userQuantity;
                }

                // Save the sale record
                var sale = new Sale
                {
                    BookId = book.Id,
                    Author = book.Author,
                    BookName = book.Name,
                    SaleDate = DateTime.Now,
                    SalePrice = book.SalePrice,
                    Quantity = quantity
                };

                _context.Sales.Add(sale);
                _context.SaveChanges();

                MessageBox.Show($"Sold {quantity} copies of '{book.Name}' for {book.SalePrice * quantity:C}");
            }
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the TextBox is not empty, hide the placeholder
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                PlaceholderText.Visibility = Visibility.Visible;
            }
            else
            {
                PlaceholderText.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenViewSales_Click(object sender, RoutedEventArgs e)
        {
            ViewSaleWindow salesWindow = new ViewSaleWindow();
            salesWindow.ShowDialog();
        }

    }
}