using Maintain_Patient_Info.HospitalServices;
using Maintain_Patient_Info.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain_Patient_Info.HospitalServices
{
    public class AppSeed
    {
        /*private readonly PatientManagementContext context;

        public AppSeed(PatientManagementContext context)
        {
            this.context = context;
        }
        public void SeedUsersAsync()
        {
            var LabTests = new List<LabTests>
            {
                new LabTests{LabTestName="BloodTest",LabTestResult="O+"},
                new LabTests{LabTestName="CovidTest",LabTestResult="Negative"},
                new LabTests{LabTestName="CreatineTest",LabTestResult="14.4"}

            };
            LabTests.ForEach(l => context.labTests.Add(l));
            context.SaveChanges();
            var PrescriptionDetails = new List<PrescriptionDetails>
            {
                new PrescriptionDetails{PrescriptionId="AOMB12",MedicineDetails="Paracetemol",Quantity=2},
                new PrescriptionDetails{PrescriptionId="BNM056",MedicineDetails="Dolo650",Quantity=1}

            };
            PrescriptionDetails.ForEach(p => context.prescriptionDetails.Add(p));
            context.SaveChanges();
            var consultation = new List<Consultation>
            {
                new Consultation{DocName="Prabhakar",Purpose="Rmp"},
                new Consultation{DocName="Chandini",Purpose="CovidTest"}

            };
            consultation.ForEach(c => context.consultation.Add(c));
            context.SaveChanges();
            var room = new List<Room>
            {
                new Room{RoomType="General",NoOfDays=2,Num=102},
                new Room{RoomType="General",NoOfDays=1,Num=101}

            };
            room.ForEach(r => context.rooms.Add(r));
            context.SaveChanges();
        }*/
    }
}
