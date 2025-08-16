using MedicalDiagnosis.Application.DTOs;

namespace MedicalDiagnosis.Application.Interfaces
{
    public interface IPatientService
    {
        DiagnosisResponseDto Diagnose(DiagnosisRequestDto request);
    }
}
