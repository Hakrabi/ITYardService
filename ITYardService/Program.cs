using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITYardService
{
    class Program
    {
        static void Main(string[] args)
        {

            //Customer customer1 = new Customer("Very smart user","qwerty12345");
            //customer1.PrintFullName();

            var usr1 = new user("VerySmartUser", "qwerty");
            var usr2 = new user("Someone", "ChiperIsBad");


            var repo = new UserRepository();

            repo.Insert(usr1);
            repo.Insert(usr2);


            var users = repo.All();

            foreach (var user in users)
            {
                user.DisplayInfo();
            }

            repo.DisplayUserInfo(usr1._id);
            repo.DisplayUserInfo(usr2._id);



            Console.ReadKey();

        }
    }
}
