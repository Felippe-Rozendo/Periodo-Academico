﻿using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;

namespace PeriodoAcademico.Contextos
{
    public class PeriodoAcademicoContext: DbContext
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
        }
    }
}
