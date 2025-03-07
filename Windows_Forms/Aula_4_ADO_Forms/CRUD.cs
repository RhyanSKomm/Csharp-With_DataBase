using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Aula_4_ADO_Forms
{
    public class CRUD
    {
        string conexaoSQL = "Host=localhost;Username=postgres;Password=010206;Database=Aula1";

        public void InserirUsuario(int id, string nome, string email){
            string query = "INSERT INTO usuario (id, nome, email) VALUES (@id, @nome, @email)";
            using(NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using(NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<string> ListarUsuarios()
        {
            List<string> usuario = new List<string>();
            string query = "SELECT * FROM Usuario";

            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader()) 
                    {
                        while (dr.Read())
                        {
                            string linha = $"ID: {dr["id"]} Nome: {dr["nome"]} Email: {dr["email"]}";
                            usuario.Add(linha);
                        }
                    }
                }
            }
            return usuario;
        }
        public void AtualizarUsuario(int id, string novoNome)
        {
            string query = "Update usuario set nome = @nome where id = @id";

            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nome", novoNome);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM usuario WHERE id = @id";
            using (NpgsqlConnection conexao = new NpgsqlConnection(conexaoSQL))
            {
                conexao.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conexao))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}