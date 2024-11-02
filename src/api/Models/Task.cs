namespace ru_pert0_back.api.Models;

public class Task
{
    public long Id { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public double Duration { get; set; }
    public double Cost  { get; set; }
    
    
    public double OptimisticTime { get; set; }
    public double MostLikelyTime { get; set; }
    public double PessimisticTime { get; set; }

    public double CaculatePERT()
    {
        return (OptimisticTime + 4 * MostLikelyTime +  PessimisticTime )/ 6;
    }
}