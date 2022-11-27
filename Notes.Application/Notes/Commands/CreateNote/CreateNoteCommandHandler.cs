using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly INotesDbContext _db;

        public CreateNoteCommandHandler(INotesDbContext db)
        {
            _db = db;
        }

       

        public async Task<int> Handle(CreateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                CreationDate = DateTime.Now,
                Title = request.Title,
                Details = request.Details,
                EditDate = null
            };
            await _db.Notes.AddAsync(note, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}