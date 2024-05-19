namespace ProgramApplicationManager.Domain.Entities
{
    public class Answer
    {
        public string QuestionId { get; set; }
        public string SingleAnswer { get; set; }
        public List<string> Multiplechoice { get; set; }
    }
}
