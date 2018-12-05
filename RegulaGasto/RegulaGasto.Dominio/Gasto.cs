using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulaGasto.Dominio
{
    public class Gasto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        [DisplayName("Comentário")]
        public string Comentario { get; set; }
        [DisplayName("Mês")]
        public string Mes { get; set; }
    }
}
