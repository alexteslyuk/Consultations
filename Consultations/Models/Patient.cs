using Consultations.DTOs;

namespace Consultations.Models
{
    public class Patient
    {
        private readonly List<Consultation> _consultations = new List<Consultation>();

        public int Id { get; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string? Patronymic { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public string SNILS { get; private set; }
        public double? Weight { get; private set; }
        public double? Height { get; private set; }

        public IReadOnlyList<Consultation> Consultations => _consultations;

        public Patient(string surname, string name, string? patronymic, DateTime birthDate, string gender, string snils, double? weight, double? height)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Gender = gender;
            SNILS = snils;
            Weight = weight;
            Height = height;
        }

        public void Edit(string surname, string name, string? patronymic, DateTime birthDate, string gender, string snils, double? weight, double? height)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Gender = gender;
            SNILS = snils;
            Weight = weight;
            Height = height;
        }
    }
}
