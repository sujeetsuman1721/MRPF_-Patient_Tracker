using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Models
{
    public class AppSeed
    {
        public async Task SeedUsersAsync()
        {
            var sampath = new Room
            {
                Num = 01,
                Type = "Single",
                Charges = 5000
            };
            var rahul = new Room
            {
                Num = 02,
                Type = "Double",
                Charges = 2500
            };
            var sara = new Room
            {
                Num = 03,
                Type = "General Ward",
                Charges = 500
            };
            var sankeerth = new Room
            {
                Num = 04,
                Type = "ICU",
                Charges = 6000
            };
            var rakesh = new Room
            {
                Num = 05,
                Type = "Special Rooms",
                Charges = 6500
            };
            var nithish = new LabTests
            {
                Id = 1,
                Name = "Blood Test",
                Result = "Completed",
                Charges = 150
            };
            var bhavana = new LabTests
            {
                Id = 2,
                Name = "Creatine Test",
                Result = "Pending",
                Charges= 200
            };
            var samhitha = new LabTests
            {
                Id = 3,
                Name = "Lipid Profile",
                Result = "Completed",
                Charges=100
            };
            var mahesh = new LabTests
            {
                Id = 4,
                Name = "Diabetes Test",
                Result = "Pending",
                Charges=150
            };
            var anusha = new Consultation
            {
                DocId=1,
                DocName = "Hari",
                Purpose = "skin Problem",
                Prescription = "Aciclovir",
                Diet = "Avoid Oily Food and Eat Healthy Vegetables",
              Charges=450
            };
            var sindhu = new Consultation
            {
                DocId=2,
                DocName = "Rahul",
                Purpose = "Headache",
                Prescription="Sumaptriptan",
                Diet="Avoid soft drinks and Ice creams",
                Charges=500
            };
            var niveditha = new Consultation
            {
                DocId=3,
                DocName = "Kiran",
                Purpose = "Fever",
                Prescription="Aspirin",
                Diet="Eat Chicken Soup,eat spicy foods,drink coconut water",
                Charges=450
            };
            var bindhu = new Consultation
            {
                DocId=4,
                DocName = "Srikanth",
                Purpose = "Stomach Pain",
                Prescription="Doxycycline",
                Diet="Eat bananas,rice,applesauce and toast",
                Charges=500
            };
        }
    }
}
