using System.ComponentModel.DataAnnotations;

namespace EtiqaContact.Models;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(255)]
    public string Username { get; set; }

    public string Mail { get; set; }

    public string PhoneNumber { get; set; }

    public List<string> Skillsets { get; set; }

    public List<string> Hobby { get; set; }
}
