using System;

namespace Bookstore.Core
{
    public class DiscountService
    {
        public decimal GetDiscount(IBook book)
        {
            // 20% discount for books released more than year before
            if (book.ReleaseDate < DateTime.UtcNow.AddYears(-1))
                return book.Price * 0.8m;

            // 10% discount for books released more than 6 months before
            if (book.ReleaseDate < DateTime.UtcNow.AddMonths(-6))
                return book.Price * 0.9m;

            return book.Price;
        }
    }
}
