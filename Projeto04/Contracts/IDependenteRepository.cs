using System;
using System.Collections.Generic;
using System.Text;
using Projeto04.Entities; //importando

namespace Projeto04.Contracts
{
    public interface IDependenteRepository : IBaseRepository<Dependente>
    {

        List<Dependente> Consultar(int idFuncionario);
    }
}
