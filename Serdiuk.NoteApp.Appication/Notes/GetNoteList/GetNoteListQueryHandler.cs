using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Containce;
using Serdiuk.NoteApp.Appication.Common.Interfaces;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Notes.GetNoteList
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, Result<IEnumerable<NoteDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<NoteDto>>> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notes = _context.Notes.AsNoTracking()
                .Where(n => n.UserId == request.UserId)
                .Skip(Pagination.PAGE_SIZE * (request.PageNumber - 1))
                .Take(Pagination.PAGE_SIZE);

            if (!notes.Any())
                return Result.Fail("No found any notes");

            var result = await notes.ProjectTo<NoteDto>(_mapper.ConfigurationProvider).ToListAsync();
            return result.ToResult<IEnumerable<NoteDto>>();
        }
    }
}
