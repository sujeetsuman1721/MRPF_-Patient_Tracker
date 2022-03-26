using SecuringApplication.Models;
using SecuringApplication.Models.Registration;

namespace SecuringApplication.Reposetory
{
    public class DoctorReposetory
    {
        private readonly ApplicationContext context;
        public DoctorReposetory(ApplicationContext context)
        {
            this.context = context;
        }

        public void InsertData(Doctor doctor)
        {
            context.Add(doctor);

        }
    }
}
