public class FollowUpAdviceDto
{
    // FollowUpAdviceDto sınıfı, hastaya yönelik takip ve öneri bilgilerini tutar.
    public string Urgency { get; set; } = "Yüksek"; // "Yüksek", "Orta", "Düşük", "İhmal Edilebilir" acillik durumu
    public string Recommendation { get; set; } = ""; // "Doktora başvurun", "Evde dinlenin", "Bol sıvı alın" gibi öneriler
    public string RecheckIn { get; set; } = ""; // Yeniden kontrol süresi, örneğin "1 saat", "12 saat", "3 gün" gibi
}