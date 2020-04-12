using System;
using System.Collections.Generic;
using System.Text;
using Projeto04.Entities; //importando
using Projeto04.Repositories; //importando

namespace Projeto04.Controlers
{
    public class FuncionarioController
    {
        //método para realizar o cadastro de um funcionário
        public void CadastrarFuncionario()
        {
            var funcionario = new Funcionario();

            Console.Write("Nome do funcionário....: ");
            funcionario.NomeFun = Console.ReadLine();

            Console.Write("Salário................: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());

            //Console.Write("Data de Admissão.......: ");
            funcionario.DataAdmissao = DateTime.Now;

            var repository = new FuncionarioRepository();
            repository.Inserir(funcionario);

            Console.WriteLine("\nFuncionário cadastrado com sucesso.");
        }

        //método para consultar todos os funcionários
        public void ConsultarFuncionarios()
        {
            var funcionarioRepository = new FuncionarioRepository();
            var dependenteRepository = new DependenteRepository();

            var funcionarios = funcionarioRepository.Consultar();

            foreach (var itemFuncionario in funcionarios)
            {
                Console.WriteLine("Id do Funcionário....: " + itemFuncionario.IdFuncionario);
                Console.WriteLine("Nome.................: " + itemFuncionario.NomeFun);
                Console.WriteLine("Salário..............: " + itemFuncionario.Salario);
                Console.WriteLine("Data de Admissão.....: " + itemFuncionario.DataAdmissao);

                var dependentes = dependenteRepository.Consultar(itemFuncionario.IdFuncionario);

                foreach (var itemDependente in dependentes)
                {
                    Console.WriteLine("Id do Dependente.....: " + itemDependente.IdDependente);
                    Console.WriteLine("Nome.................: " + itemDependente.Nome);
                    Console.WriteLine("Data de Nascimento...: " + itemDependente.DataNascimento);
                }

                Console.WriteLine("...");
            }

        }
    }
}
