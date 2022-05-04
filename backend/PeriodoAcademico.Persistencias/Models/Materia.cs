using System.Collections.Generic;

namespace PeriodoAcademico.Persistencias.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Prova> Provas { get; set; }
    }
}
