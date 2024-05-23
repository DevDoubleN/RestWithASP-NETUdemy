using Domain.Entities.Models.Person;
using Infrastructure.Core.Context;
using Infrastructure.Core.Exceptions;
using Infrastructure.Repositories.Interfaces;
using System;

namespace Infrastructure.Repositories.Implementations
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
        public List<Person> FindAll()
        {
            return _context.Person.ToList();
        }

        public Person FindById(long id)
        {
            var person = _context.Person.SingleOrDefault(p => p.Id == id);

            if (person == null) throw new NotFoundException("Person not found");

            return person;
        }

        public Person Create(Person person)
        {
            if (person == null) throw new ArgumentNullException("Object can't empty");

            _context.Person.Add(person);
            _context.SaveChanges();

            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Person.SingleOrDefault(p => p.Id == id);

            if (person == null) throw new NotFoundException("Person not found");

            _context.Person.Remove(person);
            _context.SaveChanges();
        }

        public Person Update(Person person)
        {
            if (person == null) throw new ArgumentNullException("Object can't empty");

            var entity = _context.Person.SingleOrDefault(p => p.Id == person.Id);
            if (entity == null) throw new NotFoundException("Person not found");

            _context.Entry(entity).CurrentValues.SetValues(person);
            _context.SaveChanges();

            return entity;
        }
        #endregion
    }
}
