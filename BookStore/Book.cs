using System;
using System.Collections.Generic;

namespace BookStore;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string PublishingHouse { get; set; } = null!;

    public int NumberOfPages { get; set; }

    public string Genre { get; set; } = null!;

    public DateTime DateOfPublishing { get; set; }

    public decimal PrimeCost { get; set; }

    public decimal SalePrice { get; set; }

    public bool IsSequel { get; set; }

    public bool IsOnSale { get; set; }

    public decimal Discount { get; set; }
}
