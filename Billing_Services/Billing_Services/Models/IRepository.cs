using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services.Models
{
    public interface IRepository
   <T> where T : class
    {
        T Add(T item);
        T Delete(T item);
        T Update(T item);
        Task<T> GetAsync(string username);


        Task<IReadOnlyCollection<T>> GetAsync();
        Task<int> SaveAsync();

        Task<BillingServices> GetBillyAppointId(int id);
        



    }
}
