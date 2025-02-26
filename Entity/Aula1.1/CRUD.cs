using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1._1
{
    public class CRUD
    {
        public void InserirUsuario(string nome, string email)
        {
            using (var db = new Ligacao())
            {
                db.Usuarios.Add(new Usuario { Nome = nome, Email = email });
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Ligacao())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome, string novoEmail)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.Nome = novoNome;
                    usuario.Email = novoEmail;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário atualizado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado!");
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = new Ligacao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário deletado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado!");
                }
            }
        }
    }
}