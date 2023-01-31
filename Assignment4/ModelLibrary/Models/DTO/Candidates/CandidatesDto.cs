using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.DTO.Candidates
{
    public class CandidatesDto
    {
        public string AppUserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Landline { get; set; }
        public string? Mobile { get; set; }
        public string? CandidateNumber { get; set; }
        public string? PhotoIdNumber { get; set; }
        public DateTime? PhotoIdIssueDate { get; set; }
        public GenderDto? Gender { get; set; }
        public LanguageDto? Language { get; set; }
        public PhotoIdTypeDto? PhotoIdType { get; set; }
        public ICollection<AddressDto>? Address { get; set; }
    }
}
