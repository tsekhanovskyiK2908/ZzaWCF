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
    public class OrderRepository : Repository<long, Order>, IOrderRepository<long, Order>
    {
        private ApplicationDbContext _applicationDbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public override void Add(Order entity)
        {
            _applicationDbContext.Orders.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public override void Delete(Order entity)
        {
            _applicationDbContext.Orders.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public override List<Order> GetAllEntities()
        {
            return _applicationDbContext.Orders.ToList();
        }

        public override Order GetById(long id)
        {
            return _applicationDbContext.Orders.FirstOrDefault(o => o.Id == id);
        }

        public override void Update(Order updatedEntity)
        {
            var order = GetById(updatedEntity.Id);

            if(order != null)
            {
                _applicationDbContext.Orders.Attach(updatedEntity);
                _applicationDbContext.Entry(updatedEntity).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
