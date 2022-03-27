﻿using SecuringApplication.Models;
using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public class GenereicRepository<T> : IReposetory<T> where T : class
    {
        private readonly ApplicationContext context;
        public GenereicRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}