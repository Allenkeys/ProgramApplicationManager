namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class CreateApplicationRequest
    {
        public string ProgramId { get; set; }
        public List<AnswerRequest> PersonalInfoAnswers { get; set; }
        public List<AnswerRequest> AdditionalInfoAnswers { get; set; }
    }
}
