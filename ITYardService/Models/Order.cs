using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.Repository;
using ITYardService.common;


namespace ITYardService.Models
{
    public class Order : EntityBase
    {
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address ShippingAdress { get; set; }
        public OrderItemRepository OrderItems { get; set; }

        public Order(int OrderId, Customer Customer, DateTime OrderDate, Address ShippingAdress, OrderItemRepository OrderItems)
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

            Console.WriteLine("\nOrder items:");
            foreach (var item in (this.OrderItems).All())
            {
                item.DisplayEntityInfo();
            }
        }

        public new bool Validate()
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
