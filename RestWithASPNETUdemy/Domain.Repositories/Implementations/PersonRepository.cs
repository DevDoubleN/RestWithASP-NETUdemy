using Domain.Entities.Models.Person;
using Domain.Repositories.Interfaces;
using Infrastructure.Core.Context;

namespace Domain.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        #region Properties
        private readonly DataContext _context;
        #endregion

        #region Constructor
        public PersonRepository(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Members of IPersonRepository
        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public Person FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
