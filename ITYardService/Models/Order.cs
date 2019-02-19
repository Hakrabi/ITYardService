using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.Repository;
using ITYardService.Common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public class Order : EntityBase
    {
        [DataMember] public Guid CustomerId { get; set; }       
        [DataMember] public DateTime OrderDate { get; set; }
        [DataMember] public Address ShippingAdress { get; set; }
        [DataMember] public List<Guid> OrderItems { get; set; }

        
        public Order(Guid OrderId, Guid CustomerId, DateTime OrderDate, List<Guid> OrderItems)
        {
            base.Id = OrderId;
            this.CustomerId = CustomerId;
            this.OrderDate = OrderDate;
            this.OrderItems = OrderItems;

            //CustomerRepositry.
            (GenericRepository<Customer>._general[CustomerId]).Orders.Add(base.Id);
        }

        public override void DisplayEntityInfo()
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\t -> Order {OrderDate} :: {Id}");
            Console.ResetColor();

            foreach (var OrderItemId in OrderItems)
            {
                GenericRepository<OrderItem>._general[OrderItemId].DisplayEntityInfo();
            }
        }

        public override bool Validate()
        {

            if (OrderItems.Count <= 0)
            {
                Logger.LogError("Validate error");
                return false;
            }
            return true;
        }


    }
}
