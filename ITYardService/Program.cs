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
            //LessonTask

            //Вызов скрытых методов         
            var address1 = new Address(1);
            address1.City = "Poltava";
            address1.Country = "Ukraine";
            var customer1 = new Customer(1, "Andrii");
            customer1.LastName = "Kononenko";

            var product1 = new Product(1,"Dice20", "Icosahedral with numbers from 1 to 20 on sides of it", 18);
            var product2 = new Product(2,"Dice12", "Dodecahedron with numbers from 1 to 12 on sides of it", 18);

            var orderItem1 = new OrderItem(1,product1,3,18);
            var orderItem2 = new OrderItem(2, product2, 5, 18);


            var list = new List<OrderItem>();
            list.Add(orderItem1);
            list.Add(orderItem2);

            var Order = new Order(1,customer1,DateTime.Now,address1,list);

            Order.DisplayEntityInfo();

            Console.ReadLine();





            //Customer customer1 = new Customer("Very smart user","qwerty12345");
            //customer1.PrintFullName();

            /*
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

            Console.WriteLine("\nDecrypt");

            repo.DisplayUserInfoDecrypt(usr1._id);
            repo.DisplayUserInfoDecrypt(usr2._id);
            */
            Console.ReadKey();

        }
    }
}