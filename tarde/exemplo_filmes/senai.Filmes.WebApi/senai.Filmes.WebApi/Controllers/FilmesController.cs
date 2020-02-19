using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmesRepository _filmeRespository { get; set; }

        public FilmesController()
        {
            _filmeRespository = new FilmesRepository();
        }


        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRespository.Listar();
        }




     }
}
