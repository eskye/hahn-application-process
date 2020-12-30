namespace Hahn.ApplicatonProcess.December2020.Domain.Entities
{
    public class Applicant : BaseEntity
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public int Age { get; private set; }
        public bool Hired { get; private set; }

        public Applicant(string name, string familyName, string address, string emailAddress, string countryOfOrigin, int age, bool hired)
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.Address = address;
            this.EmailAddress = emailAddress;
            this.CountryOfOrigin = countryOfOrigin;
            this.Age = age;
            this.Hired = hired;
        }

        public void UpdateDetails(string name, string familyName, string address, string emailAddress,
            string countryOfOrigin, int age, bool hired)
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.Address = address;
            this.EmailAddress = emailAddress;
            this.CountryOfOrigin = countryOfOrigin;
            this.Age = age;
            this.Hired = hired;
        }

    }
}
