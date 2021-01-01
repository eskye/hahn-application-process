namespace Hahn.ApplicatonProcess.December2020.Web.Validators
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using Services;
    using ViewModels;

    public class CreateApplicantModelValidator : AbstractValidator<ApplicantViewModel>
    {
        private readonly IValidateCountryName _validateCountryName;

        public CreateApplicantModelValidator(IValidateCountryName validateCountryName)
        {
            this._validateCountryName = validateCountryName;
            this.RuleFor(n => n.Name).NotEmpty().MinimumLength(5);
            this.RuleFor(n => n.FamilyName).NotEmpty().MinimumLength(5);
            this.RuleFor(n => n.Address).NotEmpty().MinimumLength(10);
            this.RuleFor(n => n.EmailAddress).NotEmpty().EmailAddress();
            this.RuleFor(n => n.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60);
            this.RuleFor(n => n.Hired).NotNull().NotEmpty();
            RuleFor(n => n.CountryOfOrigin).MustAsync(CheckIfCountryIsValid)
                .WithMessage("Country Name is not valid");

        }

        private async Task<bool> CheckIfCountryIsValid(string countryName, CancellationToken token)
        {
            return await this._validateCountryName.CheckIfCountryIsValid(countryName, token);
        }
    }
}
