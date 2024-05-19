using ProgramApplicationManager.Domain.Enums;

namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class QuestionRequest
    {
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
    }
}
