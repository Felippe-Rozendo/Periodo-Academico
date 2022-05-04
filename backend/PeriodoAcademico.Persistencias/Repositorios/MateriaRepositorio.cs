using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;
using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public MateriaRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Materia[]> ObterMateriasAsync()
        {
            try
            {
                IQueryable<Materia> query = _contexto.Materias
                    .AsNoTracking()
                    .Include(materia => materia.Provas)
                    .OrderBy(materia => materia.Id);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Materia> ObterMateriaPorIdAsync(int materiaId)
        {
            try
            {
                IQueryable<Materia> query = _contexto.Materias
                    .AsNoTracking()
                    .Where(materia => materia.Id == materiaId)
                    .Include(materia => materia.Provas)
                    .OrderBy(materia => materia.Id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Materia[]> ObterMateriasPorNomeAsync(string nome)
        {
            try
            {
                IQueryable<Materia> query = _contexto.Materias
                    .AsNoTracking()
                    .Where(materia => materia.Nome.ToUpper() == nome.ToUpper())
                    .Include(materia => materia.Provas)
                    .OrderBy(materia => materia.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
