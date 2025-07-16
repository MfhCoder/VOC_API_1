namespace Core.Entities;

public class SurveyQuestion : BaseEntity
{
    public int SurveyId { get; set; } 
    public Survey Survey { get; set; }
    public string QuestionText { get; set; }
    public int QuestionOrder { get; set; }
    public bool IsRequired { get; set; }
    public int QuestionTypeId { get; set; }
    public QuestionType QuestionType { get; set; }
    public ICollection<QuestionOption> Options { get; set; }
    public ICollection<QuestionBranch> ChildBranches { get; set; }
    public ICollection<FeedbackAnswer> Answers { get; set; }
}
