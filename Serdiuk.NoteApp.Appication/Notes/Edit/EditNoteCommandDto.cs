namespace Serdiuk.NoteApp.Appication.Notes.Edit
{
    public class EditNoteCommandDto
    {
        /// <summary>
        /// Identifier note
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
    }
}
