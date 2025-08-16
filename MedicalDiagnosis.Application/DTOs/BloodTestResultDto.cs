        
namespace MedicalDiagnosis.Application.DTOs
{
    public class BloodTestResultDto
    {
        public double? Hemoglobin { get; set; }          // g/dL
        public double? WhiteBloodCellCount { get; set; } // x10^9/L
        public double? PlateletCount { get; set; }       // x10^9/L
    }
}

