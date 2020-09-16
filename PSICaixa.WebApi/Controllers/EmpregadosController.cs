using AutoMapper;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Services.Empregados;
using PSICaixa.WebApi.Mapper;
using PSICaixa.WebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace PSICaixa.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpregadosController : ApiController
    {
        private readonly IEmpregadoService EmpregadoService;
        protected readonly IMapper Mapper;

        public EmpregadosController(IEmpregadoService empregadoService)
        {
            EmpregadoService = empregadoService;
            Mapper = AutoMapperConfig.RegisterMappings();
        }


        public IList<EmpregadoDto> Get()
        {
            IList<EmpregadoDto> listaEmpregados = Mapper.Map<IList<Empregado>, IList<EmpregadoDto>>(EmpregadoService.ListarEmpregados());

            return listaEmpregados;

        }


        public HttpResponseMessage Post(EmpregadoDto empregado)
        {

            Empregado empregadoDomain = Mapper.Map<EmpregadoDto, Empregado>(empregado);
            string retorno = EmpregadoService.CadastrarEmpregado(empregadoDomain);
            if (retorno != "Sucesso")
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new StringContent(retorno);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }

        }


        public void Put(EmpregadoDto empregado)
        {
            Empregado empregadoDomain = Mapper.Map<EmpregadoDto, Empregado>(empregado);
            EmpregadoService.AtualizarEmpregado(empregadoDomain);
 
        }


        public void Delete(int id)
        {
            EmpregadoService.ExcluirEmpregado(id);
        }

        public void Delete()
        {
            EmpregadoService.ExcluirTodosEmpregados();
        }

    }
}
