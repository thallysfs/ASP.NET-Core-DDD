using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            // Api.service -> Api.Data e vice-versa
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
