using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ras.DAL.sakila;

public partial class RasContext : DbContext
{
    public RasContext()
    {
    }

    public RasContext(DbContextOptions<RasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Comite> Comites { get; set; }

    public virtual DbSet<ComitePessoa> ComitePessoas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventoPessoa> EventoPessoas { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Projeto> Projetos { get; set; }

    public virtual DbSet<ProjetoPessoa> ProjetoPessoas { get; set; }

    public virtual DbSet<Reuniao> Reuniaos { get; set; }

    public virtual DbSet<ReuniaoPessoa> ReuniaoPessoas { get; set; }

    public virtual DbSet<ReuniaoProjeto> ReuniaoProjetos { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillPessoa> SkillPessoas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=ras;Uid=root;Pwd=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.HasIndex(e => e.PessoaId, "FK_CARGO_PESSOA");

            entity.Property(e => e.CargoId).HasColumnName("CARGO_ID");
            entity.Property(e => e.NomeCargo)
                .HasColumnType("enum('MEMBRO','TRAINEE','VOLUNTARIO')")
                .HasColumnName("NOME_CARGO");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CARGO_PESSOA");
        });

        modelBuilder.Entity<Comite>(entity =>
        {
            entity.HasKey(e => e.ComiteId).HasName("PRIMARY");

            entity.ToTable("comite");

            entity.HasIndex(e => e.ResponsavelId, "FK_COMITE_RESPONSAVEL");

            entity.Property(e => e.ComiteId).HasColumnName("COMITE_ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.ResponsavelId).HasColumnName("RESPONSAVEL_ID");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.Comites)
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMITE_RESPONSAVEL");
        });

        modelBuilder.Entity<ComitePessoa>(entity =>
        {
            entity.HasKey(e => e.ComitePessoaId).HasName("PRIMARY");

            entity.ToTable("comite_pessoa");

            entity.HasIndex(e => e.ComiteId, "FK_COMITE_PESSOA_C");

            entity.HasIndex(e => e.PessoaId, "FK_COMITE_PESSOA_P");

            entity.Property(e => e.ComitePessoaId).HasColumnName("COMITE_PESSOA_ID");
            entity.Property(e => e.ComiteId).HasColumnName("COMITE_ID");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");

            entity.HasOne(d => d.Comite).WithMany(p => p.ComitePessoas)
                .HasForeignKey(d => d.ComiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMITE_PESSOA_C");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.ComitePessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COMITE_PESSOA_P");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PRIMARY");

            entity.ToTable("evento");

            entity.HasIndex(e => e.ResponsavelId, "FK_EVENTO_RESPONSAVEL");

            entity.Property(e => e.EventoId).HasColumnName("EVENTO_ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.DtHora)
                .HasColumnType("datetime")
                .HasColumnName("DT_HORA");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(100)
                .HasColumnName("LOCALIZACAO");
            entity.Property(e => e.Palestrante)
                .HasMaxLength(100)
                .HasColumnName("PALESTRANTE");
            entity.Property(e => e.ResponsavelId).HasColumnName("RESPONSAVEL_ID");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVENTO_RESPONSAVEL");
        });

        modelBuilder.Entity<EventoPessoa>(entity =>
        {
            entity.HasKey(e => e.EventoPessoaId).HasName("PRIMARY");

            entity.ToTable("evento_pessoa");

            entity.HasIndex(e => e.EventoId, "FK_EVENTO_PESSOA_E");

            entity.HasIndex(e => e.PessoaId, "FK_EVENTO_PESSOA_P");

            entity.Property(e => e.EventoPessoaId).HasColumnName("EVENTO_PESSOA_ID");
            entity.Property(e => e.EventoId).HasColumnName("EVENTO_ID");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");
            entity.Property(e => e.Status)
                .HasColumnType("enum('EMPROGRESSO','ABANDONADO','CONCLUIDO')")
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Evento).WithMany(p => p.EventoPessoas)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVENTO_PESSOA_E");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.EventoPessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EVENTO_PESSOA_P");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.PessoaId).HasName("PRIMARY");

            entity.ToTable("pessoa");

            entity.HasIndex(e => e.ProjetoId, "FK_PROJETO_PESSOA");

            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");
            entity.Property(e => e.Ativo)
                .HasColumnType("enum('ATIVO','NATIVO')")
                .HasColumnName("ATIVO");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("CELULAR");
            entity.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("CPF");
            entity.Property(e => e.DtIngressoCurso)
                .HasColumnType("datetime")
                .HasColumnName("DT_INGRESSO_CURSO");
            entity.Property(e => e.DtIngressoRas)
                .HasColumnType("datetime")
                .HasColumnName("DT_INGRESSO_RAS");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("NOME");
            entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .HasColumnName("SENHA");

            entity.HasOne(d => d.Projeto).WithMany(p => p.Pessoas)
                .HasForeignKey(d => d.ProjetoId)
                .HasConstraintName("FK_PROJETO_PESSOA");
        });

        modelBuilder.Entity<Projeto>(entity =>
        {
            entity.HasKey(e => e.ProjetoId).HasName("PRIMARY");

            entity.ToTable("projeto");

            entity.HasIndex(e => e.ResponsavelId, "FK_PROJETO_RESPONSAVEL");

            entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.ResponsavelId).HasColumnName("RESPONSAVEL_ID");
            entity.Property(e => e.Status)
                .HasColumnType("enum('EMPROGRESSO','ABANDONADO','CONCLUIDO')")
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.Projetos)
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJETO_RESPONSAVEL");
        });

        modelBuilder.Entity<ProjetoPessoa>(entity =>
        {
            entity.HasKey(e => e.ProjetoPessoaId).HasName("PRIMARY");

            entity.ToTable("projeto_pessoa");

            entity.HasIndex(e => e.PessoaId, "FK_PROJETO_PESSOA_PE");

            entity.HasIndex(e => e.ProjetoId, "FK_PROJETO_PESSOA_PR");

            entity.Property(e => e.ProjetoPessoaId).HasColumnName("PROJETO_PESSOA_ID");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");
            entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.ProjetoPessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJETO_PESSOA_PE");

            entity.HasOne(d => d.Projeto).WithMany(p => p.ProjetoPessoas)
                .HasForeignKey(d => d.ProjetoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJETO_PESSOA_PR");
        });

        modelBuilder.Entity<Reuniao>(entity =>
        {
            entity.HasKey(e => e.ReuniaoId).HasName("PRIMARY");

            entity.ToTable("reuniao");

            entity.HasIndex(e => e.ResponsavelId, "FK_REUNIAO_RESPONSAVEL");

            entity.Property(e => e.ReuniaoId).HasColumnName("REUNIAO_ID");
            entity.Property(e => e.Ata)
                .HasMaxLength(250)
                .HasColumnName("ATA");
            entity.Property(e => e.Descricao)
                .HasMaxLength(250)
                .HasColumnName("DESCRICAO");
            entity.Property(e => e.DtHora)
                .HasColumnType("datetime")
                .HasColumnName("DT_HORA");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(100)
                .HasColumnName("LOCALIZACAO");
            entity.Property(e => e.ResponsavelId).HasColumnName("RESPONSAVEL_ID");

            entity.HasOne(d => d.Responsavel).WithMany(p => p.Reuniaos)
                .HasForeignKey(d => d.ResponsavelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REUNIAO_RESPONSAVEL");
        });

        modelBuilder.Entity<ReuniaoPessoa>(entity =>
        {
            entity.HasKey(e => e.ReuniaoPessoaId).HasName("PRIMARY");

            entity.ToTable("reuniao_pessoa");

            entity.HasIndex(e => e.PessoaId, "FK_REUNIAO_PESSOA_P");

            entity.HasIndex(e => e.ReuniaoId, "FK_REUNIAO_PESSOA_R");

            entity.Property(e => e.ReuniaoPessoaId).HasColumnName("REUNIAO_PESSOA_ID");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");
            entity.Property(e => e.ReuniaoId).HasColumnName("REUNIAO_ID");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.ReuniaoPessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REUNIAO_PESSOA_P");

            entity.HasOne(d => d.Reuniao).WithMany(p => p.ReuniaoPessoas)
                .HasForeignKey(d => d.ReuniaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REUNIAO_PESSOA_R");
        });

        modelBuilder.Entity<ReuniaoProjeto>(entity =>
        {
            entity.HasKey(e => e.ReuniaoProjetoId).HasName("PRIMARY");

            entity.ToTable("reuniao_projeto");

            entity.HasIndex(e => e.ProjetoId, "FK_REUNIAO_PROJETO_P");

            entity.HasIndex(e => e.ReuniaoId, "FK_REUNIAO_PROJETO_R");

            entity.Property(e => e.ReuniaoProjetoId).HasColumnName("REUNIAO_PROJETO_ID");
            entity.Property(e => e.ProjetoId).HasColumnName("PROJETO_ID");
            entity.Property(e => e.ReuniaoId).HasColumnName("REUNIAO_ID");

            entity.HasOne(d => d.Projeto).WithMany(p => p.ReuniaoProjetos)
                .HasForeignKey(d => d.ProjetoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REUNIAO_PROJETO_P");

            entity.HasOne(d => d.Reuniao).WithMany(p => p.ReuniaoProjetos)
                .HasForeignKey(d => d.ReuniaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REUNIAO_PROJETO_R");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PRIMARY");

            entity.ToTable("skill");

            entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");
            entity.Property(e => e.NomeSkill)
                .HasMaxLength(50)
                .HasColumnName("NOME_SKILL");
            entity.Property(e => e.TipoSkill)
                .HasColumnType("enum('HARD','SOFT')")
                .HasColumnName("TIPO_SKILL");
        });

        modelBuilder.Entity<SkillPessoa>(entity =>
        {
            entity.HasKey(e => e.SkillPessoaId).HasName("PRIMARY");

            entity.ToTable("skill_pessoa");

            entity.HasIndex(e => e.PessoaId, "FK_SKILL_PESSOA_P");

            entity.HasIndex(e => e.SkillId, "FK_SKILL_PESSOA_S");

            entity.Property(e => e.SkillPessoaId).HasColumnName("SKILL_PESSOA_ID");
            entity.Property(e => e.PessoaId).HasColumnName("PESSOA_ID");
            entity.Property(e => e.SkillId).HasColumnName("SKILL_ID");

            entity.HasOne(d => d.Pessoa).WithMany(p => p.SkillPessoas)
                .HasForeignKey(d => d.PessoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SKILL_PESSOA_P");

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillPessoas)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SKILL_PESSOA_S");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
