using ITYardService.Common;
using ITYardService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITYardService.Repository
{
    class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {

        public static Dictionary<Guid, T > _general = new Dictionary<Guid, T>();

        public IEnumerable<T> All()
        {
            return _general.Values.ToList();
        }

        public List<Guid> GetAllID()
        {
            Guid[] array = new Guid[_general.Count];
            int i = 0;

            foreach (var item in _general)
            {
                array[i] = item.Value.Id;
                i++;
            }
            return array.ToList();
        }

        public bool Insert(T Entity)
        {
            if (Entity.Validate())
            {
                _general.Add(Entity.Id, Entity);
                Logger.LogInfo($"{typeof(T).Name}  \t{Entity.Id} was inserted");
                return true;
            }
            return false;
        }

        public T GetById(Guid id)
        {
            return _general[id];
        }

        public bool Update(Guid id, T Entity)
        {
            if (_general.ContainsKey(id)){
                _general[id] = Entity;
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            if (_general.ContainsKey(id))
            {
                /*// if T is order delete its order items an then remove the order
                if (GetById(id).GetType() == typeof(Order))
                {
                    var OrderItemsList = GenericRepository<Order>._general[id].OrderItems;
                    foreach (var OrderItemId in OrderItemsList)
                    {
                        GenericRepository<OrderItem>._general.Remove(OrderItemId);
                    }
                    GenericRepository<Order>._general[id].OrderItems.Clear();

                }

                // if T is Customer find its orders, remove their orederitems, then remove orders and then remove Customer
                if (GetById(id).GetType() == typeof(Customer))
                {
                    var OrdersList = GenericRepository<Customer>._general[id].Orders;
                    foreach (var OrderId in OrdersList)
                    {
                        var OrderItemsList = GenericRepository<Order>._general[OrderId].OrderItems;
                        foreach (var OrderItemId in OrderItemsList)
                        {
                            GenericRepository<OrderItem>._general.Remove(OrderItemId);
                        }
                        GenericRepository<Order>._general[id].OrderItems.Clear();
                        GenericRepository<Order>._general.Remove(OrderId);
                    }
                }*/
                _general.Remove(id);
                Logger.LogInfo($"{typeof(T).Name}  \t{id} was deleted");
                return true;
            }
            Logger.LogError("Id not exist");
            return false;
        }

        public void DisplayEntityInfo(Guid id)
        {
            EntityBase Entity = _general[id] as EntityBase;
            Entity.DisplayEntityInfo();
        }

    }
}
