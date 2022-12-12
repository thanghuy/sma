using MongoDB.Driver;
using SMA.Domain.Base;
using SMA.Domain.Entities;
using SMA.Domain.Interfaces;
using SMA.Repository.Base;
using SMA.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Repository.Repository
{
    public class SmaUserRepository : BaseRepository<SmaUser>, ISmaUserRepository
    {
        public SmaUserRepository(IMongoContext db) : base(db)
        {
        }
    }
}
