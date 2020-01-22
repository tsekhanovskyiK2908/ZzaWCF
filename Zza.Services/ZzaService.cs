using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;
using Zza.BusinessLogicLayer;
using Zza.BusinessLogicLayer.Data;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Claims;

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

        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Users")]
        public List<Product> GetProducts()
        {
            var principal = Thread.CurrentPrincipal;

            if(!principal.IsInRole("BUILTIN\\Users"))
            {
                throw new SecurityException("Access Denied");
            }

            //ClaimsPrincipal.Current.HasClaim;

            return _zzaDataService.GetAllProducts();
        }

        public void SubmitOrder(Order order)
        {
            _zzaDataService.AddOrder(order);
        }
    }
}
