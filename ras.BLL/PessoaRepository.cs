using Microsoft.EntityFrameworkCore;

namespace ras.BLL
{
    using ras.DAL.sakila;
    using System.Data.Entity;

    public class PessoaRepository
    {
        public static Pessoa Add(Pessoa _pessoa)
        {
            using var dbContext = new RasContext();
            var pessoa = dbContext.Add(_pessoa);
            dbContext.SaveChanges();
            return pessoa.Entity;
        }

        public static Pessoa GetById(int Id)
        {
            using var dbContext = new RasContext();
            var pessoa = dbContext.Pessoas.Single(p => p.PessoaId == Id);
            return pessoa;
        }
        public static List<Pessoa> GetAll()
        {
            using (var dbContext = new RasContext())
            {
                var pessoas = dbContext.Pessoas.ToList();
                return pessoas;
            }
        }
        public static Pessoa Update(Pessoa _pessoa)
        {
            using (var dbContext = new RasContext())
            {
                var pessoa = dbContext.Pessoas.Single(p => p.PessoaId == _pessoa.PessoaId);
                pessoa.Nome = _pessoa.Nome;
                pessoa.SkillPessoas = _pessoa.SkillPessoas;
                pessoa.ProjetoPessoas = _pessoa.ProjetoPessoas;
                pessoa.EventoPessoas = _pessoa.EventoPessoas;
                dbContext.SaveChanges();
                return pessoa;
            }
        }
        public static void Excluir(int id)
        {
            {
                using (var dbContext = new RasContext())
                {
                    var pessoa = dbContext.Pessoas.Single(p => p.PessoaId == id);
                    dbContext.Remove(pessoa);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}