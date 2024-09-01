using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtiqaContact.Application.DTOs;

public class ContactDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<string> Skillsets { get; set; }
    public List<string> Hobbies { get; set; }
}
