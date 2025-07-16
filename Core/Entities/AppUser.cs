using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
    public UserStatus Status { get; set; } = UserStatus.Pending;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public ICollection<Survey> SurveysCreated { get; set; }
    public ICollection<SurveyBatch> SurveyBatchesCreated { get; set; }
    public ICollection<Feedback> FeedbacksSubmitted { get; set; }
}

public enum UserStatus
{
    Active,
    Inactive,
    Pending,
    Deactivated
}