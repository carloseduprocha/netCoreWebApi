using Contatos.Data.Repositories;
using Contatos.DTOs;
using Contatos.Models;
using Contatos.Models.Interfaces;

namespace Contatos.Services
{
    public class ContactService : IContactServices
    {
        public readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public List<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        public ContactDto Create(ContactDto contact)
        {

            var contactDto = ToDto(_repository.Create(ToEntity(contact)));
            return contactDto;
        }

        public ContactDto GetById(int id)
        {
            if (id <= 0)
                return new ContactDto();

            var contact = _repository.GetById(id);

            return ToDto(contact);
        }

        public ContactDto Update(int id, ContactDto contact)
        {
            if (id != contact.Id)
                return null;

            var result = GetById(id);

            if(result != null)
                _repository.Update(ToEntity(contact));

            return result;
        }

        public ContactDto Delete(int id)
        {
            var contact = GetById(id);

            if (contact != null)
                _repository.Delete(id);

            return contact;
        }


        private ContactDto ToDto(Contact contact)
        {
            if (contact == null)
                return null;

            return new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.Phone
            };
        }


        private List<ContactDto> ToDtoList(List<Contact> contacts)
        {
            if (contacts == null)
                return new List<ContactDto>();

            return contacts.Select(ToDto).ToList();
        }


        private Contact ToEntity(ContactDto dto)
        {
            if (dto == null)
                return null;

            return new Contact
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };
        }

    }
}
