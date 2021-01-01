using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    public interface IApplicantService
    {
        Task<Applicant> CreateApplicantAsync(Applicant applicant);
        Task DeleteApplicantAsync(int applicantId);
        Task<Applicant> GetApplicantById(int applicantId);
        Task UpdateApplicantAsync(Applicant applicant);
    }
}
