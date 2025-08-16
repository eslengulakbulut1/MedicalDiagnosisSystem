namespace MedicalDiagnosis.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // İlişkiler
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
