using Microsoft.EntityFrameworkCore;
using PeriodoAcademico.Persistencias.Interfaces;
using System;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Repositorios
{
    public class GeralRepositorio : IGeralRepositorio
    {
        private readonly PeriodoAcademicoContext _contexto;

        public GeralRepositorio(PeriodoAcademicoContext contexto)
        {
            _contexto = contexto;
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async void AdicionarAsync<T>(T entity) where T : class
        {
            try
            {
                await _contexto.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public void Atualizar<T>(T entity) where T : class
        {
            try
            {
                _contexto.Update(entity);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public void Excluir<T>(T entity) where T : class
        {
            try
            {
                _contexto.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            try
            {
                return (await _contexto.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
