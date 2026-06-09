using Contatos.DTOs;
using Contatos.Models;

namespace Contatos.Services
{
    public interface IContactServices
    {
        ContactDto Create(ContactDto contact);
        ContactDto Delete(int id);
        List<Contact> GetAll();
        ContactDto GetById(int id);
        ContactDto Update(int id, ContactDto contact);
    }
}
