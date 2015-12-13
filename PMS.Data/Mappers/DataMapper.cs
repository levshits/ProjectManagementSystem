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
        } 
    }
}