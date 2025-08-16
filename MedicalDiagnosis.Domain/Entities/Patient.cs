namespace MedicalDiagnosis.Domain.Entities
{
    public class Patient  // <-- public olmalı
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // İlişkiler: // Hastanın randevuları ve tıbbi kayıtları
        public ICollection<Appointment> Appointments { get; set; } 
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
