using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.DataAccessLayer
{
    public interface IRepository<TKey, TEntity> where TKey : struct 
                                                where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(TKey id);
        void Update(TEntity updatedEntity);
        void Delete(TEntity entity);
        List<TEntity> GetAllEntities();
    }
}
