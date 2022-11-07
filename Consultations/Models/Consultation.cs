namespace Consultations.Models
{
    public class Consultation
    {
        public int Id { get; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string? Symptoms { get; private set; }
        public Patient Patient { get; set; }

        private Consultation()
        {
        }

        public Consultation(DateTime startDate, DateTime endDate, string? symptoms)
        {
            StartDate = startDate;
            EndDate = endDate;
            Symptoms = symptoms;
        }

        public void Edit(DateTime startDate, DateTime endDate, string? symptoms)
        {
            StartDate = startDate;
            EndDate = endDate;
            Symptoms = symptoms;
        }
    }
}
