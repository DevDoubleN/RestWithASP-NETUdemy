using Domain.Entities.Models.Person;

namespace Domain.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
