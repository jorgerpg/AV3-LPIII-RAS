using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class EventoPessoa
{
    public int EventoPessoaId { get; set; }

    public int EventoId { get; set; }

    public int PessoaId { get; set; }

    public string? Status { get; set; }

    public virtual Evento Evento { get; set; } = null!;

    public virtual Pessoa Pessoa { get; set; } = null!;
}
