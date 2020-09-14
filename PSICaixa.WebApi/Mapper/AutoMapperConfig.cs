using AutoMapper;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSICaixa.WebApi.Mapper
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