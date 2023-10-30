using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rebar11.Models
{
    public class Order
    {
        public List<Shake> OrderShakes { get; set; }
        public int SumPrice { get; set; }
        public Guid OrderID { get; set; }
        public String CustomerName { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime OrderTimeStart { get; set; }
        public DateTime OrderTimeFinish { get; set; }

        public Order (string customerName)
        {
            OrderShakes = new List<Shake>();
            OrderID = Guid.NewGuid();
            CustomerName = customerName;
            DateTime = DateTime.Today;
            OrderTimeStart = DateTime.Now;
        }


        public void AddShakeToOrder(Shake shake)
        {
            OrderShakes.Add(shake);
            SumPrice += shake.ShakeSize ;
        }


    }
}
