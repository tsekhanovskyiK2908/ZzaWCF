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
    public class ProductRepository : Repository<Guid, Product>, IProductRepository<Guid, Product>
    {
        private ApplicationDbContext _applicationDbContext;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public override void Add(Product entity)
        {
            _applicationDbContext.Products.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public override void Delete(Product entity)
        {
            _applicationDbContext.Products.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public override List<Product> GetAllEntities()
        {
            return _applicationDbContext.Products.ToList();
        }

        public override Product GetById(Guid id)
        {
            return _applicationDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public override void Update(Product updatedEntity)
        {
            var product = GetById(updatedEntity.Id);

            if(product!=null)
            {
                _applicationDbContext.Products.Attach(updatedEntity);
                _applicationDbContext.Entry(updatedEntity).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
