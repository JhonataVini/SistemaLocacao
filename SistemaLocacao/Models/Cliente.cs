using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSistema.Models
{
    public class Cliente
    {    [Key]
        public int IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
    }
}
