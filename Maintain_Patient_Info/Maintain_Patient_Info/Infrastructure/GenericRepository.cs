using Maintain_Patient_Info.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private readonly PatientManagementContext context;
        public GenericRepository(PatientManagementContext context) => this.context = context;
        public T add(T item)
        {
            return context.Add(item).Entity;
        }

        public T delete(T item)
        {
            return context.Remove(item).Entity;
        }
        public T update(T item)
        {
            return context.Update(item).Entity;
        }
       

        public async Task<T> GetAsync(int id)

        {​​​​​

            return await context.Set<T>().FindAsync(id);

        }​​​​​




        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

       



    }
}
