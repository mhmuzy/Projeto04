using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Projeto04.Entities; //importando
using Projeto04.Contracts; //importando
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo 'somente leitura'
        private readonly string connectionString;

        //construtor -> ctor + 2x[tab]

        public FuncionarioRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BDAula03b;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public List<Funcionario> Consultar(string nome)
        {
            var query = "select * from Funcionario where NomeFun like @Nome";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>
                    (query, new { Nome = $"%{nome}%" }).ToList();
            }
        }

        public List<Funcionario> Consultar(decimal salarioMin, decimal salarioMax)
        {
            var query = "select * from Funcionario where Salario Between @Min and @Max";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>
                    (query, new { Min = salarioMin, Max = salarioMax }).ToList();
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = "select * from Funcionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }

        }

        public void Inserir(Funcionario obj)
        {
            using (var connection = new  SqlConnection(connectionString))
            {
                connection.Execute("SP_InserirFuncionario", 
                    new {
                        obj.NomeFun,
                        obj.Salario
                    },
                    commandType : CommandType.StoredProcedure);
            }
        }

        public void Alterar(Funcionario obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_AlterarFuncionario", 
                    new
                    {
                        obj.IdFuncionario,
                        obj.NomeFun,
                        obj.Salario,
                        obj.DataAdmissao
                    },
                    commandType : CommandType.StoredProcedure);
            }
        }

        public void Excluir(Funcionario obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_ExcluirFuncionario",
                    new
                    {
                        obj.IdFuncionario
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Funcionario ObterPorId(int id)
        {
            var query = "select * from Funcionario where IdFuncionario =  @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>
                    (query, new { IdFuncionario = id }).FirstOrDefault();
            }
        }
    }
}
