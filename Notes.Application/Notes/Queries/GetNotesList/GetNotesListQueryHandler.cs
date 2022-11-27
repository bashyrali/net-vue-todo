using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Notes.Queries.GetNoteDetails;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class GetNotesListQueryHandler: IRequestHandler<GetNotesListQuery, List<NoteLookUpDto>>
    {
        private readonly INotesDbContext _db;
        private readonly IMapper _mapper;

        public GetNotesListQueryHandler(INotesDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<NoteLookUpDto>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            
                var notesQuery = await _db.Notes
                    .Where(note => note.UserId == request.UserId)
                    .ToListAsync(cancellationToken);
                
                return _mapper.Map<List<NoteLookUpDto>>(notesQuery);
        }
    }
}