using System.Collections.Generic;
using System.IO;
using PSICaixa.Domain.Entities.Empregados;

namespace PSICaixa.Domain.Interfaces.Services.Empregados
{
    public interface IEmpregadoService
    {
        IList<Empregado> SalvarERetornarEmpregados(IList<Empregado> empregados);
        IList<Empregado> ListarEmpregadosPorPaginacao(int pagina, int tamanho);
        IList<Empregado> ExcluirEmpregado(int id, int pagina, int tamanho);
        IList<Empregado> LerArquivo(Stream arquivo);
        IList<Empregado> RetornarListaEmpregados();
        IList<Empregado> RetornarListaEmpregadosJQueryDataTable(int start, int length, string searchValue, string sortComumnName, string sortDirection);
    }
}
