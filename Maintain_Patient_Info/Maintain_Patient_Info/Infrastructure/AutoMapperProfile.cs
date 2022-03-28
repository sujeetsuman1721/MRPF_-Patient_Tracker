using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maintain_Patient_Info.Base;

namespace Maintain_Patient_Info.Infrastructure
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DTO_PM, patient_info>().ReverseMap();
        }

    }
}
