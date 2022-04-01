using AutoMapper;
using Billing_Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing_Services.Models
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BillingDTO, BillingServices>().ReverseMap();
        }
    }
}
