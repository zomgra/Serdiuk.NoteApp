using FluentResults;
using MediatR;

namespace Serdiuk.NoteApp.Appication.Notes.Delete
{
    public class DeleteNoteCommand : IRequest<Result>
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Note identifier
        /// </summary>
        public int Id { get; set; }
    }
}
