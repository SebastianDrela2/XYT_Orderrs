using System.Linq;
using System;

namespace Program
{

   public enum OrderType
    {
        Buy,
        Sell
    }

   public enum ActionType
    {
        Add,
        Remove
    }
    public class Order
    {

        public string Id { get; set; }
        public OrderType OrderType { get; set; }

        public ActionType ActionType { get; set; } 

        public double Price;

        public int Quantity;

    }
    class Orders
    {
      
       private static List<Order> LoadTestData()
        {
            List<Order> order_list = new List<Order>();

            order_list.Add(new Order {Id = "001", OrderType = OrderType.Buy, ActionType = ActionType.Add, Price = 20.0, Quantity = 100 });
            order_list.Add(new Order {Id = "002", OrderType = OrderType.Sell, ActionType = ActionType.Add, Price = 25.0, Quantity = 200 });
            order_list.Add(new Order {Id = "003", OrderType = OrderType.Buy, ActionType = ActionType.Add, Price = 23.0, Quantity = 50 });
            order_list.Add(new Order {Id = "004", OrderType = OrderType.Buy, ActionType = ActionType.Add, Price = 23.0, Quantity = 70 });
            order_list.Add(new Order {Id = "005", OrderType = OrderType.Buy, ActionType = ActionType.Remove, Price = 23.0, Quantity = 50 });
            order_list.Add(new Order {Id = "006", OrderType = OrderType.Sell, ActionType = ActionType.Add, Price = 28, Quantity = 100 });

            return order_list;
        }
       static void Main(string[] args)
        {
            // Get Dump Data
            List<Order> order_list = LoadTestData();

            // Get Cheapest Orders
            Order cheapest_order_sell = order_list.OrderBy(x => x.Price).Where(x => x.OrderType == OrderType.Sell).ToList().FirstOrDefault();
            Order cheapest_order_buy = order_list.OrderBy(x => x.Price).Where(x => x.OrderType == OrderType.Buy).ToList().FirstOrDefault();

            // Calculate Total Price Of Selected Orders
            double order_total_sell = cheapest_order_sell.Price * cheapest_order_sell.Quantity;
            double order_total_buy = cheapest_order_buy.Price * cheapest_order_buy.Quantity;

            // Write out Results
            Console.WriteLine($"Cheapest order type \"Sell\": ID = {cheapest_order_sell.Id} TotalPrice = {order_total_sell}");
            Console.WriteLine($"Cheapest order type \"Buy\": ID = {cheapest_order_buy.Id} TotalPrice = {order_total_buy}");


            // Results

            // Cheapest order type "Sell": ID = 002 TotalPrice = 5000
            // Cheapest order type "Buy": ID = 001 TotalPrice = 2000
        }
    }
}
