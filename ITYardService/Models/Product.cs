using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public class Product : EntityBase
    {

        [DataMember] public string ProductName { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public decimal CurrentPrice { get; set; }

        public Product(Guid ProductId, string ProductName, string Description, decimal CurrentPrice)
        {
            base.Id = ProductId;
            this.ProductName = ProductName;
            this.Description = Description;
            this.CurrentPrice = CurrentPrice;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"\t\t -> Product {ProductName}. Price: {CurrentPrice} :: {Id}");
            Console.WriteLine($"\t\t\t -> {Description}\n");


            //Console.WriteLine($"Product Id - {base.Id}, product name - {this.ProductName}, description - {this.Description}, current price - {this.CurrentPrice}");
        }

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (string.IsNullOrWhiteSpace(Description)) isValid = false;
            if (CurrentPrice <=0) isValid = false;

            if (!isValid)
            {
                Logger.LogError("Validate error");
            }

            return isValid;
        }

    }
}
