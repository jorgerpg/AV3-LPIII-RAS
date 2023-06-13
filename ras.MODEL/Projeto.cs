using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Projeto
{
    public int ProjetoId { get; set; }

    public int ResponsavelId { get; set; }

    public string Descricao { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    public virtual ICollection<ProjetoPessoa> ProjetoPessoas { get; set; } = new List<ProjetoPessoa>();

    public virtual Pessoa Responsavel { get; set; } = null!;

    public virtual ICollection<ReuniaoProjeto> ReuniaoProjetos { get; set; } = new List<ReuniaoProjeto>();
}
