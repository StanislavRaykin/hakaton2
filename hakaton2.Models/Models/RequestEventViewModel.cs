using System.Collections.Specialized;
using System.Data;

namespace hakaton2.Models
{
    public class RequestEventViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; } = string.Empty;
        public int? CurrentParticipants { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Creator { get; set; }

    }
}
