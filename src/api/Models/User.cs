namespace ru_pert0_back.api.Models;

public class User 
{
   

    public  long Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
   
    public ICollection<Project> Projects { get; set; }
    
}
