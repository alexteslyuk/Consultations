using AutoMapper;
using Consultations.DTOs;
using Consultations.Models;

namespace Consultations.Mapper.Profiles
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<Consultation, ConsultationDTO>();
            CreateMap<ConsultationDTO, Consultation>();
        }
    }
}
