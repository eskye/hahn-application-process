namespace Hahn.ApplicatonProcess.December2020.Data.Config
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.FamilyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.EmailAddress)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Address)
                .HasMaxLength(200)
                .IsRequired();


        }
    }
}
