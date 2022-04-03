using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public interface IReposetory<T> where T : class
    {
        public T Add(T item);
        Task<IReadOnlyCollection<T>> GetAsync();

        Task<int> SaveAsync();
<<<<<<< HEAD
        //Task<IReadOnlyCollection<T>> GetUserDetailsAsync();
=======
        

>>>>>>> 3f501adbc82ee9a85edd2d4a8ea5cb1e0d4fd621

         Task<int> GetByUserId(string id);
    }
}
