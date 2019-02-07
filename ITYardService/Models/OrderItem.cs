using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using ITYardService.Repository;

namespace ITYardService.Models
{
    [DataContract]
    public class OrderItem : EntityBase
    {
        [DataMember] public Guid ProductId { get; set; }
        [DataMember] public int Quantity { get; set; }
        [DataMember] public decimal PurchasePrice { get; set; }


        public OrderItem(Guid OrderItemId, Guid ProductId, int Quantity)
        {
            base.Id = OrderItemId;
            this.ProductId = ProductId;
            this.Quantity = Quantity;

            decimal CurrentPrice = (GenericRepository<Product>._general[ProductId]).CurrentPrice;
            this.PurchasePrice = CurrentPrice*Quantity;
        }


        public override void DisplayEntityInfo()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\t\t -> OrderItem {PurchasePrice}. Quantity: {Quantity} :: {Id}");
            Console.ResetColor();

            (GenericRepository<Product>._general[ProductId]).DisplayEntityInfo();


            //Console.WriteLine($"Product Id - {base.Id}, product name - {(this.Product).ProductName}, quantity - {this.Quantity}, purchase price - {this.PurchasePrice}");
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
