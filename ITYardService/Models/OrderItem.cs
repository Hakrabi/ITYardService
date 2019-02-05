using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public class OrderItem : EntityBase
    {
        [DataMember] public Product Product { get; set; }
        [DataMember] public int Quantity { get; set; }
        [DataMember] public decimal PurchasePrice { get; set; }


        public OrderItem(Guid OrderItemId, Product Product, int Quantity)
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

        public override bool Validate()
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
