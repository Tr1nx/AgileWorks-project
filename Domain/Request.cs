using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Request
{
    [Key]
    public Guid Id { get; set; }

    public string Description { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime Deadline { get; set; }
    
    public bool Resolved { get; set; }
    
}