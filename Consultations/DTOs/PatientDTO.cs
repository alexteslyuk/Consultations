namespace Consultations.DTOs
{
    public class PatientDTO
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string SNILS { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
    }
}
