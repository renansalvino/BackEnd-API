using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDePessoas
{
    public class Conexão
    {

        SqlConnection con = new SqlConnection();
        //Construtor
        public Conexão()
        {  
            con.ConnectionString = "Data Source=DEV20\\SQLEXPRESS;Initial Catalog=Pessoas;Persist Security Info=True;User ID=sa;Password=sa@132";
        }

        //Método para se conectar no banco de dados
        public SqlConnection  conectar()

        {
            if (con.State == System.Data.ConnectionState.Closed) //se essa  fechada vai executar este código
                
            {
                //conexão estiver aberta ele vai se conectar
                con.Open();

            }
            return con;
        }

        //Método para se desconectar no banco de dados

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open) //se essa conexão estiver fechada vai executar este código

            {
                con.Close();

            }
        }
    }
}
