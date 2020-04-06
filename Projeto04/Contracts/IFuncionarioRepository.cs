using System;
using System.Collections.Generic;
using System.Text;
using Projeto04.Entities; //importando

namespace Projeto04.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {

        List<Funcionario> Consultar(string nome);

        List<Funcionario> Consultar(decimal salarioMin, decimal salarioMax);
    }
}
