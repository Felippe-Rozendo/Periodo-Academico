using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface IGeralRepositorio
    {
        void AdicionarAsync<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Excluir<T>(T entity) where T : class;
        Task<bool> SalvarAlteracoesAsync();
    }
}
