using PSICaixa.Data.Repositories.Base;
using PSICaixa.Domain.Entities.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Empregados;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSICaixa.Data.Repositories.Empregados
{
    public class EmpregadoRepository : RepositoryBase<Empregado>, IEmpregadoRepository
    {
        public void ExcluirTodosEmpregados()
        {
            Db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Empregados]");
        }

        public Empregado RetornarPorMatricula(string matricula)
        {
            return Db.Empregados.Where(e => e.Matricula == matricula).FirstOrDefault();
        }
    }
}
