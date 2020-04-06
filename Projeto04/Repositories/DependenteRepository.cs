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
                connection.Execute("SP_InserirDependente", obj, 
                    commandType : CommandType.StoredProcedure);   
            }
        }

        public void Alterar(Dependente obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_AlterarDependente", obj,
                    commandType : CommandType.StoredProcedure);
            }
        }

        public List<Dependente> Consultar()
        {
            var query = "select * from Dependente";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Dependente>(query).ToList();
            }
        }

        public void Excluir(Dependente obj)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_ExcluirDependente", obj,
                    commandType : CommandType.StoredProcedure);
            }
        }
    }
}
