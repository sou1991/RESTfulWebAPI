using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Infrastructure
{
    public class DataBaseService : DbContext,IDataBaseService
    {
        public DataBaseService(DbContextOptions<DataBaseService> options)
            : base(options)
        {

        }

        public DbSet<MovieEntity> Movie { get; set; }
        public void Save()
        {
            base.SaveChanges();
        }
    }
}
