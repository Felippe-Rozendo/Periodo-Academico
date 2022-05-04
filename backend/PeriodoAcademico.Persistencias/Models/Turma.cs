using System.Collections.Generic;

namespace PeriodoAcademico.Persistencias.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
