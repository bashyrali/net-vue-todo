using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}