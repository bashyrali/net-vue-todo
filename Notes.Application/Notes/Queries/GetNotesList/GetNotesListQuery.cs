using System.Collections.Generic;
using MediatR;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class GetNotesListQuery: IRequest<List<NoteLookUpDto>>
    {
        public int UserId { get; set; }
    }
}