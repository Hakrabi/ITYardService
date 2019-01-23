using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;



namespace ITYardService.Repository
{
    public class OrderRepository
    {

        public static Dictionary<int, Order> _orders = new Dictionary<int, Order>();

        public Order[] All()
        {
            return (_orders.Values).ToArray();
        }

        public void Insert(Order Order)
        {
            if (Order.Validate())
            {
                _orders.Add(Order.Id, Order);
                Logger.LogInfo($"Order {Order.Id} was inserted");
            }
        }

        public Order GetById(int id)
        {
            return _orders[id];
        }

        public void Update(int id, Order Order) 
        {
            _orders[id]= Order;
        }

        public void Delete(int id)
        {
            if (_orders.ContainsKey(id))
            {
                _orders.Remove(id);
                Logger.LogInfo($"Product {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayUserInfo(int id)
        {
            _orders[id].DisplayEntityInfo();
        }
    }
}
