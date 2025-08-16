namespace MedicalDiagnosis.Domain.Entities
{
    // Teşhis sınıfı, hastalık teşhis bilgilerini tutar.
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Result { get; set; } = string.Empty; // Hastalık adı, teşhis
        public string Notes { get; set; } = string.Empty; // Ek açıklamalar
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Yabancı Anahtarlar
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
