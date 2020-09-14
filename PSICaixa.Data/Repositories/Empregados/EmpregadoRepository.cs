using PSICaixa.Data.Repositories.Base;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Empregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PSICaixa.Data.Repositories.Empregados
{
    public class EmpregadoRepository : RepositoryBase<Empregado>, IEmpregadoRepository
    {
        public IList<Empregado> ListarEmpregadosPorPaginacao(int pagina, int tamanho)
        {
            return GetAll().ToList().Skip(tamanho * (pagina - 1)).Take(tamanho).ToList();
        }

        public IList<Empregado> RetornarListaEmpregadosJQueryDataTable(int start, int length, string searchValue, string sortComumnName, string sortDirection)
        {
            IList<Empregado> listaEmpregados = new List<Empregado>();

            if (!string.IsNullOrEmpty(searchValue))//filter
            {
                listaEmpregados = GetAll()
                    .Where(
                        e => e.Id.ToString().ToLower().Contains(searchValue.ToLower()) || e.Nome.ToLower().Contains(searchValue.ToLower()) || e.Matricula.ToLower().Contains(searchValue.ToLower())
                    ).ToList<Empregado>();
            }

            //sorting
            string stringProcurada = sortComumnName + " " + sortDirection;
            //listaEmpregados = listaEmpregados.OrderBy().ToList<Empregado>();
            if(!(string.IsNullOrEmpty(sortComumnName) && string.IsNullOrEmpty(sortDirection)))
            {
                //listaEmpregados = GetAll().OrderBy(sortComumnName + " " + sortDirection);
            }

            int totalRegistros = GetAll().Count();

            int skip = start != null ? Convert.ToInt32(start) : 0;
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            listaEmpregados = GetAll().Skip(skip).Take(pageSize).ToList<Empregado>();

            return listaEmpregados;
        }

        public void SalvarListaEmpregados(IList<Empregado> empregados)
        {
            try
            {
                var retorno = Db.Empregados.AddRange(empregados);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void vericarSeBancoExisteEDeletar()
        {
            var existe = Db.Database.Exists();
            if (Db.Database.Exists())
            {
                Db.Database.Delete();
            }
        }
    }
}
