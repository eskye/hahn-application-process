namespace Hahn.ApplicatonProcess.December2020.Domain.Interfaces
{
    using System.Threading.Tasks;
    using Entities;

    public interface IApplicantService
    {
        Task CreateApplicantAsync(Applicant applicant);
        Task DeleteApplicantAsync(int applicantId);
    }
}
