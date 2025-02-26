using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula1._1
{
    public class Executar
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();
            crud.ListarUsuarios();

            System.Console.WriteLine("----------------------");
            crud.InserirUsuario("Fulano", "fulano@email");
            crud.ListarUsuarios();

            System.Console.WriteLine("----------------------");
            crud.AtualizarUsuario(3, "Ciclano", "ciclano@email");
            crud.ListarUsuarios();

            System.Console.WriteLine("----------------------");
            crud.DeletarUsuario(6);
            crud.ListarUsuarios();

        }
    }
}