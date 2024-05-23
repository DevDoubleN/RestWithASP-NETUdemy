using Application.DTOs.Input.Person;
using Application.DTOs.Output.Person;

namespace Application.Services.Interfaces
{
    public interface IPersonService
    {
        List<PersonOutputDTO> FindAll();
        PersonOutputDTO FindById(long id);
        PersonOutputDTO Create(PersonInsertDTO person);
        PersonOutputDTO Update(PersonUpdateDTO person);
        void Delete(long id);
    }
}
