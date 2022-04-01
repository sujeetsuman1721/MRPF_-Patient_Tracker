using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maintain_Patient_Info.Base;
using Maintain_Patient_Info.HospitalServices;
using Maintain_Patient_Info.models;

namespace Maintain_Patient_Info.Infrastructure
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DTO_PM, PatientsRegistory>().ReverseMap();
            CreateMap<LabTestsDTO, LabTests>().ReverseMap();
            CreateMap<ConsultationDTO,Consultation>().ReverseMap();
            CreateMap<RoomDTO, Room>().ReverseMap();
            CreateMap<FacilitiesDTO, Facilites>().ReverseMap();
        }

    }
}
