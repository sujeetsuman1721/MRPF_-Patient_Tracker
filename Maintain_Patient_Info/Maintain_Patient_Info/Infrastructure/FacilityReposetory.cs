using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
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
            return context.Add(item).Entity;
        }
        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<Facilites> GetAsyncBYId(int id)
        {
            Facilites facility = await context.Facilites.FirstAsync(p => p.AppointmentId == id);
            return facility;
        }

        public Task<Consultation> GetConsultationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Facilites> GetFacilityByAsyncBYId(int id)
        {
            Facilites facility = await context.Facilites.FirstAsync(p => p.AppointmentId == id);
            return facility;
        }

        public Task<LabTests> GetLabTestsById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetRoomById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public T Update(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
