using System.Collections.Generic;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Base;

namespace PSICaixa.Domain.Interfaces.Repositories.Empregados
{
    public interface IEmpregadoRepository : IRepositoryBase<Empregado>
    {
        void SalvarListaEmpregados(IList<Empregado> empregados);
        void vericarSeBancoExisteEDeletar();
        IList<Empregado> ListarEmpregadosPorPaginacao(int pagina, int tamanho);
        IList<Empregado> RetornarListaEmpregadosJQueryDataTable(int start, int length, string searchValue, string sortComumnName, string sortDirection);
    }
}
