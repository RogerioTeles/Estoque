using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexaoBD;
using System.Data;
using Objetos;

namespace Classes.cs
{
    public class Ações
    {

        public List<Produto> GridTudo()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaAll();

            List<Produto> Produto = new List<Produto>();
            foreach(DataRow dr in dt.Rows)
            {
                Produto.Add(new Produto {
                    idProduto = @dr["idProduto"].ToString().ToUpper(),
                    nomeProduto = @dr["nomeProduto"].ToString().ToUpper(),
                    descricao = @dr["descricao"].ToString().ToUpper(),
                    quantidade = @dr["quantd"].ToString().ToUpper(),
                    Categorias_id = @dr["Categorias_id"].ToString().ToUpper(),
                  
                });
            }
            return (Produto) ;
        }

        public void AddCategoria(string nomeCategoria)
        {
            Busca b = new Busca();
            b.AddCategoria(nomeCategoria);
        }

        public DataTable GetCategorias()
        {
            Busca b = new Busca();
            DataTable dt = b.BuscaCategorias();


            return ();
        }
    }

}
