using System.Collections.Generic;
using PSICaixa.Domain.Entities.Empregados;

namespace PSICaixa.Domain.Interfaces.Services.Empregados
{
    public interface IEmpregadoService
    {
        IList<Empregado> ListarEmpregados();
        string CadastrarEmpregado(Empregado empregadoDomain);
        void AtualizarEmpregado(Empregado empregado);
        void ExcluirEmpregado(int id);
        void ExcluirTodosEmpregados();
    }
}
