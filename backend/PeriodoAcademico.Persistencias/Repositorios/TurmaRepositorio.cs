using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using PeriodoAcademico.Contextos.Models;
using Microsoft.EntityFrameworkCore;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public TurmaRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Turma[]> ObterTurmasAsync()
        {
            try
            {
                IQueryable<Turma> query = _contexto.Turmas
                    .AsNoTracking()    
                    .Include(turma => turma.Alunos)
                    .OrderBy(turma => turma.Id);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Turma> ObterTurmaPorIdAsync(int turmaId)
        {
            try
            {
                IQueryable<Turma> query = _contexto.Turmas
                    .AsNoTracking()
                    .Where(turma => turma.Id == turmaId)
                    .Include(turma => turma.Alunos)
                    .OrderBy(turma => turma.Id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Turma[]> ObterTurmasPorNomeAsync(string nome)
        {
            try
            {
                IQueryable<Turma> query = _contexto.Turmas
                    .AsNoTracking()
                    .Where(turma => turma.Nome.ToUpper() == nome.ToUpper())
                    .Include(turma => turma.Alunos)
                    .OrderBy(turma => turma.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
