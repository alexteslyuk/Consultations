using AutoMapper;
using Consultations.DTOs;
using Consultations.Models;

namespace Consultations.Mapper.Profiles
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<Consultation, ConsultationDTO>()
                .ForMember(dst => dst.PatientId, opt => opt.MapFrom(src => src.Patient.Id));
            CreateMap<ConsultationDTO, Consultation>();
        }
    }
}
