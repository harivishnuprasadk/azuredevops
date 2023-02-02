using System;
using CrudDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudDemo.Repository
{
    public interface IRepository<T1,T2> where T1: class
    {
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetById(T2 id);
        Task<T1> Insert(T1 entity);
        Task Delete(T2 id);
        Task Save();
        Task Update(int id, Issue issue);
    }
}
