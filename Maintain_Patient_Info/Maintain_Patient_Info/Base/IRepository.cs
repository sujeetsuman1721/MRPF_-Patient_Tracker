using Maintain_Patient_Info.HospitalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Base
{
    public interface IRepository<T> where T:class
    {
        T Add(T item);
        T Update(T item);

        Task<Facilites> GetAsyncBYId(int id);
        Task<Consultation> GetConsultationById(int id);
        Task<LabTests> GetLabTestsById(int id);
        Task<Room> GetRoomById(int id);


        Task<IReadOnlyCollection<T>> GetAsync();
        Task<int> SaveAsync();

        Task<Facilites> GetFacilityByIdAsync(int id);



    }
}
