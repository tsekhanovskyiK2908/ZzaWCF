using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.DataAccessLayer.Repositories
{
    public interface IProductRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TKey : struct
                                                                        where TEntity : class
    {

    }
}
