using SMA.Domain.Entities;
using SMA.Domain.Interfaces.Repositories;
using SMA.Repository.Base;
using SMA.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Repository.Repository
{
    public class SmaStaticFileRepository : BaseRepository<SmaStaticFile>, ISmaStaticFileRepository
    {
        public SmaStaticFileRepository(IMongoContext db) : base(db)
        {
        }
    }
}
