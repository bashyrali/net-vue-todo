namespace Notes.WebAPI.Models
{
    public class UpdateNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}