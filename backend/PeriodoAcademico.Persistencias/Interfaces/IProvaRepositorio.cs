using PeriodoAcademico.Contextos.Models;
using System.Threading.Tasks;

namespace PeriodoAcademico.Persistencias.Interfaces
{
    public interface IProvaRepositorio
    {
        Task<Prova[]> ObterProvasAsync();
        Task<Prova[]> ObterProvasPorNomeAsync(string nome);
        Task<Prova[]> ObterProvaPorMateriaAsync(string materia);
        Task<Prova[]> ObterProvaPorAlunoAsync(int alunoId);
        Task<Prova> ObterProvaPorIdAsync(int turmaId);
    }
}
