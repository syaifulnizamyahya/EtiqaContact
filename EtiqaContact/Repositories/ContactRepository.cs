using EtiqaContact.Models;

namespace EtiqaContact.Repositories;

public class ContactRepository
{
    private readonly List<Contact> _contacts = [];

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }

    public Contact? GetContactById(Guid id)
    {
        return _contacts.Find(c => c.Id == id);
    }

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        var existingContact = GetContactById(contact.Id);
        if (existingContact != null)
        {
            existingContact.Username = contact.Username;
            existingContact.Mail = contact.Mail;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Skillsets = contact.Skillsets;
            existingContact.Hobby = contact.Hobby;
        }
    }

    public void DeleteContact(Guid id)
    {
        var contact = GetContactById(id);
        if (contact != null)
        {
            _contacts.Remove(contact);
        }
    }
}
