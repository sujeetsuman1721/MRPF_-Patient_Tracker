using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Infrastructure
{
    public class RoomRepository<T> : IRepository<T> where T : class
    {
        private readonly PatientManagementContext context;
        public RoomRepository(PatientManagementContext context)
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
        public async Task<Room> GetRoomById(int id)
        {
            Room room = await context.Rooms.FirstAsync(p => p.RoomId== id);
            return room;
        }

        public Task<LabTests> GetLabTestsById(int id)
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

        public Task<Consultation> GetConsultationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
