using System;
using Projeto04.Repositories;

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var repository = new FuncionarioRepository();
                foreach (var item in repository.Consultar())
                {
                    Console.WriteLine(item.IdFuncionario);
                    Console.WriteLine(item.Nome);
                    Console.WriteLine(item.Salario);
                    Console.WriteLine(item.DataAdmissao);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
