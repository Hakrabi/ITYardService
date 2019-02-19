using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITYardService.Models;
using ITYardService.Repository;

namespace ITYardService.Services
{
    public class CustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Order> _orderRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository, IGenericRepository<Order> orderRepository)
        {
            customerRepository = _customerRepository;
            orderRepository = _orderRepository;

        }

      /*  IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _customerRepository.All();
            var order = _orderRepository.All();

            var ComposedRep = customers.GroupJoin(
                order,
                cust => cust.Id,
                ord => ord.CustomerId,
                (customer, OrdersGroup) => 
                new Customer(customer.LastName, customer);
        }*/
    }
}
