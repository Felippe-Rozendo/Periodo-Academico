using System.Collections.Generic;

namespace PeriodoAcademico.Contextos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Turma Turma { get; set; }
        public List<Prova> Provas { get; set; }
    }
}
