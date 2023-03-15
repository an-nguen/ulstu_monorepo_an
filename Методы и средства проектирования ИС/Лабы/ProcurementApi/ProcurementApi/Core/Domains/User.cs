using System.ComponentModel.DataAnnotations;

namespace ProcurementApi.Core.Domains;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}