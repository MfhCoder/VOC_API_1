namespace Core.Entities;

public class Survey : BaseEntity
{
    public string Name { get; set; }
    public int CreatedBy { get; set; }
    public User Creator { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<QuestionSection> QuestionSections { get; set; }
}
