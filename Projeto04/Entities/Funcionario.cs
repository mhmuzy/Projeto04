using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto04.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }

        public string NomeFun { get; set; }

        public decimal Salario { get; set; }

        public DateTime DataAdmissao { get; set; }

        //Relacionamento de Associação
        //TER-MUITOS
        public List<Dependente> Dependentes { get; set; }
    }
}
