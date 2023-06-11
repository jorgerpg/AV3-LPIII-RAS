using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Pessoa
{
    public int PessoaId { get; set; }

    public int? ProjetoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DtIngressoRas { get; set; }

    public DateTime DtIngressoCurso { get; set; }

    public string? Email { get; set; }

    public string? Cpf { get; set; }

    public string? Senha { get; set; }

    public string? Celular { get; set; }

    public string? Ativo { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual ICollection<ComitePessoa> ComitePessoas { get; set; } = new List<ComitePessoa>();

    public virtual ICollection<Comite> Comites { get; set; } = new List<Comite>();

    public virtual ICollection<EventoPessoa> EventoPessoas { get; set; } = new List<EventoPessoa>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual Projeto? Projeto { get; set; }

    public virtual ICollection<ProjetoPessoa> ProjetoPessoas { get; set; } = new List<ProjetoPessoa>();

    public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();

    public virtual ICollection<ReuniaoPessoa> ReuniaoPessoas { get; set; } = new List<ReuniaoPessoa>();

    public virtual ICollection<Reuniao> Reuniaos { get; set; } = new List<Reuniao>();

    public virtual ICollection<SkillPessoa> SkillPessoas { get; set; } = new List<SkillPessoa>();
}
