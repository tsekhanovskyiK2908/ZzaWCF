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
    public class OrderItemRepository : Repository<Guid, OrderItem>, IOrderItemRepository<Guid, OrderItem>
    {
        private ApplicationDbContext _applicationDbContext;

        public OrderItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public override void Add(OrderItem entity)
        {
            _applicationDbContext.OrderItems.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public override void Delete(OrderItem entity)
        {
            _applicationDbContext.OrderItems.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public override List<OrderItem> GetAllEntities()
        {
            return _applicationDbContext.OrderItems.ToList();
        }

        public override OrderItem GetById(Guid id)
        {
            return _applicationDbContext.OrderItems.FirstOrDefault(oi => oi.Id == id);
        }

        public override void Update(OrderItem updatedEntity)
        {
            var orderItem = GetById(updatedEntity.Id);

            if(orderItem != null)
            {
                _applicationDbContext.OrderItems.Attach(orderItem);
                _applicationDbContext.Entry(orderItem).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
