namespace Consultations.Models
{
    public class Consultation
    {
        public int Id { get; }
        public DateTime Date { get; private set; }
        public string? Symptoms { get; private set; }
        public Patient Patient { get; private set; }

        public Consultation(DateTime date, string? symptoms, Patient patient)
        {
            Date = date;
            Symptoms = symptoms;
        }

        public void Edit(DateTime date, string? symptoms)
        {
            Date = date;
            Symptoms = symptoms;
        }
    }
}
