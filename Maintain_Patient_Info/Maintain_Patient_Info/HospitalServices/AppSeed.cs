//using Maintain_Patient_Info.HospitalServices;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HospitalService.Models
//{
//    public static class AppSeed
//    {
//        public static void SeedFacilityAsync(this ModelBuilder modelsBuilder)
//        {
//            modelsBuilder.Entity<Room>().HasData(

//               new Room
//               {

//                   RoomType = "Single",
//                   charge = 4000


//               },
//              new Room
//              {
//                  RoomType = "Single",
//                  charge = 4000
//              },

//              new Room
//              {
//                  RoomType = "Double",
//                  charge = 4000
//              },
//              new Room
//              {

//                  RoomType = "ICU",
//                  charge = 6000
//              },
//              new Room
//              {

//                  RoomType = "Special Rooms",
//                  charge = 6500
//              }
//              );

//            modelsBuilder.Entity<LabTests>().HasData(

//           new LabTests
//           {

//               LabTestName = "Blood Test",
//               LabTestResult = "Completed",
//               Charge = 150
//           },
//           new LabTests
//           {

//               LabTestName = "Creatine Test",
//               LabTestResult = "Pending",
//               Charge = 200
//           },
//             new LabTests
//             {

//                 LabTestName = "Lipid Profile",
//                 LabTestResult = "Completed",
//                 Charge = 100
//             },

//             new LabTests
//             {

//                 LabTestName = "Diabetes Test",
//                 LabTestResult = "Pending",
//                 Charge = 150
//             }
//             );

//            modelsBuilder.Entity<Consultation>().HasData(
//                new Consultation
//                {

//                    DoctorName = "Hari",
//                    Purpose = "skin Problem",
//                    Charge = 4005


//                },
//            new Consultation
//            {
//                DocId = 2,
//                DoctorName = "Rahul",
//                Purpose = "Headache",

//                Charge = 500
//            },
//            new Consultation
//            {
//                DocId = 3,
//                DoctorName = "Kiran",
//                Purpose = "Fever",

//                Charge = 450
//            },
//            new Consultation
//            {
//                DocId = 4,
//                DoctorName = "Srikanth",
//                Purpose = "Stomach Pain",

//                Charge = 500
//            }
//            ); 
//        }
//    }
//}
