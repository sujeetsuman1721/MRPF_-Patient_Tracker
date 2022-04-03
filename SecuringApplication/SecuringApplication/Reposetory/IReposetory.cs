using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public interface IReposetory<T> where T : class
    {
        public T Add(T item);
        Task<IReadOnlyCollection<T>> GetAsync();

        Task<int> SaveAsync();
        


         Task<int> GetByUserId(string id);
    }
}
