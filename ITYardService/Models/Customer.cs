using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.Common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using ITYardService.Repository;

namespace ITYardService.Models
{
    [DataContract]
    public class Customer : EntityBase
    {
        [DataMember] public List<Address> AddressList { get; set; }
        [DataMember] public int CustomerType { get; set; }
        [DataMember] public static int InstanceCount { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public string LastName { get; set; }
        [DataMember] public string EmailAddress { get; set; }
        [DataMember] public readonly string FullName;
        [DataMember] public List<Guid>Orders { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }

        public Customer():base()
            //: this(Guid.Empty, string.Empty
        {
        }
        public Customer(Guid customerId, string FirstName, string LastName, string EmailAddress, Gender Gender, int Age)
        {
            base.Id = customerId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.EmailAddress = EmailAddress;
            this.Gender = Gender;
            this.Age = Age;
            Orders = new List<Guid>();
        }

        public override void DisplayEntityInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCustomer {this.FirstName} {this.LastName} :: {base.Id}\n");
            Console.ResetColor();

            foreach (var OrderId in Orders)
            {
                (GenericRepository<Order>._general[OrderId]).DisplayEntityInfo();

            }

            //Console.WriteLine($"Customer Id - {base.Id}, first name - {this.FirstName}, last name - {this.LastName}");
        }
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;

            if (!isValid)
            {
                Logger.LogError("Validate error");
            }

            return isValid;
        }
    }
}
