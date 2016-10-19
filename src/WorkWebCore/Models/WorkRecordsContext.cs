using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkWebCore.Models
{
    public class WorkRecordsContext:DbContext
    {
        
        //public WorkRecordsContext(DbContextOptions<WorkRecordsContext> options) : base(options)
        //{
        
        //}

        public DbSet<Employee> employees { get; set; }

        public DbSet<WorkRecords> WorkRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(@"server=192.168.5.69;userid=root;pwd=root;port=3306;database=test;sslmode=none;");
        //@"server =192.168.5.69;userid=root;pwd=root;port=3306;database=test;sslmode=none;
    }
}
