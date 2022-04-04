using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Infrastructure
{
    public class LabtestsRepository<T> : IRepository<T> where T : class
    {
        private readonly PatientManagementContext context;
        public LabtestsRepository(PatientManagementContext context)
        {

            this.context = context;


        }
        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task<Consultation> GetConsultationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LabTests> GetLabTestsById(int id)
        {
            LabTests labtest = await context.LabTests.FirstAsync(p => p.LabTestId == id);
            return labtest;
        }

        public Task<Room> GetRoomById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }

        Task<Facilites> IRepository<T>.GetAsyncBYId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
