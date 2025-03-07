using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Entity_Forms
{
    public class CRUD
    {
        public void InserirUsuario(Usuarios usuario)
        {
            using (var db = new Conexao())
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        public void ListarUsuarios()
        {
            using (var db = new Conexao())
            {
                var usuarios = db.Usuarios.ToList();
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id}\n Nome: {usuario.Nome_Usuario}\n Ramal: {usuario.Ramal_Usuario}\n Especialidade: {usuario.Especialidade_Usuario}");
                }
            }

        }

        public void AtualizarUsuario(int id, Usuarios novoUsuario)
        {
            using (var db = new Conexao())
            {
                var usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.Nome_Usuario = novoUsuario.Nome_Usuario;
                    usuario.Ramal_Usuario = novoUsuario.Ramal_Usuario;
                    usuario.Especialidade_Usuario = novoUsuario.Especialidade_Usuario;
                    db.SaveChanges();
                    System.Console.WriteLine("Usuário atualizado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Usuário não encontrado!");
                }
            }
        }

        public void DeletarUsuario(int id_usuario)
{
    using (var db = new Conexao())
    {
        try
        {
            var usuario = db.Usuarios.Find(id_usuario);
            if (usuario != null)
            {
                // Remove related Softwares and Maquinas
                // db.Softwares.RemoveRange(db.Softwares.Where(s => s.Fk_maquina == id_usuario));
                // db.Maquinas.RemoveRange(db.Maquinas.Where(m => m.Fk_usuario == id_usuario));

                // Remove the Usuario
                db.Usuarios.Remove(usuario);
                
                // Save changes in a single transaction
                db.SaveChanges();
                
                System.Console.WriteLine("Usuário deletado com sucesso!");
            }
            else
            {
                System.Console.WriteLine("Usuário não encontrado!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Erro ao deletar o usuário: {ex.Message}");
            // Optionally, log the exception
        }
    }
}


        public void InserirMaquina(Maquina maquina)
        {
            using (var db = new Conexao())
            {
                db.Maquinas.Add(maquina);
                db.SaveChanges();
            }
        }

        public void ListarMaquinas()
        {
            using (var db = new Conexao())
            {
                var maquinas = db.Maquinas.ToList();
                foreach (var maquina in maquinas)
                {
                    System.Console.WriteLine($"Id: {maquina.Id} \nTipo: {maquina.Tipo}\n Velocidade: {maquina.Velocidade}\n Harddisk: {maquina.Hardidisk}\n Placa de rede: {maquina.Placa_rede}\n Memória RAM: {maquina.Memoria_ram}");
                }
            }
        }

        public void AtualizarMaquina(int id, Maquina novaMaquina)
        {
            using (var db = new Conexao())
            {
                var maquina = db.Maquinas.Find(id);
                if (maquina != null)
                {
                    maquina.Tipo = novaMaquina.Tipo;
                    maquina.Velocidade = novaMaquina.Velocidade;
                    maquina.Hardidisk = novaMaquina.Hardidisk;
                    maquina.Placa_rede = novaMaquina.Placa_rede;
                    maquina.Memoria_ram = novaMaquina.Memoria_ram;
                    db.SaveChanges();
                    System.Console.WriteLine("Maquina atualizada com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Maquina não encontrada!");
                }
            }
        }

        public void DeletarMaquina(int id)
        {
            using (var db = new Conexao())
            {
                var maquina = db.Maquinas.Find(id);
                if (maquina != null)
                {
                    db.Maquinas.Remove(maquina);
                    db.SaveChanges();
                    System.Console.WriteLine("Maquina deletada com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Maquina não encontrada!");
                }
            }
        }

        public void InserirSoftware(Software software)
        {
            using (var db = new Conexao())
            {
                db.Softwares.Add(software);
                db.SaveChanges();
            }
        }

        public void ListarSoftwares()
        {
            using (var db = new Conexao())
            {
                var softwares = db.Softwares.ToList();
                foreach (var software in softwares)
                {
                    System.Console.WriteLine($"Id: {software.Id} \nProduto: {software.Produto}\n Harddisk: {software.Hardidisk}\n Memória RAM: {software.Memoria_ram}\n FK Maquina: {software.Fk_maquina}");
                }
            }
        }

        public void AtualizarSoftware(int id, Software novoSoftware)
        {
            using (var db = new Conexao())
            {
                var software = db.Softwares.Find(id);
                if (software != null)
                {
                    software.Produto = novoSoftware.Produto;
                    software.Hardidisk = novoSoftware.Hardidisk;
                    software.Memoria_ram = novoSoftware.Memoria_ram;
                    software.Fk_maquina = novoSoftware.Fk_maquina;
                    db.SaveChanges();
                    System.Console.WriteLine("Software atualizado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Software não encontrado!");
                }
            }
        }

        public void DeletarSoftware(int id)
        {
            using (var db = new Conexao())
            {
                var software = db.Softwares.Find(id);
                if (software != null)
                {
                    db.Softwares.Remove(software);
                    db.SaveChanges();
                    System.Console.WriteLine("Software deletado com sucesso!");
                }
                else
                {
                    System.Console.WriteLine("Software não encontrado!");
                }
            }
        }
    }
}