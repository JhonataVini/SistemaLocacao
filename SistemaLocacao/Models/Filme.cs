using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSistema.Models
{
    public class Filme
    {
        [Key]
        public int IdFilme { get; set; }

        [StringLength(30, ErrorMessage = "Maximo de 30 Caracteres")]
        public string Titulo { get; set; }
    }
}
