using Projeto04.Repositories;
using System;
using Projeto04.Controlers; //importando..

namespace Projeto04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n - CONTROLE DE FUNCIONÁRIOS - \n");

                var funcionarioController = new FuncionarioController();
                funcionarioController.CadastrarFuncionario();
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }

            Console.ReadKey(); //pausar a execução do prompt..
        }
    }
}
