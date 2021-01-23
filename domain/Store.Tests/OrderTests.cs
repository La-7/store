using System;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyitems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }
        
        [Fact]
        public void TotalPrice_WithEmptyitems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalCount);
        }      
        
        [Fact]
        public void TotalCount_WitNonEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 200m),

            });

            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalcualtesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void AddItem_WithNullBook_ThrowsArgumentNullException()
        {
            var order = new Order(1, new[]
{
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Book book = null;

            Assert.Throws<ArgumentNullException>(() => order.AddItem(book, 1));
        }

        [Fact]
        public void AddItem_WithBook_AddNewBookInCart()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m)
            });

            Book book = new Book(4, "", "", "", "", 0m);
            order.AddItem(book, 2);

            Assert.Contains(order.Items, b => b.BookId == book.Id);
            Assert.Contains(order.Items, b => b.Count == 2);
            Assert.Contains(order.Items, b => b.Price == 0m);
        }

        [Fact]
        public void AddItem_WithBook_IncreasingNumberOfBooksInCart()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m)
            });

            Book book = new Book(1, "", "", "", "", 0m);
            order.AddItem(book, 2);

            Assert.Contains(order.Items, o => o.Count == 5);
        }
    }
}
