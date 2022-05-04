namespace PeriodoAcademico.Contextos.Models
{
    public class Prova
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Nota { get; set; }
        public double Peso { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
