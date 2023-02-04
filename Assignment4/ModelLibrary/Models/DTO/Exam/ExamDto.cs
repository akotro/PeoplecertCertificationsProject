using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models.DTO.Certificates;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.Questions;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Exams
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string? CertificateTitle { get; set; }

        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public CertificateDto? Certificate { get; set; }
        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public virtual ICollection<QuestionDto>? Questions { get; set; }
    }
}
