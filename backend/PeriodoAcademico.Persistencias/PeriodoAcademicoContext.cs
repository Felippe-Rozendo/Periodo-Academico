using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;

namespace PeriodoAcademico.Persistencias
{
    public class PeriodoAcademicoContext : DbContext
    {

        public PeriodoAcademicoContext(DbContextOptions<PeriodoAcademicoContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Prova> Provas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Aluno>().HasKey(aluno => new { aluno.Turma.Id });

            //modelBuilder.Entity<Prova>().HasKey(prova => new { prova.Aluno.Id, prova.Materia.Id });

            //modelBuilder.Entity<Professor>().HasKey(professor => new { professor.Materia.Id });
        }
    }
}
