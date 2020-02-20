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
        private IFilmesRepository _filmeRespository
        {
            get;
            set;
        }

        public FilmesController()
        {
            _filmeRespository = new FilmesRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRespository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRespository.CadastrarFilme(novoFilme);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRespository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado");
            }

            return Ok(filmeBuscado);
        }

        [HttpPut]
        public IActionResult PutIdCorpo(FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRespository.BuscarPorId(filmeAtualizado.IdFilme);

            if (filmeBuscado != null)
            {
                try
                {
                    _filmeRespository.AtualizarIdCorpo(filmeAtualizado);

                    return NoContent();

                }
                catch (Exception Erro)
                {
                    return BadRequest(Erro);
                }

            }
            return NotFound(
            new
            {
                Mensagem = "Filme nao encontrado",
                erro = true
            }

            );
        }

        [HttpPut("id")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            FilmeDomain filmeBuscado = _filmeRespository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound(
                new
                {
                    mensagem = "Filme nao encontrado",
                    erro = true
                });
            }

            try
            {
                _filmeRespository.AtualizarIdUrl(id, filmeAtualizado);

                return NoContent();
            }

            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRespository.Deletar(id);

            return Ok ("Filme Deletado com sucesso irmão")
        }

    }
}