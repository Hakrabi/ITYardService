using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.Common;
using ITYardService.Models;
using ITYardService.Repository;


namespace ITYardService
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateRepository
            var CustomerRepository = new GenericRepository<Customer>();
            var OrderRepository = new GenericRepository<Order>();
            var ProductRepository = new GenericRepository<Product>();



            //Create first Customer and insert it to Repository
            var customer1 = new Customer(Guid.NewGuid(), "Dmitry", "Dudnik", "hakrabi@vasya.com", Common.Gender.Male,18);
            var customer2 = new Customer(Guid.NewGuid(), "Bogdan", "Chopivsky", "wakka@vasya.com", Common.Gender.Male, 17);
            var customer3 = new Customer(Guid.NewGuid(), "Eugene", "Shtofel", "shtompel@vasya.com", Common.Gender.Male, 18);
            var customer4 = new Customer(Guid.NewGuid(), "Roman", "Derkach", "duck@vasya.com", Common.Gender.Male, 20);
            var customer5 = new Customer(Guid.NewGuid(), "Not", "Sure", "Yeah@vasya.com", Common.Gender.Male, 42);

            CustomerRepository.Insert(customer1);
            CustomerRepository.Insert(customer2);
            CustomerRepository.Insert(customer3);
            CustomerRepository.Insert(customer4);
            CustomerRepository.Insert(customer5);


            //Create new Products and insert it to Repository
            var product1 = new Product(Guid.NewGuid(), "Dice20", "Icosahedral with numbers from 1 to 20 on sides of it", 20);
            var product2 = new Product(Guid.NewGuid(), "Dice12", "Dodecahedron with numbers from 1 to 12 on sides of it", 15);
            ProductRepository.Insert(product1);
            ProductRepository.Insert(product2);

            //Create first Order and insert it to Repository
            var orderItem1 = new OrderItem(Guid.NewGuid(), product1.Id, 3);
            orderItem1.Color = Common.Color.Blue | Common.Color.Red;
            orderItem1.Color = orderItem1.Color ^ Common.Color.Red;

            var orderItem2 = new OrderItem(Guid.NewGuid(), product2.Id, 5);

            var OrderItemRepository1 = new GenericRepository<OrderItem>();
            OrderItemRepository1.Insert(orderItem1);
            OrderItemRepository1.Insert(orderItem2);


            var Order1 = new Order(Guid.NewGuid(), customer1.Id, DateTime.Now, OrderItemRepository1.GetAllID());
            OrderRepository.Insert(Order1);


            //Create second Order and insert it to Repository
            var orderItem3 = new OrderItem(Guid.NewGuid(), product1.Id, 2);

            var OrderItemRepository2 = new GenericRepository<OrderItem>();
            OrderItemRepository2.Insert(orderItem3);


            var Order2 = new Order(Guid.NewGuid(), customer2.Id, DateTime.Now, OrderItemRepository2.GetAllID());
            OrderRepository.Insert(Order2);


            //Delete second Order

            OrderRepository.Delete(Order2.Id);

            //
            var GenreralRepository2 = new GenericRepository<Order>();
            GenreralRepository2.Insert(Order2);


            foreach (var Customer in CustomerRepository.All())
            {
                Customer.DisplayEntityInfo();
            }



            // var an = new { FirstName = "SSS" };

            //var customers = CustomerRepository.All().ToList();
            //Predicate<Customer> predicate = new Predicate<Customer>(StartWith);
            // var item = customers.Where(cust => cust.LastName.StartsWith("D", StringComparison.OrdinalIgnoreCase)).Select( x => new { id = x.Id, FirstNmae = x.FirstName });





            /*
            //Create first Customer and insert it to Repository
            var customer1 = new Customer(Guid.NewGuid(), "Dmitry");
            customer1.LastName = "Dudnik";
            customer1.EmailAddress = "hakrabi@vasya.com";

            var address1 = new Address(Guid.NewGuid());
            address1.City = "Poltava";
            address1.Country = "Ukraine";

            var AddressList = new List<Address>();
            AddressList.Add(address1);
            customer1.AddressList = AddressList;

            var CustomerRepository = new CustomerRepository();
            CustomerRepository.Insert(customer1);


            //Create new Products and insert it to Repository
            var product1 = new Product(Guid.NewGuid(), "Dice20", "Icosahedral with numbers from 1 to 20 on sides of it", 20);
            var product2 = new Product(Guid.NewGuid(), "Dice12", "Dodecahedron with numbers from 1 to 12 on sides of it", 15);
            var ProductRepository = new ProductRepository();
            ProductRepository.Insert(product1);
            ProductRepository.Insert(product2);


            //Create OrderRepository
            var OrderRepository = new OrderRepository();


            //Create first Order and insert it to Repository
            var orderItem1 = new OrderItem(Guid.NewGuid(), product1, 3);
            var orderItem2 = new OrderItem(Guid.NewGuid(), product2, 5);

            var OrderItemRepository1 = new OrderItemRepository();
            OrderItemRepository1.Insert(orderItem1);
            OrderItemRepository1.Insert(orderItem2);


            var Order1 = new Order(Guid.NewGuid(), customer1, DateTime.Now, address1, OrderItemRepository1);
            OrderRepository.Insert(Order1);


            //Create second Order and insert it to Repository
            var orderItem3 = new OrderItem(Guid.NewGuid(), product1, 2);

            var OrderItemRepository2 = new OrderItemRepository();
            OrderItemRepository2.Insert(orderItem3);


            var Order2 = new Order(Guid.NewGuid(), customer1, DateTime.Now, address1, OrderItemRepository2);
            OrderRepository.Insert(Order2);


            //Delete second Order

            OrderRepository.Delete(Order2.Id);

            //
            var GenreralRepository2 = new GeneralRepositoryJSON();
            GenreralRepository2.Insert(Order2);
             */

            Console.ReadKey();

        }
    }
}
 