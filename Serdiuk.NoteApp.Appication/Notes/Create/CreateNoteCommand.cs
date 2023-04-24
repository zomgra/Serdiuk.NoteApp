using FluentResults;
using MediatR;

namespace Serdiuk.NoteApp.Appication.Notes.Create
{
    /// <summary>
    /// Command to create note
    /// </summary>
    public class CreateNoteCommand : IRequest <Result<int>>
    {
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
