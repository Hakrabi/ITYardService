using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    class Customer
    {
        string _firstname;
        string _lastname;

        public Customer(string firstname, string lastname)
        {
            _firstname = firstname;
            _lastname = lastname;
        }

        public void PrintFullName()
        {
            Console.WriteLine($"Full name is {_firstname} {_lastname}");
        }

    }
}
