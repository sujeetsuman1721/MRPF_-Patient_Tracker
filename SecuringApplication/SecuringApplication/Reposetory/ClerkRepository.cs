using SecuringApplication.Models;
using SecuringApplication.Models.Registration;

namespace SecuringApplication.Reposetory
{
    public class ClerkRepository
    {

        private readonly ApplicationContext context;
        public ClerkRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void InsertData(Clerk clerk)
        {
            context.Add(clerk);

        }

    }
}
