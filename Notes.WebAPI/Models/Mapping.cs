using AutoMapper;
using Notes.Application.Notes.Commands;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebAPI.Models
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<CreateNoteDto, CreateNoteCommand>().ReverseMap();
            CreateMap<UpdateNoteDto, UpdateNoteCommand>().ReverseMap();
        }
    }
}