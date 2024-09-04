using AutoMapper;
using EtiqaContact.Application.DTOs;
using EtiqaContact.Application.Mappings;
using EtiqaContact.Domain.Entities;
using EtiqaContact.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace EtiqaContact.Application.Services.Tests;

[TestClass()]
public class ContactServiceTests
{
    private Mock<IContactRepository> _contactRepositoryMock;
    private Mapper _mapper;
    private ContactService _contactService;

    [TestInitialize]
    public void Initialize()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new ContactMappingProfile())));
        _contactService = new ContactService(_contactRepositoryMock.Object, _mapper);
    }

    [TestMethod()]
    public async Task GetByIdAsync_ShouldReturnContactDto_WhenContactExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var contact = new Contact
        {
            Id = id,
            Username = "John Doe",
            Email = "4kDkK@example.com",
            PhoneNumber = "1234567890",
            Hobbies = new List<string> { "Reading", "Traveling" },
            Skillsets = new List<string> { "Java", "C#" },
        };
        var contactDto = new ContactDto
        {
            Id = contact.Id,
            Username = contact.Username,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Hobbies = contact.Hobbies,
            Skillsets = contact.Skillsets
        };

        _contactRepositoryMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(contact);

        // Act
        var result = await _contactService.GetByIdAsync(id);

        // Assert
        Assert.IsNotNull(result);
        result.Should().BeEquivalentTo(contactDto);
    }
}