using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConexaoBD
{
    public class Busca
    {
        public DataTable BuscaAll()
        {
            Conexao conexao = new Conexao();
            DataTable dt = new DataTable();
            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("select * from estoque.produto Inner JOIN estoque.categorias on produto.Categorias_id = categorias.id;", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                da.Fill(dt);
                return dt;
            }

            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable  BuscaCategorias()
        {
            Conexao conexao = new Conexao();
            DataTable dt = new DataTable();
            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("select * from estoque.categorias", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                da.Fill(dt);
                return dt;
            }

            catch (Exception e)
            {
                throw e;
            }

        }

        public DataTable BuscaProdutos()
        {
            Conexao conexao = new Conexao();
            DataTable dt = new DataTable();
            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("select idProduto , nomeProduto from estoque.produto", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                da.Fill(dt);
                return dt;
            }

            catch (Exception e)
            {
                throw e;
            }

        }

        public void AddProduto(string Nome, string desc , string categoria, string quantidade )
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("Insert into estoque.produto values('0',@nome,@descricao,@categoria,@quantidade); ", con);
                cmd.Parameters.AddWithValue("@nome", Nome );
                cmd.Parameters.AddWithValue("@descricao", desc);
                cmd.Parameters.AddWithValue("@categoria", categoria);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

        public void AddCategoria(string nome_categoria)
        {
            Conexao conexao = new Conexao();
            
            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("Insert into estoque.categorias values('0',@nome_categoria); ", con);
                cmd.Parameters.AddWithValue("@nome_categoria", nome_categoria);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }
 

        }

        public void DeleteCategoria(string id)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("Delete FROM estoque.categorias where id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

        public void UpdateCategoria(string id ,string new_name)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.categorias set nm_categoria=@new_name where id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@new_name", new_name);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

        public void UpdateProduto(string id, string name, string idcat, string desc, string qtd)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.produto set nomeProduto=@name , descricao=@desc, Categorias_id = @idcat, quantidade=@qtd where idproduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@idcat", idcat);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@qtd", qtd);

                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

        public void UpdateProdutoName(string id, string name)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.produto set nomeProduto=@new_name where idproduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@new_name", name);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

        public void UpdateProdutoDesc(string id, string desc)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.produto set descricao=@desc where idproduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateProdutoCat(string id, string idcat)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.produto set Categorias_id=@idcat where idproduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idcat", idcat);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateProdutoQtd(string id, string qtd)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("UPDATE estoque.produto set quantidade=@qtd where idproduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@qtd", qtd);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteProduto(string id)
        {
            Conexao conexao = new Conexao();

            //A string de conexao está no webconfig na tag AppSettings
            string connection = ConfigurationManager.AppSettings["conexaoSQLServer"];
            try
            {
                //Abrindo Conexão
                MySqlConnection con = conexao.AbrirConexao(connection);
                MySqlCommand cmd = new MySqlCommand("Delete FROM estoque.produto where idProduto = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                throw e;
            }


        }

    }
}
