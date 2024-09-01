namespace EtiqaContact.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Skillsets { get; set; }
    public List<string> Hobbies { get; set; }
}
