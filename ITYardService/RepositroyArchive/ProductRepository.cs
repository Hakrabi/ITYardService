using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;



namespace ITYardService.Repository
{
    public class ProductRepository
    {

        public static Dictionary<Guid, Product> _products = new Dictionary<Guid, Product>();

        public Product[] All()
        {
            return (_products.Values).ToArray();
        }

        public void Insert(Product Product)
        {
            if (Product.Validate())
            {
                _products.Add(Product.Id, Product);
                Logger.LogInfo($"Product {Product.Id} was inserted");
            }
        }

        public Product GetById(Guid id)
        {
            return _products[id];
        }

        public void Update(Guid id, Product Product) 
        {
            _products[id]= Product;
        }

        public void Delete(Guid id)
        {
            if (_products.ContainsKey(id))
            {
                _products.Remove(id);
                Logger.LogInfo($"Product {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayUserInfo(Guid id)
        {
            _products[id].DisplayEntityInfo();
        }
    }
}
