using ModelLibrary.Models.Certificates;

namespace Assignment4Final.Data.Repositories;

public interface ICertificatesRepository
{
    Task<List<Certificate>> GetAllAsync();
    Task<Certificate?> GetAsync(int? id, bool include = true);
    Task<Certificate?> AddAsync(Certificate certificate);
    Task<Certificate?> UpdateAsync(int id, Certificate certificate);
    Task<Certificate?> Delete(int id);
    bool CertificatesDbSetExists();
    bool CertificateExists(int id);
}