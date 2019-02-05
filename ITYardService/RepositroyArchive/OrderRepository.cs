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

        public static Dictionary<Guid, Order> _orders = new Dictionary<Guid, Order>();

        /*public List<Order> All()
        {
            List<Order> = new List<Order>();
            return _orders.Keys.ToList();
        }*/

        public void Insert(Order Order)
        {
            if (Order.Validate())
            {
                _orders.Add(Order.Id, Order);
                Logger.LogInfo($"Order {Order.Id} was inserted");
            }
            //var entity = Order as EntityBase;
            //if (entity != null)
            //{

            //}
        }

        public Order GetById(Guid id)
        {
            return _orders[id];
        }

        public void Update(Guid id, Order Order) 
        {
            _orders[id]= Order;
        }

        public void Delete(Guid id)
        {
            if (_orders.ContainsKey(id))
            {
                _orders.Remove(id);
                Logger.LogInfo($"Order {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayUserInfo(Guid id)
        {
            _orders[id].DisplayEntityInfo();
        }
    }
}
