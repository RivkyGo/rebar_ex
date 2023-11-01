using MongoDB.Driver;
using rebar11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rebar11.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<ShakeMenu> _menu;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);

            _orders = _database.GetCollection<Order>("Orders");
            _menu = _database.GetCollection<ShakeMenu>("Menu");

        }

        public List<ShakeMenu> GetMenu()
        {
            var menuItems = _menu.Find(_ => true).ToList();
            return menuItems.AsEnumerable().Select(item =>
            {
                item.ShakeID = Guid.Parse(item.ShakeID.ToString());
                return item;
            }).ToList();
        }


        public void AddShakeMenu(ShakeMenu shakeMenu)
        {
            _menu.InsertOne(shakeMenu);
        }



        public ShakeMenu GetShakeById(Guid id)
        {
            var filter = Builders<ShakeMenu>.Filter.Eq(menu => menu.ShakeID, id);
            return _menu.Find(filter).FirstOrDefault();
        }


        // order fanction

        public Order GetOrderById(Guid id)
        {
            var filter = Builders<Order>.Filter.Eq(order => order.OrderID, id);
            return _orders.Find(filter).FirstOrDefault();
        }


        public ShakeMenu GetShakeMenu(string shakeName)
        {
            var filter = Builders<ShakeMenu>.Filter.Eq(s => s.ShakeName, shakeName);
            return _menu.Find(filter).FirstOrDefault();
        }


        public void AddOrder(Order order)
        {
            _orders.InsertOne(order);
        }

        //public ShakeMenu GetShakeMenu(string shakeName)
        //{
        //    return (ShakeMenu)_menu.Find(shakeName);
        //}


        //public ShakeMenu a

        //public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
