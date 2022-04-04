using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Base
{
    public interface IRepository<T> where T:class
    {
        T Add(T item);
        T Delete(T item);
        T Update(T item);
        Task<T> GetAsyncBYId(int id);


        Task<IReadOnlyCollection<T>> GetAsync();
        Task<int> SaveAsync();



    }
}
