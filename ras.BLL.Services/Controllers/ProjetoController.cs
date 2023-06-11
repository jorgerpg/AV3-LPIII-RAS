using Microsoft.AspNetCore.Mvc;
using ras.DAL.sakila;

namespace ras.BLL.Services.Controllers
{
    public class ProjetoController : Controller
    {
        [HttpGet(Name = "projetos")]
        public ActionResult<List<Projeto>> GetProjetos() {
            try
            {
            var projetos = ProjetoRepository.GetAll();
            return Ok(projetos);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "projeto")]
        public ActionResult<Projeto> GetProjetoById(int id)
        {
            try
            {
                var projeto = ProjetoRepository.GetById(id);
                return Ok(projeto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Name = "projetos")]
        public ActionResult<Projeto> AddProjeto(Projeto projeto)
        {
            try
            {
                var projetoCriado = ProjetoRepository.Add(projeto);
                return Ok(projetoCriado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch(Name = "projeto")]
        public ActionResult<Projeto> UpdateProjeto(Projeto projeto)
        {
            try
            {
                var projetoAtualizado = ProjetoRepository.Update(projeto);
                return Ok(projetoAtualizado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}", Name = "projeto")]
        public ActionResult DeletarProjeto(int id)
        {
            try
            {
                ProjetoRepository.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}