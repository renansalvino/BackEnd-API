using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using senai.Filmes.WebApi.Domains;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private string stringConexao = "Data Source = DEV20\\SQLEXPRESS; initial catalog = Filmes_tarde; user Id = sa; pwd=sa@132";

        public void CadastrarFilme (FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastra = "INSERT INTO Filmes(Titulo,IdGenero) VALUES (@Titulo,@Id)";

                SqlCommand cmd = new SqlCommand(queryCadastra, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@Id", filme.IdGenero);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>  ();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
            string queryTodos = "SELECT IdFilme, Titulo from Filmes";

            con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryTodos, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        filmes.Add(filme);
                    }
                }

            }

            return filmes;


        }
    }
}
