using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class ProjetoPessoa
{
    public int ProjetoPessoaId { get; set; }

    public int ProjetoId { get; set; }

    public int PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual Projeto Projeto { get; set; } = null!;
}
