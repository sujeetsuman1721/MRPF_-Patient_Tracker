using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Management_Services
{
    public class PatientRegistry
    {
        
        public int Id { get; set; }
        public string PatientName { get; set; }
        
        public int PatientId { get; set; }
        public string PatientProblem { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
        private  List<DoctorConsaltation> _doctorconsaltations { get; set; } = new List<DoctorConsaltation>();

        public virtual IEnumerable<DoctorConsaltation> doctorconsaltations
        {
            get { return _doctorconsaltations.AsReadOnly(); }
        }
        public PatientRegistry(string patientName, string patientProblem, int doctorId)
        {
            //validation of details
            this.PatientName = patientName;
            this.PatientProblem = patientProblem;
            this.DoctorId = doctorId;
            this.Date = DateTime.Now;
           

        }
        public void AddDoctorConsaltation(DoctorConsaltation doctorconsaltations)
        {
            if (doctorconsaltations == null)
                throw new ArgumentException($"Cannot be null : {nameof(doctorconsaltations)}");
        }















        }
    }
