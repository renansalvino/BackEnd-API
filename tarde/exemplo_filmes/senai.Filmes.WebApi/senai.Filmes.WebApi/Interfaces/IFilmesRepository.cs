using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmesRepository
    {
        List<FilmeDomain> Listar();

        void CadastrarFilme(FilmeDomain Filme);

        //void AtualizarIdCorpo(FilmeDomain filme);

        //void AtualizarIdUrl(int id, FilmeDomain filmes);

        //void Deletar(int id);

        //FilmeDomain BuscarPorId(int id);

        

       
    }
}
