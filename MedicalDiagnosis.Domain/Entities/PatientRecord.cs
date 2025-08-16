namespace MedicalDiagnosis.Domain.Entities
{
    public class PatientRecord
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty; // virgülle ayrılmış
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
