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

       [HttpGet("{pessoaID}", Name = "person")]
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

        [HttpPost(Name = "pessoa")]
        public ActionResult<Pessoa> AddPessoa(Pessoa pessoa)
        {
            try
            {
                var pessoaCriada = PessoaRepository.Add(pessoa);
                return Ok(pessoaCriada);
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
