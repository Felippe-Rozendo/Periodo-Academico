using PeriodoAcademico.Contextos.Models;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<Turma[]> ObterTurmasAsync();
        Task<Turma[]> ObterTurmasPorNomeAsync(string nome);
        Task<Turma> ObterTurmaPorIdAsync(int turmaId);
    }
}
