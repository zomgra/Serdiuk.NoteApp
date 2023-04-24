namespace Serdiuk.NoteApp.Appication.Notes.Create
{
    public class CreateNoteCommandDto
    {
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
