using System.Collections.Generic;

namespace PeriodoAcademico.Persistencias.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public List<Prova> Provas { get; set; }
    }
}
