using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto04.Contracts
{
    public interface IBaseRepository<T>
    {
        //métodos

        void Inserir(T obj);

        void Alterar(T obj);

        void Excluir(T obj);

        List<T> Consultar();
    }
}
