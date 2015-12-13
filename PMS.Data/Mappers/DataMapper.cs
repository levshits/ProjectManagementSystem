using AutoMapper;
using PMS.Common.Dto;
using PMS.Data.Enity;

namespace PMS.Data.Mappers
{
    public class DataMapper
    {
        public DataMapper()
        {
            Mapper.CreateMap<PrincipalEntity, PrincipalDto>();
            Mapper.CreateMap<PrincipalDto, PrincipalEntity>();

            Mapper.CreateMap<RoleEntity, RoleDto>();
            Mapper.CreateMap<RoleDto, RoleEntity>();

            Mapper.CreateMap<ActionEntity, ActionDto>();
            Mapper.CreateMap<ActionDto, ActionEntity>();
        } 
    }
}