using System;
using System.Collections.Generic;

namespace ras.DAL.sakila;

public partial class Skill
{
    public int SkillId { get; set; }

    public string NomeSkill { get; set; } = null!;

    public string? TipoSkill { get; set; }

    public virtual ICollection<SkillPessoa> SkillPessoas { get; set; } = new List<SkillPessoa>();
}
