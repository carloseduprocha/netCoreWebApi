using Contatos.Models;
using Contatos.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.AsNoTracking().ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public Contact Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public Contact Update(Contact contact)
        {
            var entity = _context.Contacts.Find(contact.Id);
            if (entity == null) return null;

            _context.Contacts.Entry(entity).CurrentValues.SetValues(contact);
            _context.SaveChanges();
            return contact;
        }

        public void Delete(int id)
        {
            var entity = _context.Contacts.Find(id);
            if (entity == null) return;

            _context.Contacts.Remove(entity);
            _context.SaveChanges();
        }
    }
}

