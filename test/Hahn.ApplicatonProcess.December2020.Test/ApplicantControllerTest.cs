using System;
using Xunit;

namespace Hahn.ApplicatonProcess.December2020.Test
{
    using System.Threading.Tasks;
    using Domain.Entities;
    using Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Web.Controllers;
    using Web.ViewModels;

    public class ApplicantControllerTest
    {
        [Fact]
        public async Task Create_Applicant_ReturnCreated_If_Successful()
        {
            //Arrange
            var applicantServiceMock = new Mock<IApplicantService>();
            var loggerMock = new Mock<ILogger<ApplicantController>>();

            var sut = new ApplicantController(loggerMock.Object, applicantServiceMock.Object);
            var applicant = new Applicant("", "", "", "", "", 0, false);

            applicantServiceMock.Setup(a => a.CreateApplicantAsync(It.IsAny<Applicant>()))
                .Returns(Task.FromResult(applicant));

            //Act

            var result = await sut.CreateApplicantAsync(new ApplicantViewModel
            {
                FamilyName = "TestFamily",
                Address = "TestAddres",
                Age = 30,
                CountryOfOrigin = "Nigeria",
                EmailAddress = "test@gmail.com",
                Hired = true,
                Name = "Test Name"
            });

            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
        }

        [Fact]
        public async Task Get_ReturnsApplicant_If_ApplicantIdIsFound()
        {
            //Arrange 
            var applicantServiceMock = new Mock<IApplicantService>();
            var loggerMock = new Mock<ILogger<ApplicantController>>();

            var sut = new ApplicantController(loggerMock.Object, applicantServiceMock.Object);
            var applicant = new Applicant("", "", "", "", "", 0, false);

            applicantServiceMock.Setup(c => c.GetApplicantById(It.IsAny<int>()))
                .Returns(Task.FromResult(applicant));

            //Act
            var result = await sut.GetApplicant(1);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);

        }

        [Fact]
        public async Task Update_ReturnsUpdated_If_successful()
        {
            //Arrange 
            var applicantServiceMock = new Mock<IApplicantService>();
            var loggerMock = new Mock<ILogger<ApplicantController>>();

            var sut = new ApplicantController(loggerMock.Object, applicantServiceMock.Object);
            var applicantViewModel = new ApplicantViewModel
            {
                FamilyName = "TestFamily",
                Address = "TestAddres",
                Age = 30,
                CountryOfOrigin = "Nigeria",
                EmailAddress = "test@gmail.com",
                Hired = true,
                Name = "Test Name"
            };

            var applicant = new Applicant("", "", "", "", "", 0, false);

            applicantServiceMock.Setup(c => c.GetApplicantById(It.IsAny<int>()))
                .Returns(Task.FromResult(applicant));

            applicantServiceMock.Setup(a => a.UpdateApplicantAsync(applicant))
                .Returns(Task.FromResult(applicant));
            //Act
            var result = await sut.EditApplicant(applicantViewModel, 1);

            Assert.NotNull(result);
            var response = Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(response.Value, $"Applicant Record Updated Successfully");

        }

        [Fact]
        public async Task Delete_ReturnsDeleted_If_successful()
        {
            //Arrange 
            var applicantServiceMock = new Mock<IApplicantService>();
            var loggerMock = new Mock<ILogger<ApplicantController>>();

            var sut = new ApplicantController(loggerMock.Object, applicantServiceMock.Object);

            applicantServiceMock.Setup(c => c.DeleteApplicantAsync(It.IsAny<int>()))
                .Returns(Task.CompletedTask);
            //Act
            var result = await sut.DeleteApplicant(1);

            Assert.NotNull(result);
            var response = Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.Equal(response.Value, $"Applicant Deleted Successfully");

        }
    }
}
