
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hakaton2.Models.Models;

namespace hakaton2.Models.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public int? MaxParticipants { get; set; }

        public int? CurrentParticipants { get; set; }

        public DateTime? CreatedOn { get; set; }

        
    }
}
