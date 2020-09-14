using AutoMapper;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Site.Mvc.Models;

namespace PSICaixa.Site.Mvc.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            MapperConfiguration config = new MapperConfiguration(x => {

                #region DomainToDto
                x.CreateMap<Empregado, EmpregadoDto>();
                #endregion

                #region DtoToDomain
                x.CreateMap<EmpregadoDto, Empregado>();
                #endregion

            });

            return config.CreateMapper();
        }
    }
}