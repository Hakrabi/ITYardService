using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;

namespace ITYardService.Models
{
    public class Product : EntityBase
    {

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }

        public Product(int ProductId, string ProductName, string Description, decimal CurrentPrice)
        {
            base.Id = ProductId;
            this.ProductName = ProductName;
            this.Description = Description;
            this.CurrentPrice = CurrentPrice;
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Product Id - {base.Id}, product name - {this.ProductName}, description - {this.Description}, current price - {this.CurrentPrice}");
        }

        public new bool Validate()
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
