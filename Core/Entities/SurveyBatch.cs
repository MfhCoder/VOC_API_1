namespace Core.Entities;

public class SurveyBatch : BaseEntity
{
    public string Name { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public int ChannelId { get; set; }
    public Channel Channel { get; set; }
    public DateTime ScheduledTime { get; set; }
    public string Status { get; set; }
    public int MerchantCount { get; set; }
    public int CreatedBy { get; set; } 
    public User Creator { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<SurveyDelivery> SurveyDelivery { get; set; } 
}
