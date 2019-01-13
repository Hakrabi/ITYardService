using System;
using System.Collections.Generic;
using System.Text;

namespace ITYardService
{
    class Product : EntityBase
    {

        public string ProductName;
        public string Description;
        public decimal CurrentPrice;

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

            return isValid;
        }

    }
}
