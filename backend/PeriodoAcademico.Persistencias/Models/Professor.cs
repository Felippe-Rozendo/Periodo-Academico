namespace PeriodoAcademico.Persistencias.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}
