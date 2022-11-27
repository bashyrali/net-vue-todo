using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery: IRequest<NoteDetailsVm>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        
    }
    
}