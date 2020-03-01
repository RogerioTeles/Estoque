using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace ConexaoBD
{
    public class Conexao
    {
        public MySql.Data.MySqlClient.MySqlConnection AbrirConexao(string stringConexao)
        {
            try
            {

                MySqlConnection connection = new MySqlConnection(stringConexao);

                connection.Open();

                return connection;
            }

            catch (Exception e)
            {
                throw e;
            }

        }

        public void fecharConexao(MySqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
