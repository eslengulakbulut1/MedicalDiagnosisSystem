namespace MedicalDiagnosisAPI.Entities
{
    // MedicalDiagnosis.API katmanında kullanılacak olan hasta varlık sınıfı
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; } // "Male", "Female", "Other"
    }
}
