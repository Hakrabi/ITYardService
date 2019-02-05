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

        public static Dictionary<Guid, OrderItem> _orderItems = new Dictionary<Guid, OrderItem>();
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

        public OrderItem GetById(Guid id)
        {
            return _orderItems[id];
        }

        public void Update(Guid id, OrderItem OrderItem) 
        {
            _orderItems[id]= OrderItem;
        }

        public void Delete(Guid id)
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

        public void DisplayUserInfo(Guid id)
        {
            _orderItems[id].DisplayEntityInfo();
        }
    }
}
