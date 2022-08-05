using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.Domain.DTOs
{
    public class FetchNoteDto 
    {
        public Guid NoteId { get; set; }
        public Guid? CreatorUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GroupName GroupName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
