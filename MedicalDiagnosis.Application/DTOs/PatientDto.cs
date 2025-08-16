using MedicalDiagnosis.API.DTOs;

namespace MedicalDiagnosis.API.DTOs
{
    public class PatientDto
    {
        public int Age { get; set; }
        public string FullName { get; set; } = "";
        public string Gender { get; set; } = "Other"; // "Male, Female, Other"
    }
}


