using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Evento
{
    public int EventoId { get; set; }

    public int ResponsavelId { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DtHora { get; set; }

    public string? Localizacao { get; set; }

    public string? Palestrante { get; set; }

    public virtual ICollection<EventoPessoa> EventoPessoas { get; set; } = new List<EventoPessoa>();

    public virtual Pessoa Responsavel { get; set; } = null!;
}
