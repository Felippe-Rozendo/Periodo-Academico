using PeriodoAcademico.Contextos.Models;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno[]> ObterAlunosAsync();
        Task<Aluno[]> ObterAlunosPorNomeAsync(string nome);
        Task<Aluno> ObterAlunoPorIdAsync(int turmaId);
    }
}
