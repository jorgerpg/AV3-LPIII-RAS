using Microsoft.AspNetCore.Mvc;
using ras.DAL.sakila;

namespace ras.BLL.Services.Controllers
{
    public class PessoaController : Controller
    {
        [HttpGet(Name = "pessoas")]
        public ActionResult<List<Pessoa>> GetPessoas()
        {
            try
            {
                var pessoas = PessoaRepository.GetAll();
                return Ok(pessoas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "pessoa")]
        public ActionResult<Pessoa> GetPessoaById(int id)
        {
            try
            {
                var pessoa = PessoaRepository.GetById(id);
                return Ok(pessoa);
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
        [HttpPatch(Name = "pessoa")]
        public ActionResult<Pessoa> UpdatePessoa(Pessoa pessoa)
        {
            try
            {
                var pessoaAtualizada = PessoaRepository.Update(pessoa);
                return Ok(pessoaAtualizada);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}", Name = "pessoa")]
        public ActionResult DeletarPessoa(int id)
        {
            try
            {
                PessoaRepository.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
