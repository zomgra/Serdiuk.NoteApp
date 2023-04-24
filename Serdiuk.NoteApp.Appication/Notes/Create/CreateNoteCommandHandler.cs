using FluentResults;
using MediatR;
using Serdiuk.NoteApp.Appication.Common.Interfaces;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Notes.Create
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateNoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note(request.UserId, request.Title, request.Details);

            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
