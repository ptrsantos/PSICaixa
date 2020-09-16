using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSICaixa.WebApi.Models
{
    public class EmpregadoDto
    {
        public int Id { get; set; }

        public string Matricula { get; set; }

        public string Nome { get; set; }

        public string Coordenacao { get; set; }

        public string Unidade { get; set; }
    }
}