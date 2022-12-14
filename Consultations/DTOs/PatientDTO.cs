namespace Consultations.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string SNILS { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public int Age { get; set; }
        public List<ConsultationDTO>? Consultations { get; set; }
    }
}
