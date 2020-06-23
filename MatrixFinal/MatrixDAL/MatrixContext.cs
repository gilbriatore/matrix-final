using br.edu.up.mtx.domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace br.edu.up.mtx.dal
{
    public class MatrixContext : IdentityDbContext
    {
        public DbSet<Mensagem> Mensagems { get; set; }
        public DbSet<Atitude> Atitudes { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Bloom> NiveisDeBloom { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Conhecimento> Conhecimentos { get; set; }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<DCN> DCNs { get; set; }
        public DbSet<Diretriz> Diretrizes { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Habilidade> Habilidades { get; set; }
        public DbSet<Matriz> Matrizes { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PerfilDoCurso> PerfisDoCurso { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<TipoDeCurso> TiposDeCurso { get; set; }
        public DbSet<Trilha> Trilhas { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Perfis do curso
            modelBuilder.Entity<PerfilDoCurso>()
               .HasKey(pc => new { pc.CursoId, pc.PerfilId });

            modelBuilder.Entity<PerfilDoCurso>()
                .HasOne(pc => pc.Curso)
                .WithMany(c => c.PerfisDoCurso)
                .HasForeignKey(pc => pc.CursoId);

            modelBuilder.Entity<PerfilDoCurso>()
                .HasOne(pc => pc.Perfil)
                .WithMany(p => p.PerfisDoCurso)
                .HasForeignKey(pc => pc.PerfilId);

            //Unidades da disciplina
            modelBuilder.Entity<UnidadeDaDisciplina>()
                .HasKey(ud => new { ud.DisciplinaId, ud.UnidadeId});

            modelBuilder.Entity<UnidadeDaDisciplina>()
                .HasOne(ud => ud.Disciplina)
                .WithMany(d => d.UnidadesDaDisciplina)
                .HasForeignKey(ud => ud.DisciplinaId);

            modelBuilder.Entity<UnidadeDaDisciplina>()
                .HasOne(ud => ud.Unidade)
                .WithMany(u => u.UnidadesDaDisciplina)
                .HasForeignKey(ud => ud.UnidadeId);

            //Períodos da trilha
            modelBuilder.Entity<PeriodoDaTrilha>()
                .HasKey(pt => new { pt.TrilhaId, pt.PeriodoId });

            modelBuilder.Entity<PeriodoDaTrilha>()
                .HasOne(pt => pt.Trilha)
                .WithMany(d => d.PeridosDaTrilha)
                .HasForeignKey(pt => pt.TrilhaId);

            modelBuilder.Entity<PeriodoDaTrilha>()
                .HasOne(pt => pt.Periodo)
                .WithMany(u => u.PeridosDaTrilha)
                .HasForeignKey(pt => pt.PeriodoId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Matrix;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /* public MatrixContext(DbContextOptions<MatrixContext> options)
                 : base(options)
         {
         }*/

    }
}
