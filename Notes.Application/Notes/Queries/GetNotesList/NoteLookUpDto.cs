using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NoteLookUpDto 
    {
        public int Id { get; set; } 
        public string Title { get; set; }

       
    }
}