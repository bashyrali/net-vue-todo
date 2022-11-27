using AutoMapper;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNotesList;
using Notes.Domain;

namespace Notes.Application.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteDetailsVm>().ReverseMap();
            CreateMap<Note, NoteLookUpDto>().ReverseMap();
            CreateMap<Note, CreateNoteCommand>().ReverseMap();
        }
    }
}