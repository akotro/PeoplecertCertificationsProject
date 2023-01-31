using Assignment4Final.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.Questions;

namespace Assignment4Final.Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            if (!CandidatesDbSetExists())
            {
                return Enumerable.Empty<Candidate>();
            }

            return await _context.Candidates
                .Include(a => a.Gender)
                .Include(a => a.Language)
                .Include(a => a.PhotoIdType)
                .Include(a => a.Address).ThenInclude(a => a.Country)
                .ToListAsync();            
        }

        public async Task<Candidate?> GetCandidate(string appUserId)
        {
            if (!CandidatesDbSetExists())
            {
                return null;
            }

            return await _context.Candidates
                .Include(a => a.Gender)
                .Include(a => a.Language)
                .Include(a => a.PhotoIdType)
                .Include(a => a.Address).ThenInclude(a => a.Country)
                .FirstOrDefaultAsync(p => p.AppUserId == appUserId);
        }

        public async Task<Candidate?> DeleteCandidate(string appUserId)
        {
            // NOTE(vmavraganis): not working needs to delete candidateExams -> we have to make cascade on delete
            var candidate = await _context.Candidates
                .Include(a => a.Gender)
                .Include(a => a.Language)
                .Include(a => a.PhotoIdType)
                .Include(a => a.Address).ThenInclude(a => a.Country)
                .Include(a => a.CandidateExams)
                .FirstOrDefaultAsync(p => p.AppUserId == appUserId);
            if (candidate != null)
            {
                var candidateDeleted = _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();

                return candidateDeleted.Entity;
            }

            return null;
        }

        public async Task<Candidate?> AddCandidate(Candidate candidate)
        {
            var candidateEntity = await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();

            return candidateEntity.Entity;
        }

        public async Task<Candidate?> UpdateCandidate(string id, Candidate candidate)
        {
            var candidateToUpdate = await GetCandidate(id);

            if (candidateToUpdate != null)
            {
                candidateToUpdate.FirstName = candidate.FirstName;
                candidateToUpdate.MiddleName = candidate.MiddleName;
                candidateToUpdate.LastName = candidate.LastName;
                candidateToUpdate.DateOfBirth = candidate.DateOfBirth;
                candidateToUpdate.Email = candidate.Email;
                candidateToUpdate.Landline = candidate.Landline;
                candidateToUpdate.Mobile = candidate.Mobile;
                candidateToUpdate.PhotoIdNumber = candidate.PhotoIdNumber;
                candidateToUpdate.PhotoIdIssueDate = candidate.PhotoIdIssueDate;

                candidateToUpdate.Gender = candidate.Gender;
                candidateToUpdate.Language = candidate.Language;
                candidateToUpdate.PhotoIdType = candidate.PhotoIdType;
                candidateToUpdate.Address = candidate.Address;

                await _context.SaveChangesAsync();
            }

            return candidateToUpdate;
        }

        public bool CandidatesDbSetExists()
        {
            return _context.Candidates != null;
        }
    }
}
