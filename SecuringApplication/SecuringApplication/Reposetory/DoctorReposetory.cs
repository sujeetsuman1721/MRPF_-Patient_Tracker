using Microsoft.EntityFrameworkCore;
using SecuringApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public class DoctorReposetory<T> :IReposetory<T> where T : class
    {
        private readonly ApplicationContext context;
    public DoctorReposetory(ApplicationContext context)
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

            return (IReadOnlyCollection<T>)await context.Doctor.Include(x => x.ApplicationUser).ToListAsync();

        }

        public async Task<int> GetByUserId(string id)
        {
            Doctor doctor = await context.Doctor.FirstAsync(p => p.ApplicationUserId == id);



            return doctor.DoctorId;
        }


    }
}
