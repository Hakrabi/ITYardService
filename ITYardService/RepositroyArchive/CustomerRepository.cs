using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace ITYardService.Repository
{
    public class CustomerRepository
    {

        public static Dictionary<Guid, Customer> _customers = new Dictionary<Guid, Customer>();

        public Customer[] All()
        {
            return (_customers.Values).ToArray();
        }

        public void Insert(Customer Customer)
        {
            if (Customer.Validate())
            {
                _customers.Add(Customer.Id, Customer);

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Customer));
                using (FileStream fs = new FileStream("object.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, Customer);
                }

                Logger.LogInfo($"Customer {Customer.Id} was inserted");

            }
        }

        public Customer GetById(Guid id)
        {
            return _customers[id];
        }

        public void Update(Guid id, Customer Customer) 
        {
            _customers[id] = Customer;
        }

        public void Delete(Guid id)
        {
            if (_customers.ContainsKey(id))
            {
                _customers.Remove(id);
                Logger.LogInfo($"User {id} was deleted");
                return;
            }
            Logger.LogError("Id not exist");
        }

        public void DisplayCustomerInfo(Guid id)
        {
            _customers[id].DisplayEntityInfo();
        }

        
    }
}
