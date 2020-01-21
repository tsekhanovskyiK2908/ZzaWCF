using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;

namespace Zza.BusinessLogicLayer.Data
{
    public interface IZzaDataService
    {   
        //Customers
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        //Orders
        List<Order> GetAllOrders();
        void AddOrder(Order order);
        //Products
        List<Product> GetAllProducts();
        void AddProducts(Product product)
       
    }
}
