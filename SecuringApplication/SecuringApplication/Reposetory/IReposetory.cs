using System.Threading.Tasks;

namespace SecuringApplication.Reposetory
{
    public interface IReposetory<T> where T : class
    {
        public T Add(T item);

        Task<int> SaveAsync();


    }
}
