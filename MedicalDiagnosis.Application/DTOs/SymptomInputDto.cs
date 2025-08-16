using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDiagnosis.Application.DTOs;

public class SymptomInputDto
{
    public List<string> Symptoms { get; set; } = new List<string>();
}
