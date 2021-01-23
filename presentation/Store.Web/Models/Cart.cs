using System.Collections.Generic;

namespace Store.Web.Models
{
    public class Cart
    {
        public int OrderId { get; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public Cart(int id)
        {
            OrderId = id;
            TotalCount = 0;
            TotalPrice = 0m;
        }
    }
}
