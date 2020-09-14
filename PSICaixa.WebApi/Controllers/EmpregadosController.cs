using AutoMapper;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Services.Empregados;
using PSICaixa.WebApi.Mapper;
using PSICaixa.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/Empregados
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Empregados/5
        public IList<EmpregadoDto> Get(int pagina, int tamanho)
        {
            IList<EmpregadoDto> listaEmpregadosDto = Mapper.Map<IList<Empregado>, IList<EmpregadoDto>>(EmpregadoService.ListarEmpregadosPorPaginacao(pagina, tamanho));
            return listaEmpregadosDto;
        }

        // POST: api/Empregados
        public IList<EmpregadoDto> Post(IList<EmpregadoDto> empregadosDto)
        {

            IList<Empregado> empregados = Mapper.Map<IList<EmpregadoDto>, IList<Empregado>>(empregadosDto);
            IList<Empregado> empregadosRetorno = EmpregadoService.SalvarERetornarEmpregados(empregados);
            IList<EmpregadoDto> listaEmpregadosDto = Mapper.Map<IList<Empregado>, IList<EmpregadoDto>>(empregadosRetorno);

            return listaEmpregadosDto;
        }

        // PUT: api/Empregados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empregados/5
        public IList<EmpregadoDto> Delete(int id, int pagina, int tamanho)
        {
            return Mapper.Map<IList<Empregado>, IList<EmpregadoDto>>(EmpregadoService.ExcluirEmpregado(id, pagina, tamanho));
        }


    }
}
