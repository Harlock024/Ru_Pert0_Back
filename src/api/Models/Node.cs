namespace ru_pert0_back.api.Models;

public class Node
{
    public long Id { get; set; }
    public long? ParentId { get; set; }    
    public Node Parent { get; set; } 
    public ICollection<Node> Children { get; set; }
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long TaskId { get; set; }
    public Task Task { get; set; }
}