namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class CreateProgramRequest
    {
        public string EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<QuestionRequest> PersonalDetails { get; set; }
        public List<QuestionRequest> AdditionalQuestions { get; set; }
    }
}
