using Swashbuckle.AspNetCore.Filters;
using Hahn.ApplicatonProcess.December2020.Web.ViewModels;

namespace Hahn.ApplicatonProcess.December2020.Web.SwaggerRequestExample
{
    public class ApplicantModelExample : IExamplesProvider<ApplicantViewModel>
    {
        public ApplicantViewModel GetExamples() => new ApplicantViewModel
        {
            FamilyName = "Jackson",
            Name = "Jackson Johnson",
            Address = "1 Gwalior Road",
            EmailAddress = "jacksonjohnson@gmail.com",
            CountryOfOrigin = "Germany",
            Age = 20,
            Hired = true
        };
    }
}
