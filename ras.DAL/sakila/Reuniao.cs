using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Reuniao
{
    public int ReuniaoId { get; set; }

    public int ResponsavelId { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DtHora { get; set; }

    public string? Localizacao { get; set; }

    public string? Ata { get; set; }

    public virtual Pessoa Responsavel { get; set; } = null!;

    public virtual ICollection<ReuniaoPessoa> ReuniaoPessoas { get; set; } = new List<ReuniaoPessoa>();

    public virtual ICollection<ReuniaoProjeto> ReuniaoProjetos { get; set; } = new List<ReuniaoProjeto>();
}
