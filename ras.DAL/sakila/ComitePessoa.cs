using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class ComitePessoa
{
    public int ComitePessoaId { get; set; }

    public int ComiteId { get; set; }

    public int PessoaId { get; set; }

    public virtual Comite Comite { get; set; } = null!;

    public virtual Pessoa Pessoa { get; set; } = null!;
}
