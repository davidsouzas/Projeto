using RegulaGasto.Aplicacao;
using RegulaGasto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var gastoAplicacao = new GastoAplicacao();

            Console.WriteLine("Insira o Valor: ");
            string valor = Console.ReadLine();
            Console.WriteLine("Insira a Categoria: ");
            string categoria = Console.ReadLine();
            Console.WriteLine("Comentario: ");
            string comentario = Console.ReadLine();
            Console.WriteLine("Insira o Mes");
            string mes = Console.ReadLine();

            var gasto1 = new Gasto()
            {
                Valor = Convert.ToDecimal(valor),
                Categoria = categoria,
                Comentario = comentario,
                Mes = mes
            };

            gastoAplicacao.Salvar(gasto1);

            var dados = gastoAplicacao.ListaTodos();

            foreach (var gasto in dados)
            {
                Console.WriteLine("Id:{0}, Valor:{1}, Categoria:{2}, Comentario:{3}, Mes:{4}", gasto.Id, gasto.Valor, gasto.Categoria, gasto.Comentario, gasto.Mes);
            }
          
        }

    }
}
