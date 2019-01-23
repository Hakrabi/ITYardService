using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;



namespace ITYardService.Repository
{
    public class CustomerRepository
    {

        public static Dictionary<int, Customer> _customers = new Dictionary<int, Customer>();

        public Customer[] All()
        {
            return (_customers.Values).ToArray();
        }

        public void Insert(Customer Customer)
        {
            if (Customer.Validate())
            {
                _customers.Add(Customer.Id, Customer);
                Logger.LogInfo($"Customer {Customer.Id} was inserted");
            }
        }

        public Customer GetById(int id)
        {
            return _customers[id];
        }

        public void Update(int id, Customer Customer) 
        {
            _customers[id] = Customer;
        }

        public void Delete(int id)
        {
            if (_customers.ContainsKey(id))
            {
                _customers.Remove(id);
                Logger.LogInfo($"User {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayCustomerInfo(int id)
        {
            _customers[id].DisplayEntityInfo();
        }

        
    }
}
