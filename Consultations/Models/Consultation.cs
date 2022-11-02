namespace Consultations.Models
{
    public class Consultation
    {
        public int Id { get; }
        public DateTime Time { get; private set; }
        public string? Symptoms { get; private set; }
        public Patient Patient { get; private set; }
    }
}
