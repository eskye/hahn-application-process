using System;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Domain.Services
{

    public class ApplicantService : IApplicantService
    {
        private readonly IAsyncRepository<Applicant> _applicantRepository;

        public ApplicantService(IAsyncRepository<Applicant> applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<Applicant> CreateApplicantAsync(Applicant applicant)
        {
            var newApplicant = new Applicant(applicant.Name, applicant.FamilyName, applicant.Address, applicant.EmailAddress, applicant.CountryOfOrigin, applicant.Age, applicant.Hired);
            var newCreatedApplicant = await _applicantRepository.AddAsync(newApplicant);
            return newCreatedApplicant;
        }

        public async Task DeleteApplicantAsync(int applicantId)
        {
            var applicant = await this._applicantRepository.GetByIdAsync(id: applicantId);
            if (applicant == null)
                throw new ApplicationException($"Unable to load Applicant with ID '{applicantId}'.");
            await _applicantRepository.DeleteAsync(applicant);

        }

        public async Task<Applicant> GetApplicantById(int applicantId)
        {
            var applicant = await _applicantRepository.GetByIdAsync(applicantId);
            if (applicant == null)
                throw new ApplicationException($"Unable to load Applicant with ID '{applicantId}'.");
            return applicant;
        }

        public async Task UpdateApplicantAsync(Applicant applicant)
        {
            await _applicantRepository.UpdateAsync(applicant);
             
        }
    }
}
