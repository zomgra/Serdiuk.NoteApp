namespace Serdiuk.NoteApp.Domain
{
    /// <summary>
    /// Note date transfer object
    /// </summary>
    public class NoteDto
    {
        /// <summary>
        /// Note identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Data of note
        /// </summary>
        public string Details { get; set; } = null!;
        /// <summary>
        /// View date note
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Date to create note
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Flag, is edit
        /// </summary>
        public bool IsEdit { get; set; }
    }
}
