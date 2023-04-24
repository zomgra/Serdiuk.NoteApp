using FluentResults;
using MediatR;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Notes.GetNoteList
{
    public class GetNoteListQuery : IRequest<Result<IEnumerable<NoteDto>>>
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// For pafination
        /// </summary>
        public int PageNumber { get; set; }
    }
}
