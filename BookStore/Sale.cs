using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Sale
    {
        public int Id { get; set; } // Primary Key
        public int BookId { get; set; } // Foreign Key from Book Table
        public string BookName { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; } // Number of books sold
        public string Author { get; set; } = string.Empty ;

        // Navigation Property to Book
        public virtual Book? Book { get; set; }
    }

}
