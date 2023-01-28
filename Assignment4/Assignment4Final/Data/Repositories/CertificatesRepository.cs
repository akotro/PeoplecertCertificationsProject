using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models.Certificates;

namespace Assignment4Final.Data.Repositories;

public class CertificatesRepository : ICertificatesRepository
{
    private readonly ApplicationDbContext _context;

    public CertificatesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Certificate>> GetAllAsync()
    {
        return await _context.Certificates
            .Include(c => c.Topics)
            .Include(c => c.Exams)
            .ToListAsync();
    }

    public async Task<Certificate?> GetAsync(int? id, bool include = true)
    {
        if (!include)
        {
            return await _context.Certificates.FirstOrDefaultAsync(q => q.Id == id);
        }

        return await _context.Certificates
            .Include(q => q.Topics)
            .Include(q => q.Exams)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Certificate?> AddAsync(Certificate certificate)
    {
        var certificateEntry = await _context.Certificates.AddAsync(certificate);
        await _context.SaveChangesAsync();

        return certificateEntry.Entity;
    }

    public async Task<Certificate?> UpdateAsync(int id, Certificate certificate)
    {
        var dbCertificate = await GetAsync(id);

        if (dbCertificate != null)
        {
            dbCertificate = certificate;

            await _context.SaveChangesAsync();
        }

        return dbCertificate;
    }

    public async Task<Certificate?> Delete(int id)
    {
        var certificate = await _context.Certificates.FindAsync(id);
        if (certificate != null)
        {
            var certificateEntry = _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync();

            return certificateEntry.Entity;
        }

        return null;
    }

    public bool CertificatesDbSetExists()
    {
        return _context.Certificates != null;
    }

    public bool CertificateExists(int id)
    {
        return (_context.Certificates?.Any(c => c.Id == id)).GetValueOrDefault();
    }
}
