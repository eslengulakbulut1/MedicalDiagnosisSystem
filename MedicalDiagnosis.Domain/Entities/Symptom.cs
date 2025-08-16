namespace MedicalDiagnosis.Domain.Entities
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Ateş, baş ağrısı vb.
        public string Severity { get; set; } = string.Empty; // Hafif, Orta, Şiddetli

        // Yabancı Anahtar
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
}
