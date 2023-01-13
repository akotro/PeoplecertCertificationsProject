using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models.Candidate
{
    internal class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfbirth { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string CandidateNumber { get; set; }
        public  string PhotoIdNumber { get; set; }
        public DateTime PhotoIdIssueDate { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Language Language { get; set; }
        public virtual PhotoIdType PhotoIdType{ get; set; }
        public Address Address { get; set; }


    }
}
