using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Web.SwaggerRequestExample;
using Swashbuckle.AspNetCore.Filters;
using Hahn.ApplicatonProcess.December2020.Web.ViewModels;


namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{ 
    public class ApplicantController : BaseApiController
    {
        private readonly ILogger<ApplicantController> _logger;
        private readonly IApplicantService _applicantService;

        public ApplicantController(ILogger<ApplicantController> logger, IApplicantService applicantService )
        {
            _logger = logger;
            _applicantService = applicantService;
        }


        [HttpPost]
        [SwaggerRequestExample(typeof(ApplicantViewModel), typeof(ApplicantModelExample))]
        public async Task<IActionResult> CreateApplicantAsync([FromBody] ApplicantViewModel model)
        {
            var applicant = new Applicant(model.Name, model.FamilyName, model.Address, model.EmailAddress,
                model.CountryOfOrigin, model.Age, model.Hired);
            var applicantEntity = await _applicantService.CreateApplicantAsync(applicant);
            return new CreatedAtRouteResult("GetApplicant", new { id = applicantEntity.Id }, model);
        }
        /// <param name="id" example="1">The applicant id</param>
        [HttpGet("{id:int}", Name = "GetApplicant")]
        public async Task<IActionResult> GetApplicant(int id)
        {
            var applicant = await _applicantService.GetApplicantById(id);
            return Ok(applicant);
        }

        /// <param name="id" example="1">The applicant id</param>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            await _applicantService.DeleteApplicantAsync(id);
            return Ok(new {Message = "Applicant Deleted Successfully"});
        }

        /// <param name="id" example="1">The applicant id</param>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditApplicant([FromBody] ApplicantViewModel model, int id)
        {
            var applicant = await _applicantService.GetApplicantById(id); 
            applicant.UpdateDetails(model.Name, model.FamilyName, model.Address, model.EmailAddress, model.CountryOfOrigin, model.Age, model.Hired);
            await _applicantService.UpdateApplicantAsync(applicant);
            return Ok(new { Message = "Applicant Record Updated Successfully" });
        }


    }
}
