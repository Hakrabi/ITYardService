using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService
{
    class Order : EntityBase
    {
        public Customer Customer;
        public DateTime OrderDate;
        public Address ShippingAdress;
        public List<OrderItem> OrderItems = new List<OrderItem>();

        public Order(int OrderId, Customer Customer, DateTime OrderDate, Address ShippingAdress, List<OrderItem> OrderItems)
        {
            base.Id = OrderId;
            this.Customer = Customer;
            this.OrderDate = OrderDate;
            this.ShippingAdress = ShippingAdress;
            this.OrderItems = OrderItems;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"\Order Id - {base.Id}");

            Console.WriteLine("\nCustomer:");
            (this.Customer).DisplayEntityInfo();

            Console.WriteLine($"\nOrder date - {this.OrderDate}");

            Console.WriteLine("\nShipping adress:");
            (this.ShippingAdress).DisplayEntityInfo();

            Console.WriteLine("\nOrder items:");
            foreach (var item in this.OrderItems)
            {
                item.DisplayEntityInfo();
            }
        }

        public new bool Validate()
        {
            var isValid = true;
            if (!Customer.Validate()) isValid = false;
            if (!ShippingAdress.Validate()) isValid = false;
            if (OrderItems.Count == 0) isValid = false;

            return isValid;
        }
    }
}
