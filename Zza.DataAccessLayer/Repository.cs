using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.DataAccessLayer
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TKey : struct
                                                                        where TEntity : class
    {
        public abstract void Add(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract List<TEntity> GetAllEntities();
        public abstract TEntity GetById(TKey id);
        public abstract void Update(TEntity updatedEntity);
    }
}
