using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services.Models
{
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private readonly BillingContext context;
        public GenericRepository(BillingContext context)
        {

            this.context = context;


        }


        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }

        public T Update(T item)
        {

            return context.Update(item).Entity;
        }

        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(string username)
        {
            return await context.Set<T>().FindAsync(username);
        }

        public T Add(T item)
        {
            return context.Add(item).Entity;
        }




    }
}
