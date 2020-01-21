using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.DataAccessLayer;
using Zza.DataAccessLayer.ConcreteRepositories;
using Zza.DataAccessLayer.Repositories;
using Zza.Entities;

namespace Zza.BusinessLogicLayer.Data
{
    public class ZzaDataService : IZzaDataService
    {
        private ApplicationDbContext _applicationDbContext;
        private ICustomerRepository<Guid,Customer> _customerRepository;
        private IOrderRepository<long, Order> _orderRepository;
        private IProductRepository<int, Product> _productRepository;
        public ZzaDataService()
        {
            _applicationDbContext = new ApplicationDbContext();
            _customerRepository = new CustomerRepository(_applicationDbContext);
            _orderRepository = new OrderRepository(_applicationDbContext);
            _productRepository = new ProductRepository(_applicationDbContext);
        }
        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
        }

        public void AddProducts(Product product)
        {
            _productRepository.Add(product);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllEntities();
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllEntities();
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllEntities();
        }
    }
}
