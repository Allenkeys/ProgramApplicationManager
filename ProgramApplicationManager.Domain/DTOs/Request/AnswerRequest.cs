namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class AnswerRequest
    {
        public string QuestionId { get; set; }
        public string SingleAnswer { get; set; }
        public List<string> Multiplechoice { get; set; }
    }
}
