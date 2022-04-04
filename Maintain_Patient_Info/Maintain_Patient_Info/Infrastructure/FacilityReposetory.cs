using Maintain_Patient_Info.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Infrastructure
{
    public class FacilityReposetory<T> : IRepository<T> where T : class

    {
        private readonly PatientManagementContext context;
        public FacilityReposetory(PatientManagementContext context)
        {

            this.context = context;


        }

        public T Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Delete(T item)
        {
            throw new System.NotImplementedException();
        }

      

        public Task<IReadOnlyCollection<T>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Facilites> GetAsyncBYId(int id)
        {
            Facilites facility = await context.Facilites.FirstAsync(p => p.AppointmentId == id);
            return facility;
        }

        public async Task<Facilites> GetFacilityByIdAsync(int id)
        {
            Facilites facility = await context.Facilites.FirstAsync(p => p.AppointmentId == id);
            return facility;
        }

        public Task<int> SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public T Update(T item)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
