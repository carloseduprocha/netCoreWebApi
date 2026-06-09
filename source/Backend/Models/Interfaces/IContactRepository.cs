namespace Contatos.Models.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact contact);
        Contact Update(Contact contact);
        void Delete(int id);
    }
}
