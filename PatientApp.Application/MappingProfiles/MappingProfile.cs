using PatientApp.Application.DTOs;
using PatientApp.Domain.Entities;
using AutoMapper;

namespace PatientApp.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Appointments,
                    opt => opt.MapFrom(src => src.Appointments));

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.MeetingTypeDescription,
                    opt => opt.MapFrom(src => src.MeetingType.Description));
        }
    }
}
