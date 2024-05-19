namespace ProgramApplicationManager.Domain.Entities
{
    public class Question
    {
        public string QuestionId { get; set; } = Guid.NewGuid().ToString();
        public string ProgramId { get; set; }
        public string Text {  get; set; }
        public string Type { get; set; }
        public List<string> Options { get; set; }
    }
}
