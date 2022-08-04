namespace CCSANoteApp.Domain
{
    public class NoteDto
    {
        public Guid creatorUserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GroupName GroupName { get; set; }
    }
}
