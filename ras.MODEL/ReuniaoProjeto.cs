using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class ReuniaoProjeto
{
    public int ReuniaoProjetoId { get; set; }

    public int ReuniaoId { get; set; }

    public int ProjetoId { get; set; }

    public virtual Projeto Projeto { get; set; } = null!;

    public virtual Reuniao Reuniao { get; set; } = null!;
}
