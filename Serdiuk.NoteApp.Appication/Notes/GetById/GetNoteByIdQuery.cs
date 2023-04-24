using FluentResults;
using MediatR;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Notes.GetById
{
    public class GetNoteByIdQuery : IRequest<Result<NoteDto>>
    {
        /// <summary>
        /// Note identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
    }
}
