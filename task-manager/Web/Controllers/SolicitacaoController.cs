using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    public class SolicitacaoController : Controller
    {

        private readonly ISolicitacaoRepositorio _solicitacaoRepositorio;

        public SolicitacaoController(ISolicitacaoRepositorio solicitacaoRepositorio)
        {
            _solicitacaoRepositorio = solicitacaoRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_solicitacaoRepositorio.ObterTodos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Put([FromRoute] int id)
        {
            try
            {
                return Ok(_solicitacaoRepositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                Solicitacao solicitacao =  _solicitacaoRepositorio.ObterPorId(id);
                _solicitacaoRepositorio.Excluir(solicitacao);
                return Ok(solicitacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] Solicitacao solicitacao)
        {
            try
            {
                //solicitacao = _solicitacaoRepositorio.ObterPorId(id);
                _solicitacaoRepositorio.Salvar(solicitacao);
                return Ok(solicitacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Solicitacao solicitacao)
        {
            try
            {
                _solicitacaoRepositorio.Salvar(solicitacao);
                return Created("api/solicitacao", solicitacao);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
