using SecuringApplication.Models;

namespace SecuringApplication.Reposetory
{
    public class PatienReposetory
    {
        private readonly ApplicationContext context;
        public PatienReposetory(ApplicationContext context)
        {
            this.context = context;
        }

        public void InsertData(Patient patient)
        {
            context.Add(patient);

        }
    }
}
