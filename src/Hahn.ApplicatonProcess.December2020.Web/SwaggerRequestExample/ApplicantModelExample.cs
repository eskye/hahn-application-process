namespace Hahn.ApplicatonProcess.December2020.Web.SwaggerRequestExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Swashbuckle.AspNetCore.Filters;
    using ViewModels;

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
