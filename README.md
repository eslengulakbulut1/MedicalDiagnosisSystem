# 🩺 Medical Diagnosis System

Bu proje, tıbbi teşhis süreçlerini desteklemeyi amaçlayan bir sistemdir. Amaç, hastaların verileri üzerinden bulguların tespitini kolaylaştırmak ve klinik karar süreçlerini desteklemektir. Projenin bazı bölümleri (örneğin görüntü işleme) geliştirme aşamasındadır ve ilerleyen versiyonlarda entegre edilecektir.

---

## ✨ Özellikler
- 🏗️ Katmanlı mimari (API, Infrastructure, Domain, Application)  
- 🗄️ Entity Framework Core ile veritabanı yönetimi  
- 💾 SQL Server desteği  
- 🌐 RESTful API uç noktaları  
- 🤖 Gelecekte görüntü işleme ve yapay zeka entegrasyonu planlanmaktadır

---

## 📂 Proje Yapısı
MedicalDiagnosisSystem/
│
├── MedicalDiagnosis.API # REST API katmanı
├── MedicalDiagnosis.Application # İş kuralları ve servisler
├── MedicalDiagnosis.Domain # Varlıklar ve çekirdek modeller
├── MedicalDiagnosis.Infrastructure# Veritabanı erişimi (EF Core)
└── README.md # Proje açıklaması

## 🛠️ Kullanılan Teknolojiler
- .NET8.0 / C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Web API
- Git & GitHub

## 📌 Yol Haritası
Görev	Durum
Katmanlı mimari kurulumu	✅
EF Core ile veritabanı bağlantısı	✅
Hasta, Çalışan ve Seans yönetimi	⚪
Görüntü işleme ve yapay zeka entegrasyonu	⚪
Web/Mobil arayüz geliştirme	⚪

**
