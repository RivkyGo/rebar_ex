using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

    
   
namespace rebar11.Models
{
    public class Account
    {
        public List<Order> Orders { get; set; }
        public int SumPriceAllTheOrder { get; set; }

        public Account()
        {
            Orders = new List<Order>();
            SumPriceAllTheOrder = 0;
        }

        public void AddOrderToTheCount(Order order)
        {
            Orders.Add(order);
            SumPriceAllTheOrder += order.SumPrice;
        }
    }
}
