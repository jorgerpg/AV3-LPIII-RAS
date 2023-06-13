using System;
using System.Collections.Generic;

namespace ras.MODEL;

public partial class Cargo
{
    public int CargoId { get; set; }

    public int PessoaId { get; set; }

    public string? NomeCargo { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;
}
