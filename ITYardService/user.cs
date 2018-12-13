using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    public class user
    {
        public Guid _id;
        public string _username;
        public string _password { get;  set; }

        public user()
        {
            this._id = Guid.NewGuid();
        }

        public user(string username, string password):this()
        {
            this._username = username;
            this._password = password;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Username - {this._username} and password - {this._password}");
        }

    }

}
