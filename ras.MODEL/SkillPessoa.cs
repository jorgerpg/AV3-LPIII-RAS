using System;
using System.Collections.Generic;

namespace ras.MODEL;

public partial class SkillPessoa
{
    public int SkillPessoaId { get; set; }

    public int SkillId { get; set; }

    public int PessoaId { get; set; }

    public virtual Pessoa Pessoa { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
