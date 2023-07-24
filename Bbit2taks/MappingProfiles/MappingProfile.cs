using Bbit2taks.Model;
using AutoMapper;
using Bbit2taks.DTO;

namespace Bbit2taks.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<Resident, ResidentDto>().ReverseMap();
        }
        
    }
}
