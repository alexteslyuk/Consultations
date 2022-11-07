using AutoMapper;
using Consultations.DTOs;
using Consultations.Models;

namespace Consultations.Mapper.Profiles
{
    public class PatientProfile : Profile
    {
        private const int YearLength = 365;

        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>()
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => (DateTime.Now.Subtract(src.BirthDate)).Days / YearLength));
            CreateMap<PatientDTO, Patient>();
        }
    }
}
