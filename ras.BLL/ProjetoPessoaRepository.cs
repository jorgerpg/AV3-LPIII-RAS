using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ras.BLL
{
    using ras.DAL.sakila;
    using ras.MODEL;
    public class ProjetoPessoaRepository
    {

        public ProjetoPessoa Add(ProjetoPessoa _projetoPessoa)
        {
            using var dbContext = new RasContext();
            var projetoPessoaEntity = dbContext.Add(_projetoPessoa);
            dbContext.SaveChanges();
            return projetoPessoaEntity.Entity;
        }

        public ProjetoPessoa GetById(int id)
        {
            using var dbContext = new RasContext();
            var projetoPessoa = dbContext.ProjetoPessoas
                .Include(pp => pp.Projeto)
                .Include(pp => pp.Pessoa)
                .SingleOrDefault(pp => pp.ProjetoPessoaId == id);

            return projetoPessoa;
        }

        public List<ProjetoPessoa> GetAll()
        {
            var projetoPessoas = dbContext.ProjetoPessoas
                .Include(pp => pp.Projeto)
                .Include(pp => pp.Pessoa)
                .ToList();

            return projetoPessoas;
        }

        public ProjetoPessoa Update(ProjetoPessoa projetoPessoa)
        {
            var projetoPessoaEntity = dbContext.ProjetoPessoas.Attach(projetoPessoa);
            projetoPessoaEntity.State = EntityState.Modified;
            dbContext.SaveChanges();
            return projetoPessoaEntity.Entity;
        }

        public void Delete(int id)
        {
            var projetoPessoa = dbContext.ProjetoPessoas.SingleOrDefault(pp => pp.ProjetoPessoaId == id);
            if (projetoPessoa != null)
            {
                dbContext.ProjetoPessoas.Remove(projetoPessoa);
                dbContext.SaveChanges();
            }
        }
    }
}
