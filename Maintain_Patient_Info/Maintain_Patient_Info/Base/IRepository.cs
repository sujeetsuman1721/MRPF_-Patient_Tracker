using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.Base
{
    public interface IRepository<T> where T:class
    {
        T add(T item);
        T delete(T item);
        T update(T item);

        Task<IReadOnlyCollection<T>> GetAsync();
        Task<int> SaveAsync();


    }
}
