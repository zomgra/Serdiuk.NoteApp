using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Interfaces;

namespace Serdiuk.NoteApp.Appication.Notes.Edit
{
    public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public EditNoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(EditNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n=>n.Id == request.Id, cancellationToken);

            if (note == null || note.UserId != request.UserId)
                return Result.Fail("Not not found or you dont have permissions");

            var result = note.Edit(request.Title, request.Details);

            if (result.IsSuccess)
                await _context.SaveChangesAsync(cancellationToken);
            
            return result;
        }
    }
}
