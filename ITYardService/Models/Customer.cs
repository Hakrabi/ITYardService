using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

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

        public Customer():base()
            //: this(Guid.Empty, string.Empty
        {
        }
        public Customer(Guid customerId, string name)
        {
            base.Id = customerId;
            this.FirstName = name;
            //AddressList = new List<Address>();
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Customer Id - {base.Id}, first name - {this.FirstName}, last name - {this.LastName}");
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
