namespace ru_pert0_back.api.Models;

public class Project
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public  string? Description { get; set; }
    public long UserId { get; set; }
    public  User User { get; set; }
    public  ICollection<Node> Nodes { get; set; } 
} 