namespace Hahn.ApplicatonProcess.December2020.Domain.Validators
{
    using Entities;
    using FluentValidation;

    public class CreateApplicantValidator : AbstractValidator<Applicant>
    {
        public CreateApplicantValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MinimumLength(5);
            RuleFor(n => n.FamilyName).NotEmpty().MinimumLength(5);
            RuleFor(n => n.Address).NotEmpty().MinimumLength(10);
            RuleFor(n => n.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(n => n.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60);
            RuleFor(n => n.Hired).NotNull().NotEmpty();

        }
    }
}
