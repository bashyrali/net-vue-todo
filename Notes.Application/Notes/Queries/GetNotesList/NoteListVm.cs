using System.Collections.Generic;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NoteListVm
    {
        public IList<NoteLookUpDto> Notes { get; set; }
        
    }
}