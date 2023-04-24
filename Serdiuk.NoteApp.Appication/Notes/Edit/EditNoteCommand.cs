using FluentResults;
using MediatR;

namespace Serdiuk.NoteApp.Appication.Notes.Edit
{
    public class EditNoteCommand : IRequest<Result<int>>
    {
        /// <summary>
        /// Identifier note
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identifier user
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Data of note
        /// </summary>
        public string Details { get; set; } = null!;

    }
}
