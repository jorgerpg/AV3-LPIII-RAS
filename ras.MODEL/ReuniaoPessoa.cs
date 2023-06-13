using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class ReuniaoPessoa
{
    public int ReuniaoPessoaId { get; set; }

    public int ReuniaoId { get; set; }

    public int PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual Reuniao Reuniao { get; set; } = null!;
}
