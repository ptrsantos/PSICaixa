using System.Collections.Generic;
using System.Linq;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Empregados;
using PSICaixa.Domain.Interfaces.Services.Empregados;

namespace PSICaixa.Data.Services.Empregados
{
    public class EmpregadoService : IEmpregadoService
    {
        private readonly IEmpregadoRepository EmpregadoRepository;

        public EmpregadoService(IEmpregadoRepository empregadoRepository)
        {
            EmpregadoRepository = empregadoRepository;
        }

        public void AtualizarEmpregado(Empregado empregado)
        {
                EmpregadoRepository.Update(empregado);
                EmpregadoRepository.Save();
        }

        public string CadastrarEmpregado(Empregado empregado)
        {
            Empregado empregadoAux = EmpregadoRepository.RetornarPorMatricula(empregado.Matricula);
            if (empregadoAux == null)
            {
                EmpregadoRepository.Add(empregado);
                EmpregadoRepository.Save();
                return "Sucesso";
            }
            else
            {
                return "A matrícula informada já foi cadastrada.";
            }
        }

        public void ExcluirEmpregado(int id)
        {
            Empregado empregado = ObterEmpregadoPorId(id);
            EmpregadoRepository.Remove(empregado);
            EmpregadoRepository.Save();
        }

        public void ExcluirTodosEmpregados()
        {
            EmpregadoRepository.ExcluirTodosEmpregados();
        }

        public IList<Empregado> ListarEmpregados()
        {
            return EmpregadoRepository.GetAll().OrderByDescending(e => e.Id).ToList();
        }

        private Empregado ObterEmpregadoPorId(int id)
        {
            return EmpregadoRepository.GetById(id);
        }


    }
}
