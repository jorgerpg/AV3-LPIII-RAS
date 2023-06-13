using Microsoft.EntityFrameworkCore;

namespace ras.BLL
{
    using ras.DAL.sakila;
    using System.Data.Entity;

    public class ProjetoRepository
    {
        public static Projeto Add(Projeto _projeto)
        {
            using (var dbContext = new RasContext())
            {
                var projeto = dbContext.Add(_projeto);
                dbContext.SaveChanges();
                return projeto.Entity;
            }
        }

        public static Projeto GetProjectById(int Id)
        {
            using (var dbContext = new RasContext())
            {
                var projeto = dbContext.Projetos.Single(p => p.ProjetoId == Id);
                return projeto;
            }
        }
        public static List<Projeto> GetAll()
        {
            using (var dbContext = new RasContext())
            {
                var projeto = dbContext.Projetos.ToList();
                return projeto;
            }
        }

        public static Pessoa GetResponsavelProjeto(int Id)
        {
            using (var dbContext = new RasContext())
            {
                var pessoa = dbContext.Pessoas.Single(p => p.PessoaId == Id);
                return pessoa;
            }
        }

        public static Projeto Update(Projeto _projeto)
        {
            using (var dbContext = new RasContext())
            {
                var projeto = dbContext.Projetos.Single(p => p.ProjetoId == _projeto.ProjetoId);
                projeto.Descricao = _projeto.Descricao;
                projeto.Status = _projeto.Status;
                projeto.Responsavel = _projeto.Responsavel;
                dbContext.SaveChanges();
                return projeto;
            }
        }
        public static void Excluir(int id)
        {
            {
                using (var dbContext = new RasContext())
                {
                    var projeto = dbContext.Projetos.Single(p => p.ProjetoId == id);
                    dbContext.Remove(projeto);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}