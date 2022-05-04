using PeriodoAcademico.Contextos.Models;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<Professor[]> ObterProfessoresAsync();
        Task<Professor[]> ObterProfessoresPorNomeAsync(string nome);
        Task<Professor> ObterProfessorPorIdAsync(int turmaId);
    }
}
