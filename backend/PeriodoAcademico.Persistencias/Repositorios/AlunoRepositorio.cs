using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;
using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public AlunoRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Aluno[]> ObterAlunosAsync()
        {
            try
            {
                IQueryable<Aluno> query = _contexto.Alunos
                    .AsNoTracking()
                    .Include(aluno => aluno.Turma)
                    .Include(aluno => aluno.Provas)
                    .OrderBy(aluno => aluno.Id);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Aluno> ObterAlunoPorIdAsync(int alunoId)
        {
            try
            {
                IQueryable<Aluno> query = _contexto.Alunos
                    .AsNoTracking()
                    .Where(aluno => aluno.Id == alunoId)
                    .Include(aluno => aluno.Turma)
                    .Include(aluno => aluno.Provas)
                    .OrderBy(aluno => aluno.Id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Aluno[]> ObterAlunosPorNomeAsync(string nome)
        {
            try
            {
                IQueryable<Aluno> query = _contexto.Alunos
                    .AsNoTracking()
                    .Where(aluno => aluno.Nome.ToUpper() == nome.ToUpper())
                    .Include(aluno => aluno.Turma)
                    .Include(aluno => aluno.Provas)
                    .OrderBy(aluno => aluno.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
