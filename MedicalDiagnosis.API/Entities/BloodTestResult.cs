
namespace MedicalDiagnosisAPI.Entities
{
    // BloodTestResult sınıfı, kan testi sonuçlarını tutar.
    public class BloodTestResult
    {
        public double Hemoglobin { get; set; } // g/dL
        public double WhiteBloodCellCount { get; set; } // x10^9/L
        public double PlateletCount { get; set; } // x10^9/L
    }
}
