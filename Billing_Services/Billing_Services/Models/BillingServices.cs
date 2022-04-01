using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Billing_Services.Models
{
    public class BillingServices
    {
        [Key]
        public int Id { get; set; }
        public int ConsultationCharges { get; set; }
        public int LabTestCharges { get; set; }
        public int RoomCharges { get; set; }

        internal static Task<IEnumerable<BillingServices>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
