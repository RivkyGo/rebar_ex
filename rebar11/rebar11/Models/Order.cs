using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;


//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using System;
//using System.Collections.Generic;

namespace rebar11.Models
    {
        public class Order
        {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid OrderID { get; set; }

        [BsonElement("OrderShakes")] 
        public List<Shake> OrderShakes { get; set; }

        [BsonElement("SumPrice")]   
        public double SumPrice { get; set; }
        
        [BsonElement("CustomerName")] 
        public string CustomerName { get; set; }

        [BsonElement("OrderTimeStart")] 
        public DateTime OrderTimeStart { get; set; }

        [BsonElement("OrderTimeFinish")] 
        public DateTime OrderTimeFinish { get; set; }
        }
    }


    //public List<Shake> OrderShakes { get; set; }
    //public double SumPrice { get; set; }
    //public Guid OrderID { get; set; }
    //public String CustomerName { get; set; }
    ////public DateTime OrderDateTime { get; set; }
    //public DateTime OrderTimeStart { get; set; }
    //public DateTime OrderTimeFinish { get; set; }

    //[BsonGuidRepresentation((GuidRepresentation)BsonType.ObjectId)]
    //public DateTime OrderTimeStart { get; set; }
    //public DateTime OrderTimeFinish { get; set; }

    //public Order (string customerName)
    //{
    //    OrderShakes = new List<Shake>();
    //    OrderID = Guid.NewGuid();
    //    CustomerName = customerName;
    //    OrderDateTime = DateTime.Today;
    //    //DateTime = DateTime.Today;
    //    //OrderTimeStart = DateTime.Now;
    //}


    //public void AddShakeToOrder(Shake shake)
    //{
    //    OrderShakes.Add(shake);
    //    SumPrice += shake.ShakeSize ;
    //}




