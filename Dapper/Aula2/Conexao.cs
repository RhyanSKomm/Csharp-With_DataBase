using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;


namespace Aula2
{
    public class Conexao
    {
        private static readonly string conexaoDB = "Server=localhost;Database=Back1;Username=postgres;Password=010206";

        public static IDbConnection GetConexao()
        {
            return new NpgsqlConnection(conexaoDB);
        }
    }
}