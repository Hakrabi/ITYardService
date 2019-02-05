using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.Repository;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public class Order : EntityBase
    {
        [DataMember] public Customer Customer { get; set; }       
        [DataMember] public DateTime OrderDate { get; set; }
        [DataMember] public Address ShippingAdress { get; set; }
        [DataMember] public Guid[] OrderItems { get; set; }

        public Order(Guid OrderId, Customer Customer, DateTime OrderDate, Address ShippingAdress, Guid[] OrderItems)
        {
            base.Id = OrderId;
            this.Customer = Customer;
            this.OrderDate = OrderDate;
            this.ShippingAdress = ShippingAdress;
            this.OrderItems = OrderItems;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"\nOrder7 Id - {base.Id}");

            Console.WriteLine("\nCustomer:");
            (this.Customer).DisplayEntityInfo();

            Console.WriteLine($"\nOrder date - {this.OrderDate}");

            Console.WriteLine("\nShipping adress:");
            (this.ShippingAdress).DisplayEntityInfo();

            Console.WriteLine("\nOrder items id:");
            foreach (var item in (this.OrderItems))
            {
                Console.WriteLine(item);
            }
        }

        public override bool Validate()
        {

            if (OrderItems.Length <= 0)
            {
                Logger.LogError("Validate error");
                return false;
            }
            return true;
        }


    }
}
