// Randevu sınıfı, randevu bilgilerini tutar.

namespace MedicalDiagnosis.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Varsayılan";

        // Yabancı Anahtarlar
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
