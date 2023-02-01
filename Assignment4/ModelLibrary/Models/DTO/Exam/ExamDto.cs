using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models.DTO.Certificates;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Exams
{
    public class ExamDto
    {
        public int Id { get; set; }
        public string? CertificateTitle { get; set; }

        [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
        public CertificateDto? Certificate { get; set; }
    }
}
