using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto04.Entities
{
    public class Dependente
    {

        public int IdDependente { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public int IdFuncionario { get; set; }

        //Relacionamento de Associação
        //TER-1
        public Funcionario Funcionario { get; set; }
    }
}
