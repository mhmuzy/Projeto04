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
                    Console.WriteLine("Lista de Funcionarios:");
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Id do Funcionario: " + item.IdFuncionario);
                    Console.WriteLine("Nome do Funcionário: " + item.Nome);
                    Console.WriteLine("Slário: R$" + item.Salario);
                    Console.WriteLine("---------------------------------------");

                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Ocorreu um erro: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
