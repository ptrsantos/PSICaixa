using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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

        public IList<Empregado> ExcluirEmpregado(int id, int pagina, int tamanho)
        {
            Empregado empregado = EmpregadoRepository.GetById(id);
            EmpregadoRepository.Remove(empregado);
            EmpregadoRepository.Save();

            return ListarEmpregadosPorPaginacao(pagina, tamanho);
        }

        public IList<Empregado> LerArquivo(Stream arquivo)
        {
            IList<Empregado> listaEmpregados = new List<Empregado>();
            string linha = "";
            using (var reader = new StreamReader(arquivo))
            {
                while ((linha = reader.ReadLine()) != null)
                {
                    string[] stringEmpregado = linha.Split('|');
                    if (stringEmpregado[0].Length > 0)
                    {
                        Empregado empregado = new Empregado(stringEmpregado[0], stringEmpregado[2]);
                        listaEmpregados.Add(empregado);
                    }

                }
            }

            SalvarERetornarEmpregados(listaEmpregados);

            return ListarEmpregadosPorPaginacao(1, 5);
        }

        public IList<Empregado> ListarEmpregadosPorPaginacao(int pagina, int tamanho)
        {
            return EmpregadoRepository.ListarEmpregadosPorPaginacao(pagina, tamanho);
        }

        public IList<Empregado> RetornarListaEmpregados()
        {
            return EmpregadoRepository.GetAll().ToList();
        }

        public IList<Empregado> RetornarListaEmpregadosJQueryDataTable(int start, int length, string searchValue, string sortComumnName, string sortDirection)
        {
            EmpregadoRepository.RetornarListaEmpregadosJQueryDataTable(start, length, searchValue, sortComumnName, sortDirection);

            throw new NotImplementedException();
        }

        public IList<Empregado> SalvarERetornarEmpregados(IList<Empregado> empregados)
        {
            vericarSeBancoExisteEDeletar();

            EmpregadoRepository.SalvarListaEmpregados(empregados);

            return empregados;
        }

        private void vericarSeBancoExisteEDeletar()
        {
            EmpregadoRepository.vericarSeBancoExisteEDeletar();
        }
    }
}
