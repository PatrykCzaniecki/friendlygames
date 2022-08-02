namespace FriendlyGames.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public int PhoneNumber { get; set; }
    public string Country { get; set; }
}