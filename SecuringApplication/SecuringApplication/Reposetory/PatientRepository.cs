using Microsoft.EntityFrameworkCore;
using SecuringApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public class PatientRepository<T>: IReposetory<T> where T : class
    {
        private readonly ApplicationContext context;
        public PatientRepository(ApplicationContext context)
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
        public async Task<IReadOnlyCollection<T>> GetAsync()
        {

            return (IReadOnlyCollection<T>)await context.Patient.Include(x => x.ApplicationUser).ToListAsync();

        }


        public async Task<int> GetByUserId(string id)
        {

            Patient patient = await context.Patient.FirstAsync(p => p.ApplicationUserId == id);



            return patient.PatientId;
        }

    }
}
