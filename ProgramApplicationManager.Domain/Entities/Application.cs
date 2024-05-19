using System.ComponentModel.DataAnnotations;

namespace ProgramApplicationManager.Domain.Entities
{
    public class Application
    {
        [Key]
        public string ApplicationId { get; set; } = Guid.NewGuid().ToString();
        public string ProgramId { get; set; }
        public string CandidateId { get; set; }
        public List<Answer> PersonalInfoAnswers { get; set; }
        public List<Answer> AdditionalInfoAnswers { get; set; }
    }
}
