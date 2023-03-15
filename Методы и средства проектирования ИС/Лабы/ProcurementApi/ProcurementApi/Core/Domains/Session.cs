using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace ProcurementApi.Core.Domains;

public class Session
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ZonedDateTime CreatedAt { get; set; }
    public int Lifetime { get; set; }
}