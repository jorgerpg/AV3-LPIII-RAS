using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Comite
{
    public int ComiteId { get; set; }

    public int ResponsavelId { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<ComitePessoa> ComitePessoas { get; set; } = new List<ComitePessoa>();

    public virtual Pessoa Responsavel { get; set; } = null!;
}
