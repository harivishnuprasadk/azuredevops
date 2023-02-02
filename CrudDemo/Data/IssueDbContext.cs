using System;
using CrudDemo.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudDemo.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            : base(options)
        {
        }
        public DbSet<Issue> Issues { get; set; }
    }
}

