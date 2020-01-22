﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Zza.Client.ZzaServices;
using Zza.Entities;

namespace Zza.Client
{
    public class ZzaProxy : ClientBase<IZzaService>, IZzaService
    {
        public ZzaProxy()
        {

        }

        public ZzaProxy(string endpointName) : base(endpointName)
        {

        }

        public ZzaProxy(Binding binding, string address) : base(binding, new EndpointAddress(address))
        {

        }
        public ObservableCollection<Customer> GetCustomers()
        {
            return Channel.GetCustomers();
        }

        public Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            return Channel.GetCustomersAsync();
        }

        public ObservableCollection<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public Task<ObservableCollection<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            Channel.SubmitOrder(order);
        }

        public Task SubmitOrderAsync(Order order)
        {
             return Channel.SubmitOrderAsync(order);
        }
    }
}
