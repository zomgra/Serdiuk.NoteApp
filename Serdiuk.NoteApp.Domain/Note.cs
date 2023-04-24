using FluentResults;

namespace Serdiuk.NoteApp.Domain
{
    /// <summary>
    /// Note
    /// </summary>
    public class Note
    {
        #region .ctor
        /// <summary>
        /// Create new note with details, title and userId
        /// </summary>
        public Note(Guid userId, string title, string details)
        {
            UserId = userId;
            Title = title;
            Details = details;
            CreateDate = DateTime.UtcNow;
        }
        /// <summary>
        /// .Ctor for EF core
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="createDate"></param>
        /// <param name="editDate"></param>
        /// <param name="isEdited"></param>
        public Note(int id, Guid userId, string title, string details, DateTime createDate, DateTime? editDate, bool isEdited)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Details = details;
            CreateDate = createDate;
            EditDate = editDate;
        }
        /// <summary>
        /// .ctor
        /// </summary>
        public Note()
        {

        }
        #endregion
        /// <summary>
        /// Note identifier
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
        /// <summary>
        /// Date to create note
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Date to edit note
        /// </summary>
        public DateTime? EditDate { get; set; }
        /// <summary>
        /// Flag, is edit
        /// </summary>
        public bool IsEdited { get { return EditDate == default ? false : true; } }

        public Result<int> Edit(string? title, string? details)
        {
            Title = title;
            Details = details;
            EditDate = DateTime.UtcNow;
            return Result.Ok(Id);
        }
    }
}
