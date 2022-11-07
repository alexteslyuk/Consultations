namespace Consultations.DTOs
{
    public class ConsultationDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Symptoms { get; set; }
        public int PatientId { get; set; }
    }
}
