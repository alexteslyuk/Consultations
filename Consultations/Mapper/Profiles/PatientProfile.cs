using AutoMapper;
using Consultations.DTOs;
using Consultations.Models;

namespace Consultations.Mapper.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
        }
    }
}
