using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.Common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ITYardService.Models
{
    [DataContract]
    public abstract class EntityBase
    {
        [DataMember] public Guid Id { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.Id}");
        }

        public abstract bool Validate();
    }
}
