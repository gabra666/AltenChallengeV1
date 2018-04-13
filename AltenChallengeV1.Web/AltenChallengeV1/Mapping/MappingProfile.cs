using AltenChallengeV1.DTO;
using AltenChallengeV1.Model.Models;
using AutoMapper;

namespace AltenChallengeV1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Vehicle, VehicleDTO>();

            //DTO to Domain
            CreateMap<CustomerDTO, Customer>();
            CreateMap<VehicleDTO, Vehicle>();
        }
    }
}