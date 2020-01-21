using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.DataAccessLayer.Repositories
{
    public interface ICustomerRepository<TKey, TEntity> : IRepository<TKey, TEntity> where TKey : struct
                                                                        where TEntity : class
    {

    }
}
