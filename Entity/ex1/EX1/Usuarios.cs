using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EX1
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }
        [Column("password")]
        public string Password_Usuario { get; set; } = string.Empty;
        [Column("nome_usuario")]
        public string Nome_Usuario { get; set; } = string.Empty;
        [Column("ramal")]
        public int Ramal_Usuario { get; set; }
        [Column("especialidade")]
        public string Especialidade_Usuario { get; set; } = string.Empty;   
             
    }
}