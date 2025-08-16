namespace MedicalDiagnosis.Domain.Entities
{
    // MedicalRecord sınıfı, hastaların tıbbi kayıtlarını tutar.
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty; // Notlar, raporlar vb.

        // Yabancı Anahtarlar
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<Symptom> Symptoms { get; set; }
        public ICollection<Diagnosis> Diagnoses { get; set; }
    }
}
