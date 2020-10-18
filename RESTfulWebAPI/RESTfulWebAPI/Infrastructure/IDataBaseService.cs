using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Infrastructure
{
    public interface IDataBaseService
    {
        DbSet<MovieEntity> Movie { get; set; }
        void Save();
    }
}
