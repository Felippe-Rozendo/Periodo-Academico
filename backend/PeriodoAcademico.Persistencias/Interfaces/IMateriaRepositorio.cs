using PeriodoAcademico.Contextos.Models;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface IMateriaRepositorio
    {
        Task<Materia[]> ObterMateriasAsync();
        Task<Materia[]> ObterMateriasPorNomeAsync(string nome);
        Task<Materia> ObterMateriaPorIdAsync(int turmaId);
    }
}
