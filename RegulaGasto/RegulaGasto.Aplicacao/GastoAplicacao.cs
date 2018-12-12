
using RegulaGasto.Dominio;
using RegulaGasto.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegulaGasto.Aplicacao
{
    public class GastoAplicacao
    {
        private Contexto contexto;

        private void Inserir(Gasto gasto)
        {
            var strQuery = "";
            strQuery += "INSERT INTO Gasto (Valor, Categoria, Comentario, Mes)";
            strQuery += string.Format(" VALUES ({0},'{1}','{2}','{3}') ",gasto.Valor, gasto.Categoria, gasto.Comentario, gasto.Mes);
            using(contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
        private void Alterar(Gasto gasto)
        {
            var strQuery = "";
            strQuery += "UPDATE GASTO SET ";
            strQuery += String.Format(" Valor = {0}, ", gasto.Valor);
            strQuery += String.Format(" Categoria = '{0}', ", gasto.Categoria);
            strQuery += String.Format(" Comentario = '{0}', ", gasto.Comentario);
            strQuery += String.Format(" Mes = '{0}' ", gasto.Mes);
            strQuery += String.Format(" WHERE Id = {0}", gasto.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }
        public void Salvar(Gasto gasto)
        {
            if (gasto.Id > 0)
                Alterar(gasto);
            else
                Inserir(gasto);
            
        }
        public void Excluir(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("DELETE FROM GASTO WHERE Id = {0}", id);
                contexto.ExecutaComando(strQuery);
            }
        }
        public List<Gasto> ListaTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM GASTO ";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public List<Gasto> ListarporCategoria(string Categoria)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM GASTO WHERE Categoria LIKE '%{0}%' ", Categoria);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Gasto ListarPorId(int id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM GASTO WHERE Id = {0} ", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        public decimal ValorTotal()
        {
            using (contexto = new Contexto())
            {
                var strQuery = ("SELECT SUM(Valor) FROM GASTO ");
                 return contexto.ExecutaComandoComRetorno2(strQuery);
                
            }
        }

        
        private List<Gasto> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var gastos = new List<Gasto>();
            while (reader.Read())
            {
                var temObjeto = new Gasto()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Valor = decimal.Parse(reader["Valor"].ToString()),
                    Categoria = reader["Categoria"].ToString(),
                    Comentario = reader["Comentario"].ToString(),
                    Mes = reader["Mes"].ToString()
                };
                gastos.Add(temObjeto);
            }
            reader.Close();
            return gastos;
        }
    }
}
