using System.Collections.Generic;

namespace MedicalDiagnosis.Application.DTOs
{
    public class DiagnosisResponseDto
    {
        public List<string> PossibleConditions { get; set; } = new(); // olası hastalık isimleri
        public Dictionary<string, int> ConditionScores { get; set; } = new(); // hastalık=puan
        public FollowUpAdviceDto FollowUp { get; set; } = new();
        public List<string> NextQuestions { get; set; } = new(); // derinleştirici sorular
        public string Notes { get; set; } = "Bu bir ön değerlendirmedir; kesin tanı için hekime başvurunuz.";
    }
}
