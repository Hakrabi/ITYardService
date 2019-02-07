using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITYardService.common;
using ITYardService.Models;
using ITYardService.Repository;


namespace ITYardService
{
    class Program
    {
        static void Main(string[] args)
        {

            var GeneralRepository = new GenericRepository<Order>();


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

            var CustomerRepository = new GenericRepository<Customer>();
            CustomerRepository.Insert(customer1);


            //Create new Products and insert it to Repository
            var product1 = new Product(Guid.NewGuid(), "Dice20", "Icosahedral with numbers from 1 to 20 on sides of it", 20);
            var product2 = new Product(Guid.NewGuid(), "Dice12", "Dodecahedron with numbers from 1 to 12 on sides of it", 15);
            var ProductRepository = new GenericRepository<Product>();
            ProductRepository.Insert(product1);
            ProductRepository.Insert(product2);


            //Create OrderRepository
            var OrderRepository = new GenericRepository<Order>();


            //Create first Order and insert it to Repository
            var orderItem1 = new OrderItem(Guid.NewGuid(), product1.Id, 3);
            var orderItem2 = new OrderItem(Guid.NewGuid(), product2.Id, 5);

            var OrderItemRepository1 = new GenericRepository<OrderItem>();
            OrderItemRepository1.Insert(orderItem1);
            OrderItemRepository1.Insert(orderItem2);


            var Order1 = new Order(Guid.NewGuid(), customer1.Id, DateTime.Now, address1, OrderItemRepository1.GetAllID());
            OrderRepository.Insert(Order1);


            //Create second Order and insert it to Repository
            var orderItem3 = new OrderItem(Guid.NewGuid(), product1.Id, 2);

            var OrderItemRepository2 = new GenericRepository<OrderItem>();
            OrderItemRepository2.Insert(orderItem3);


            var Order2 = new Order(Guid.NewGuid(), customer1.Id, DateTime.Now, address1, OrderItemRepository2.GetAllID());
            OrderRepository.Insert(Order2);


            //Delete second Order

            OrderRepository.Delete(Order2.Id);

            //
            var GenreralRepository2 = new GenericRepository<Order>();
            GenreralRepository2.Insert(Order2);

            customer1.DisplayEntityInfo();

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
 