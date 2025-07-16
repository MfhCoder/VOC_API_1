namespace Core.Entities;

public class Feedback : BaseEntity
{
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public int? DeliveryId { get; set; }
    public SurveyDelivery Delivery { get; set; }
    public int? MerchantId { get; set; }
    public Merchant Merchant { get; set; }
    public DateTime SubmittedAt { get; set; }
    public int? SubmittedBy { get; set; } 
    public User Submitter { get; set; }
    public ICollection<FeedbackAnswer> Answers { get; set; }
    public ICollection<FeedbackTag> FeedbackTags { get; set; }
}
