using MedicalDiagnosisAPI.Entities;

// DiagnosisRequest sınıfı, bir hastanın teşhis talebini temsil eder.
namespace MedicalDiagnosisAPI.Entities;
public class DiagnosisRequest
{
    public Patient Patient { get; set; }
    public List<string> Symptoms { get; set; }
    public BloodTestResult BloodTest { get; set; }
}