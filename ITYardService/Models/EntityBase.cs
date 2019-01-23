using System;
using System.Collections.Generic;
using System.Text;
using ITYardService.common;

namespace ITYardService.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void DisplayEntityInfo()
        {
            Console.WriteLine($"Id - {this.Id}, name - {this.Name}");
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                Logger.LogError("Validate error");
                return false;
            }
            return true;
        }
    }
}
