using Application.DTOs.Input.Person;
using Application.DTOs.Output.Person;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities.Models.Person;
using Infrastructure.Core.Exceptions;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations
{
    public class PersonService : IPersonService
    {
        #region Properties
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Members of IPersonService
        public List<PersonOutputDTO> FindAll()
        {
            return _mapper.Map<List<PersonOutputDTO>>(_repository.FindAll());
        }

        public PersonOutputDTO FindById(long id)
        {
            try
            {
                if (id <= 0)
                    throw new NotFoundException("The input value identifier can't be smaller than zero");

                return _mapper.Map<PersonOutputDTO>(_repository.FindById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PersonOutputDTO Create(PersonInsertDTO person)
        {
            try
            {
                if (person == null) throw new ArgumentNullException("Object can't empty");

                _repository.Create(PersonFactory.CreatePerson(person.FirstName, person.LastName, person.Address, person.Gender));

                return _mapper.Map<PersonInsertDTO, PersonOutputDTO>(person);
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException($"Concurrency exception! {ex.Message}");
            }
        }

        public PersonOutputDTO Update(PersonUpdateDTO personDTO)
        {
            try
            {
                if (personDTO == null) throw new ArgumentNullException("Object can't empty");

                var person = _repository.Update(_mapper.Map<PersonUpdateDTO, Person>(personDTO));

                return _mapper.Map<Person, PersonOutputDTO>(person);
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException($"Concurrency exception! {ex.Message}");
            }
        }

        public void Delete(long id)
        {
            try
            {
                if (id <= 0)
                    throw new NotFoundException("The input value identifier can't be smaller than zero");

                _repository.Delete(id);
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException($"Concurrency exception! {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException($"Integrity exception! {ex.Message}");
            }
        }
        #endregion
    }
}
