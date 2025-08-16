using System;
using System.Collections.Generic;
using System.Linq;
using MedicalDiagnosis.Application.DTOs;
using MedicalDiagnosis.Application.Interfaces;

namespace MedicalDiagnosis.Application.Services
{
    public class AdvancedPatientService : IPatientService
    {
        public DiagnosisResponseDto Diagnose(DiagnosisRequestDto req)
        {
            // Kullanıcının gönderdiği semptomları küçük harfe çevirip tekrar edenleri temizliyoruz.
            var symptoms = req.Symptoms.Select(s => s.Trim().ToLower()).ToHashSet();

            // Hastalık puanlarını tutacak sözlük
            var scores = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            // Belirtilen hastalık için puan ekleyen yardımcı fonksiyon
            void AddScore(string condition, int points)
            {
                if (!scores.ContainsKey(condition)) scores[condition] = 0;
                scores[condition] += points;
            }

            // --- Basit semptom bazlı puanlama ---
            if (symptoms.Contains("baş ağrısı")) AddScore("Migren", 2);
            if (symptoms.Contains("bulantı")) AddScore("Migren", 1);

            if (symptoms.Contains("öksürük") || symptoms.Contains("boğaz ağrısı"))
                AddScore("Üst Solunum Yolu Enfeksiyonu (Viral)", 2);

            if (symptoms.Contains("ateş"))
            {
                AddScore("Enfeksiyon", 2);
                AddScore("Üst Solunum Yolu Enfeksiyonu (Viral)", 1);
            }

            if (symptoms.Contains("göğüs ağrısı") || symptoms.Contains("nefes darlığı"))
                AddScore("Kardiyak/Respiratuvar Değerlendirme Gerekir", 4);

            if (symptoms.Contains("yüksek tansiyon") || symptoms.Contains("baş dönmesi"))
                AddScore("Hipertansiyon", 3);

            // --- Kan testi bazlı puanlama (varsa) ---
            var bt = req.BloodTest;
            if (bt != null)
            {
                // Yüksek beyaz kan hücresi sayısı → enfeksiyon ihtimali
                if (bt.WhiteBloodCellCount.HasValue && bt.WhiteBloodCellCount.Value > 11)
                    AddScore("Enfeksiyon", 3);

                // Düşük hemoglobin → anemi ihtimali
                if (bt.Hemoglobin.HasValue)
                {
                    var hb = bt.Hemoglobin.Value;
                    // Basit referans aralıkları (tıbbi doğrulama gerektirir)
                    if ((req.Patient.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) && hb < 13) ||
                        (req.Patient.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase) && hb < 12) ||
                        (req.Patient.Gender.Equals("Other", StringComparison.OrdinalIgnoreCase) && hb < 12.5))
                    {
                        AddScore("Anemi", 3);
                    }
                }

                // Düşük trombosit sayısı → hematolojik değerlendirme önerisi
                if (bt.PlateletCount.HasValue && bt.PlateletCount.Value < 150)
                    AddScore("Hematolojik Değerlendirme Gerekir (Trombosit Düşüklüğü)", 3);
            }

            // --- Risk değerlendirmesi & takip önerisi ---
            var response = new DiagnosisResponseDto();

            // En yüksek puanlı 3 olası hastalığı ekle
            foreach (var kv in scores.OrderByDescending(k => k.Value).Take(3))
                response.PossibleConditions.Add(kv.Key);

            // Tüm durumların puanlarını ekle
            response.ConditionScores = scores
                .OrderByDescending(k => k.Value)
                .ToDictionary(k => k.Key, v => v.Value, StringComparer.OrdinalIgnoreCase);

            // Acil durum değerlendirmesi
            var urgent = symptoms.Contains("göğüs ağrısı") || symptoms.Contains("nefes darlığı");
            var highRiskHT = symptoms.Contains("yüksek tansiyon") || symptoms.Contains("şiddetli baş ağrısı");

            if (urgent)
            {
                // Hayati risk olabilir, acil yönlendirme
                response.FollowUp = new FollowUpAdviceDto
                {
                    Urgency = "Immediate",
                    Recommendation = "Acil durum belirtisi olabilir. Derhal acil servise başvurun.",
                    RecheckIn = "Now"
                };
            }
            else if (highRiskHT)
            {
                // Hipertansiyon riski, 1 saat içinde tekrar ölçüm önerisi
                response.FollowUp = new FollowUpAdviceDto
                {
                    Urgency = "High",
                    Recommendation = "Kan basıncınızı ölçün ve yakın takip edin.",
                    RecheckIn = "1 hour"
                };
            }
            else if (scores.Any() && scores.Values.Max() >= 4)
            {
                // Orta seviye risk, 12 saat içinde takip
                response.FollowUp = new FollowUpAdviceDto
                {
                    Urgency = "Medium",
                    Recommendation = "Semptomlarınızı izleyin; şikayet artarsa sağlık kuruluşuna başvurun.",
                    RecheckIn = "12 hours"
                };
            }
            else
            {
                // Düşük risk, evde bakım önerisi
                response.FollowUp = new FollowUpAdviceDto
                {
                    Urgency = "Low",
                    Recommendation = "Bol sıvı, dinlenme. Gerekirse aile hekimine başvurun.",
                    RecheckIn = "3 days"
                };
            }

            // --- Derinleştirici ek sorular ---
            var next = new List<string>();
            if (symptoms.Contains("baş ağrısı"))
            {
                next.Add("Baş ağrısı ne kadar süredir devam ediyor?");
                next.Add("Işığa/sese hassasiyet var mı?");
            }
            if (symptoms.Contains("ateş"))
            {
                next.Add("En yüksek ölçtüğünüz ateş kaç dereceydi?");
                next.Add("Ateş gece artıyor mu?");
            }
            if (symptoms.Contains("öksürük"))
            {
                next.Add("Balgam var mı? Rengi nedir?");
                next.Add("Nefes darlığı ya da göğüs ağrısı eşlik ediyor mu?");
            }
            response.NextQuestions = next.Distinct().ToList(); // Tekrarlayan soruları temizle

            return response;
        }
    }
}
