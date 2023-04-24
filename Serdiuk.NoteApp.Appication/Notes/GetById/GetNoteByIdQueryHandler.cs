using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Interfaces;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Notes.GetById
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Result<NoteDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<NoteDto>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (note == null || note.UserId == request.UserId)
                return Result.Fail("Not not found or you dont have permissions");

            return _mapper.Map<NoteDto>(note).ToResult();
        }
    }
}
