using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;
using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public ProfessorRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Professor[]> ObterProfessoresAsync()
        {
            try
            {
                IQueryable<Professor> query = _contexto.Professores
                    .AsNoTracking()
                    .Include(professor => professor.Materia)
                    .OrderBy(professor => professor.Id);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Professor> ObterProfessorPorIdAsync(int professorId)
        {
            try
            {
                IQueryable<Professor> query = _contexto.Professores
                    .AsNoTracking()
                    .Where(professor => professor.Id == professorId)
                    .Include(professor => professor.Materia)
                    .OrderBy(professor => professor.Id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Professor[]> ObterProfessoresPorNomeAsync(string nome)
        {
            try
            {
                IQueryable<Professor> query = _contexto.Professores
                    .AsNoTracking()
                    .Where(professor => professor.Nome.ToUpper() == nome.ToUpper())
                    .Include(professor => professor.Materia)
                    .OrderBy(professor => professor.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
