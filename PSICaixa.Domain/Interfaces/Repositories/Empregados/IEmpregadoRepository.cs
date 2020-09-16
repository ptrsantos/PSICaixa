using System.Collections.Generic;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Base;

namespace PSICaixa.Domain.Interfaces.Repositories.Empregados
{
    public interface IEmpregadoRepository : IRepositoryBase<Empregado>
    {
        Empregado RetornarPorMatricula(string matricula);
        void ExcluirTodosEmpregados();
    }
}
