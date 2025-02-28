using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EX1
{
    public class Executar
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();

            // System.Console.WriteLine("USUARIOS");
            // crud.ListarUsuarios();
            // crud.InserirUsuario(new Usuarios {Id= 34, Nome_Usuario = "Carlos", Ramal_Usuario = 1234, Especialidade_Usuario = "Desenvolvedor" });
            // crud.AtualizarUsuario(1, new Usuarios { Nome_Usuario = "Pablo", Ramal_Usuario = 4321, Especialidade_Usuario = "Analista" });
            // crud.DeletarUsuario(33);

            System.Console.WriteLine();
            System.Console.WriteLine("MAQUINA");
            // crud.ListarMaquinas();
            crud.InserirMaquina(new Maquina {Id= 7, Tipo = "Desktop", Velocidade = 3, Hardidisk = 8, Placa_rede = 10, Memoria_ram = 16, Fk_usuario = 30 });
            // crud.AtualizarMaquina(1, new Maquina { Tipo = "Notebook", Velocidade = 2, Hardidisk = 4, Placa_rede = 5, Memoria_ram = 8, Fk_usuario = 1 });
            // crud.DeletarMaquina(30);

            // // System.Console.WriteLine();
            // System.Console.WriteLine("SOFTWARE");
            // crud.ListarSoftwares();
            // crud.InserirSoftware(new Software {Id= 31, Produto = "Windows", Hardidisk = 15, Memoria_ram = 8, Fk_maquina = 1 });
            // crud.AtualizarSoftware(1, new Software { Produto = "Linux", Hardidisk = 12, Memoria_ram = 16, Fk_maquina = 1 });
            // crud.DeletarSoftware(1);
        }
    }
}