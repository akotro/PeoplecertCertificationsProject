using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.DTO.CandidateExam
{
    internal class CandidateExamAnswersDto
    {
        public int Id { get; set; }
        public string? CorrectOption { get; set; }
        public string? ChosenOption { get; set; }
        public bool? IsCorrect { get; set; }
        public bool? IsCorrectModerated { get; set; }
        public virtual CandidateExamDto? CandidateExamDto { get; set; }

    }
}
