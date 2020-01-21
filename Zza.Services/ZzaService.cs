using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;
using Zza.BusinessLogicLayer;
using Zza.BusinessLogicLayer.Data;

namespace Zza.Services
{   
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class ZzaService : IZzaService
    {   
        private readonly IZzaDataService _zzaDataService = new ZzaDataService();
        public List<Customer> GetCustomers()
        {
            return _zzaDataService.GetAllCustomers();
        }

        public List<Product> GetProducts()
        {
            return _zzaDataService.GetAllProducts();
        }

        public void SubmitOrder(Order order)
        {
            _zzaDataService.AddOrder(order);
        }
    }
}
