namespace ProblemSolvingCSharp.Gemini;

[TestClass]
public class DataProcessingPipeline
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string ProductCategory { get; set; }
        public decimal Price { get; set; }

    }
    [TestMethod]
    public void TestDataProcessingPipeline()
    {
        // Arrange
        var orderList = new List<Order>
        {
            new Order { OrderId = 1, OrderDate = new DateTime(2024, 1, 15), ProductCategory = "Electronics", Price = 1200.50m },
            new Order { OrderId = 2, OrderDate = new DateTime(2024, 2, 20), ProductCategory = "Books", Price = 55.00m },
            new Order { OrderId = 3, OrderDate = new DateTime(2023, 5, 10), ProductCategory = "Electronics", Price = 800.00m },
            new Order { OrderId = 4, OrderDate = new DateTime(2024, 3, 5), ProductCategory = "Electronics", Price = 350.00m },
            new Order { OrderId = 5, OrderDate = new DateTime(2024, 4, 1), ProductCategory = "Books", Price = 75.25m },
            new Order { OrderId = 6, OrderDate = new DateTime(2024, 5, 12), ProductCategory = "Home Goods", Price = 150.75m }
        };

        // Act
        var revenueByCategory = orderList
            .Where(order => order.OrderDate.Year == 2024)
            .GroupBy(order => order.ProductCategory)
            .ToDictionary(
                group => group.Key,
                group => group.Sum(order => order.Price)
            );

        // Assert
        Assert.HasCount(3, revenueByCategory);
        Assert.AreEqual(1550.50m, revenueByCategory["Electronics"]); // 1200.50 + 350.00
        Assert.AreEqual(130.25m, revenueByCategory["Books"]);       // 55.00 + 75.25
        Assert.AreEqual(150.75m, revenueByCategory["Home Goods"]);
    }
}
