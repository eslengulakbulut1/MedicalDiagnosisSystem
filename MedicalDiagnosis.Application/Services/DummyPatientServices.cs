using MedicalDiagnosis.Application.DTOs;
using MedicalDiagnosis.Application.Interfaces;

namespace MedicalDiagnosis.Application.Services
{
    public class DummyPatientServices : IPatientService
    {
        public string Diagnose(List<string> symptoms)
        {
            if (symptoms.Contains("baş ağrısı") && symptoms.Contains("bulantı"))
                return "Migren olabilir.";
            if (symptoms.Contains("yüksek tansiyon"))
                return "Hipertansiyon belirtisi olabilir.";

            return "Belirtiler genel, daha fazla bilgiye ihtiyaç var.";
        }

        public DiagnosisResponseDto Diagnose(DiagnosisRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
