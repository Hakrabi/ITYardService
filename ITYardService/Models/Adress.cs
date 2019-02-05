using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public class Address : EntityBase
    {
        public Address()
        {
        }
        public Address(Guid addressId)
        {
            base.Id = addressId;
        }
        [DataMember] public int AddressType { get; set; }
        [DataMember] public string StreetLine1 { get; set; }
        [DataMember]  public string StreetLine2 { get; set; }
        [DataMember] public string City { get; set; }
        [DataMember] public string State { get; set; }
        [DataMember] public string PostalCode { get; set; }
        [DataMember] public string Country { get; set; }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Address Id - {base.Id}, country - {this.Country}, city - {this.City}");
        }
        public override bool Validate()
        {
            return true;
        }
    }
}
