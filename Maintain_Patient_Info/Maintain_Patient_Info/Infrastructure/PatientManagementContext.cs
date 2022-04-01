using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;


namespace Maintain_Patient_Info.Infrastructure
{
    public class PatientManagementContext : DbContext

    {
        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {

        }

        public virtual DbSet<PatientsRegistory> PatientsRegistory { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; }

        public virtual DbSet<Consultation> Consultation { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }


        public virtual DbSet<PatientsRegistory> Patient_Infos { get; set; }
     
        public virtual DbSet<Room> RoomDetails { get; set; }


        public virtual DbSet<PatientsRegistory> PatientsRegistories { get; set; }
        public virtual DbSet<Facilites> Facilites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelsBuilder)
        {
            modelsBuilder.Entity<Room>().HasData(

               new Room
               {

                   RoomId = 1,
                   RoomType = "Single",
                   charge = 4000


               },
              new Room
              {
                  RoomId = 2,
                  RoomType = "Single",
                  charge = 4000
              },

              new Room
              {
                  RoomId = 3,
                  RoomType = "Double",
                  charge = 4000
              },
              new Room
              {
                  RoomId = 4,
                  RoomType = "ICU",
                  charge = 6000
              },
              new Room
              {
                  RoomId = 5,
                  RoomType = "Special Rooms",
                  charge = 6500
              }
              );

            modelsBuilder.Entity<LabTests>().HasData(

           new LabTests
           {
               LabTestId = 1,
               LabTestName = "Blood Test",
               LabTestResult="Pending",
               Charge = 150
           },
           new LabTests
           {
               LabTestId = 2,

               LabTestName = "Creatine Test",
               LabTestResult = "Pending",
               Charge = 200
           },
             new LabTests
             {
                 LabTestId = 3,

                 LabTestName = "Prick Test",
                 LabTestResult = "Completed",
                 Charge = 100
             },

             new LabTests
             {
                 LabTestId = 4,

                 LabTestName = "Diabetes Test",
                 LabTestResult = "Pending",
                 Charge = 150
             }
             );

            modelsBuilder.Entity<Consultation>().HasData(
                new Consultation
                {
                    ConsultationId=1,
                    Purpose = "skin Problem",
                    Charge = 4005


                },
            new Consultation
            {
                ConsultationId=2,
                Purpose = "Cardiac CheckUp",

                Charge = 500
            },
            new Consultation
            {
                ConsultationId=3,
                Purpose = "Kidney CheckUp",

                Charge = 450
            },
            new Consultation
            {
               ConsultationId=4,
                Purpose = "Sugar CheckUp",

                Charge = 500
            }
            );
        }



    }
}
