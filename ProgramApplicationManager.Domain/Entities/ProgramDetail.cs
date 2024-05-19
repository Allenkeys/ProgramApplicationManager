using System.ComponentModel.DataAnnotations;

namespace ProgramApplicationManager.Domain.Entities
{
    public class ProgramDetail
    {
        [Key]
        public string ProgramId { get; set; } = Guid.NewGuid().ToString();
        public string EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Question> PersonalInfo { get; set; }
        public List<Question> AdditionalInfo { get; set; }
    }
}
