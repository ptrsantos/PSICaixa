using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSICaixa.Domain.Entities.Empregados
{
    public class Empregado
    {
        public int Id { get; set; }

        public string Matricula { get; set; }

        public string Nome { get; set; }

        public Empregado()
        {

        }

        public Empregado(string matricula, string nome)
        {
            Matricula = matricula;
            Nome = nome;
        }
    }
}
