using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ViewSaleWindow.xaml
    /// </summary>
    public partial class ViewSaleWindow : Window
    {
        private readonly BookstoreDbContext _context;

        public ViewSaleWindow()
        {
            InitializeComponent();
            _context = new BookstoreDbContext();
            LoadSales();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadSales()
        {
            SalesDataGrid.ItemsSource = _context.Sales
                .Include(s => s.Book)
                .OrderByDescending(s => s.SaleDate)
                .ToList()
                .Select(s => new
                {
                    BookName = s.BookName,
                    Author = s.Author,
                    QuantitySold = s.Quantity,
                    SalePrice = s.SalePrice,
                    SaleDate = s.SaleDate.ToString("MM/dd/yyyy HH:mm")  // Format date here
                })
                .ToList();
        }

    }
}
