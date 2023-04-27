using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Interfaces;

namespace Serdiuk.NoteApp.Appication.Notes.Delete
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public DeleteNoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

            if (note == null || note.UserId != request.UserId)
                return Result.Fail("Not not found or you dont have permissions");

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
