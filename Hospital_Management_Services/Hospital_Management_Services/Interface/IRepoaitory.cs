using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Services
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        Task<int> SaveAsync();
        IReadOnlyCollection<T> Get(BaseSpecification<T> spec);
    }
}
