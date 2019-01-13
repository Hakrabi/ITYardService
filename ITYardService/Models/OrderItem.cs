using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService
{
    class OrderItem : EntityBase
    {
        public Product Product;
        public int Quantity;
        public decimal PurchasePrice;


        public OrderItem(int OrderItemId, Product Product, int Quantity, Decimal PurchasePrice )
        {
            base.Id = OrderItemId;
            this.Product = Product;
            this.Quantity = Quantity;
            this.PurchasePrice = PurchasePrice;
        }


        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Product Id - {base.Id}, product name - {(this.Product).ProductName}, quantity - {this.Quantity}, purchase price - {this.PurchasePrice}");
        }

    }
}
