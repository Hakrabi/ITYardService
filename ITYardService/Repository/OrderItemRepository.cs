using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;



namespace ITYardService.Repository
{
    public class OrderItemRepository
    {

        public static Dictionary<int, OrderItem> _orderItems = new Dictionary<int, OrderItem>();
        public int Count = 0;

        public OrderItem[] All()
        {
            return (_orderItems.Values).ToArray();
        }

        public void Insert(OrderItem OrderItem)
        {
            if (OrderItem.Validate())
            {
                _orderItems.Add(OrderItem.Id, OrderItem);
                Logger.LogInfo($"Order Item {OrderItem.Id} was inserted");
                Count++;
            }
        }

        public OrderItem GetById(int id)
        {
            return _orderItems[id];
        }

        public void Update(int id, OrderItem OrderItem) 
        {
            _orderItems[id]= OrderItem;
        }

        public void Delete(int id)
        {
            if (_orderItems.ContainsKey(id))
            {
                _orderItems.Remove(id);
                Logger.LogInfo($"Product {id} was deleted");
                Count--;
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayUserInfo(int id)
        {
            _orderItems[id].DisplayEntityInfo();
        }
    }
}
