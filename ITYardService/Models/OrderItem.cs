using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;


namespace ITYardService.Models
{
    public class OrderItem : EntityBase
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }


        public OrderItem(int OrderItemId, Product Product, int Quantity)
        {
            base.Id = OrderItemId;
            this.Product = Product;
            this.Quantity = Quantity;
            this.PurchasePrice = Product.CurrentPrice*Quantity;
        }


        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Product Id - {base.Id}, product name - {(this.Product).ProductName}, quantity - {this.Quantity}, purchase price - {this.PurchasePrice}");
        }

        public new bool Validate()
        {
            if (Quantity <= 0)
            {
                Logger.LogError("Validate error");
                return false;
            }
            return true;
        }
    }
}
