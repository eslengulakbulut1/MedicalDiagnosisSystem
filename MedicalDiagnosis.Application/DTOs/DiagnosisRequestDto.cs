using MedicalDiagnosis.API.DTOs;
using MedicalDiagnosis.Application.DTOs;
using System.Collections.Generic;
public class DiagnosisRequestDto
{
    public PatientDto Patient { get; set; } = new();
    public List<string> Symptoms { get; set; } = new();
    public BloodTestResultDto? BloodTest { get; set; }
    public string? OnsetDays { get; set; } // "1-3", "3-7", "7+"
}


