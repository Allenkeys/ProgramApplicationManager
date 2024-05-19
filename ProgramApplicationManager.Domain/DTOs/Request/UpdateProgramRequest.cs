using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramApplicationManager.Domain.DTOs.Request
{
    public class UpdateProgramRequest
    {
        public string ProgramId { get; set; }
        public string EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<QuestionRequest> PersonalDetails { get; set; }
        public List<QuestionRequest> AdditionalQuestions { get; set; }
    }
}
