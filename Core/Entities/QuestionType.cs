namespace Core.Entities;

public class QuestionType : BaseEntity
{
    public string Name { get; set; }
    public ICollection<SurveyQuestion> Questions { get; set; }
}
