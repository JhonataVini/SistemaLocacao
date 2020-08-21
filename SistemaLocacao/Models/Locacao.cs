using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSistema.Models
{
    public class Locacao
    {
        [Key]
        public int IdLocacao { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "O formato da data está incorreto")]
        [Display(Name = "Data Locação")]
        public DateTime DataLocacao { get; set; }

        [Display(Name = "Data de Entrega")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data está incorreto")]
        public DateTime DataEntrega { get; set; }

        [Display(Name = "Data Data de Devolução")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data está incorreto")]
        public DateTime DataDevolucao { get; set; }

        [DisplayName("Filme")]
        [ForeignKey("Filme")]
        public int IdFilme { get; set; }

        [DisplayName("Cliente")]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Filme Filmes { get; set; }

        public Cliente Clientes { get; set; }
       

    }
}
