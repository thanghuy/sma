using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Domain.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> GetById(ObjectId id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Update(ObjectId id, TEntity obj);
        Task<bool> Remove(ObjectId id);
    }
}
