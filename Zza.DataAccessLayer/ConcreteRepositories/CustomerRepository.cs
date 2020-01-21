using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.DataAccessLayer.Repositories;
using Zza.Entities;

namespace Zza.DataAccessLayer.ConcreteRepositories
{
    public class CustomerRepository : Repository<Guid, Customer>, ICustomerRepository<Guid, Customer>
    {
        private ApplicationDbContext _applicationDbContext;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public override void Add(Customer entity)
        {
            _applicationDbContext.Customers.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public override void Delete(Customer entity)
        {
            _applicationDbContext.Customers.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public override List<Customer> GetAllEntities()
        {
            return _applicationDbContext.Customers.ToList();
        }

        public override Customer GetById(Guid id)
        {
            return _applicationDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public override void Update(Customer updatedEntity)
        {
            var customer = GetById(updatedEntity.Id);

            if(customer != null)
            {
                _applicationDbContext.Customers.Attach(updatedEntity);
                _applicationDbContext.Entry(updatedEntity).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
