namespace Domain.Entities.Models.Person
{
    public class PersonFactory
    {
        public static Person CreatePerson(string? firstName, string? lastName, string? address, string? gender)
        {
            Person person = new Person();

            person.FirstName = firstName;
            person.LastName = lastName;
            person.Address = address;
            person.Gender = gender;

            return person;
        }
    }
}
