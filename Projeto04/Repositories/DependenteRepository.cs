using System;
using System.Collections.Generic;
using System.Text;
using Projeto04.Entities; //importando
using Projeto04.Contracts; //importando
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;

namespace Projeto04.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        //atributo 'somente leitura'
        private readonly string connectionString;

        //construtor -> ctor + 2x[tab]
        public DependenteRepository()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BDAula03b;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public void Inserir(Dependente obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_InserirDependente", 
                    new
                    {
                        obj.Nome,
                        obj.DataNascimento,
                        obj.IdFuncionario 
                    }, 
                    commandType : CommandType.StoredProcedure);   
            }
        }

        public void Alterar(Dependente obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_AlterarDependente", 
                    new
                    {
                        obj.IdDependente,
                        obj.Nome,
                        obj.DataNascimento,
                        obj.IdFuncionario
                    },
                    commandType : CommandType.StoredProcedure);
            }
        }

        public List<Dependente> Consultar()
        {
            var query = "select * from Dependente d inner join Funcionario f "
                      + "on f.IdFuncionario = d.IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query, 
                    (Dependente d, Funcionario f) => 
                    {
                        d.Funcionario = f; //relacionamento TER-1
                        return d;
                    },
                    splitOn : "IdFuncionario" //foreign key
                    ).ToList();
            }
        }

        public void Excluir(Dependente obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_ExcluirDependente", 
                    new
                    {
                        obj.IdDependente
                    },
                    commandType : CommandType.StoredProcedure);
            }
        }

        public Dependente ObterPorId(int id)
        {
            var query = "select * from Dependente d inner join Funcionario f "
                       + "on f.IdFuncionario = d.IdFuncionario "
                       + "where d.IdDependente = @IdDependente";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Dependente d, Funcionario f) =>
                    {
                        d.Funcionario = f; //relacionamento TER-1
                        return d;
                    },
                    new { IdDependente = id },
                    splitOn: "IdFuncionario" //foreign key
                    ).FirstOrDefault();
            }
        }

        public List<Dependente> Consultar(int idFuncionario)
        {
            var query = "select * from Dependente where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Dependente>
                    (query, new { idFuncionario }).ToList();
            }
        }
    }
}
