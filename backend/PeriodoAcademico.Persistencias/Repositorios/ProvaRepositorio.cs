using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Contextos.Models;
using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class ProvaRepositorio : IProvaRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public ProvaRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Prova[]> ObterProvasAsync()
        {
            try
            {
                IQueryable<Prova> query = _contexto.Provas
                    .AsNoTracking()
                    .Include(prova => prova.Aluno)
                    .Include(prova => prova.Materia)
                    .OrderBy(prova => prova.Id);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Prova> ObterProvaPorIdAsync(int provaId)
        {
            try
            {
                IQueryable<Prova> query = _contexto.Provas
                    .AsNoTracking()
                    .Where(prova => prova.Id == provaId)
                    .Include(prova => prova.Aluno)
                    .Include(prova => prova.Materia)
                    .OrderBy(prova => prova.Id);

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Prova[]> ObterProvasPorNomeAsync(string nome)
        {
            try
            {
                IQueryable<Prova> query = _contexto.Provas
                    .AsNoTracking()
                    .Where(prova => prova.Nome.ToUpper() == nome.ToUpper())
                    .Include(prova => prova.Aluno)
                    .Include(prova => prova.Materia)
                    .OrderBy(prova => prova.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Prova[]> ObterProvaPorMateriaAsync(string materia)
        {
            try
            {
                IQueryable<Prova> query = _contexto.Provas
                    .AsNoTracking()
                    .Where(prova => prova.Materia.Nome.ToUpper() == materia.ToUpper())
                    .Include(prova => prova.Aluno)
                    .Include(prova => prova.Materia)
                    .OrderBy(prova => prova.Materia.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Prova[]> ObterProvaPorAlunoAsync(int alunoId)
        {
            try
            {
                IQueryable<Prova> query = _contexto.Provas
                    .AsNoTracking()
                    .Where(prova => prova.Aluno.Id == alunoId)
                    .Include(prova => prova.Aluno)
                    .Include(prova => prova.Materia)
                    .OrderBy(prova => prova.Aluno.Nome);

                return await query.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
