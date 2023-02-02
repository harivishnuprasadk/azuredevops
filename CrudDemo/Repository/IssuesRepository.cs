using System;
using CrudDemo.Models;
using CrudDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CrudDemo.Repository
{
    public class IssuesRepository:IRepository<Issue, int>
    {

        private readonly IssueDbContext context;
        public IssuesRepository(IssueDbContext context)
        {
            this.context = context;
        }
       
        async Task<IEnumerable<Issue>> IRepository<Issue, int>.GetAll()
        {
            return await context.Issues.ToListAsync();
        }

        async Task<Issue> IRepository<Issue, int>.GetById(int id)
        {
            
            return await context.Issues.FindAsync(id);
           
        }

        async Task<Issue> IRepository<Issue, int>.Insert(Issue entity)
        {
            await context.Issues.AddAsync(entity);
            return entity;
        }

        async Task IRepository<Issue, int>.Delete(int id)
        {
            var issuesToDelete = await context.Issues.FindAsync(id);
  
                if (issuesToDelete != null)
                {
                    context.Issues.Remove(issuesToDelete);
                }
                else
                {
                    throw new Exception("elem not found");
                }
        }

        async Task IRepository<Issue, int>.Save()
        {
            await context.SaveChangesAsync();
        }

        async Task IRepository<Issue, int>.Update(int id, Issue issue)
        {
            context.Entry(issue).State = EntityState.Modified;
           
        }
    }
}

