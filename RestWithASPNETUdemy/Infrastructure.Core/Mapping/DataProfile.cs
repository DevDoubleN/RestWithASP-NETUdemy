using Application.DTOs.Input.Person;
using Application.DTOs.Output.Person;
using AutoMapper;
using Domain.Entities.Models.Person;

namespace Infrastructure.Core.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<PersonInsertDTO, Person>();
            CreateMap<PersonUpdateDTO, Person>();
            CreateMap<Person, PersonOutputDTO>();
            CreateMap<PersonInsertDTO, PersonOutputDTO>();
            CreateMap<PersonUpdateDTO, PersonOutputDTO>();
        }
    }
}
