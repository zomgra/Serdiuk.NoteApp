using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Infrastructure.Persistance
{
    public class ApplicationDbContextFactory
    {
        #region statics
        public static string TitleA = "First title";
        public static string TitleB = "Second title";
        public static string TitleC = "Third title";

        public static string DescriptionA = "First Desc";
        public static string DescriptionB = "Second Desc";
        public static string DescriptionC = "Third Desc";

        public static Guid UserA = new Guid("9D9FC0AA-5A03-41E8-94A6-AC50FC291F51");
        public static Guid UserB = new Guid("180FE5BB-5C4D-4072-BE40-D93947FC7F29");
        public static Guid UserC = Guid.NewGuid();
        #endregion
        public static void Initialize(ApplicationDbContext context)
        {
            var notes = new List<Note>
            {
                new Note
                {
                    UserId = UserA,
                    Title = TitleA,
                    Details = DescriptionA,
                    CreateDate = DateTime.UtcNow,
                },
                new Note
                {
                    UserId = UserA,
                    IsEdited = true,
                    Title = TitleB,
                    Details = DescriptionB,
                    CreateDate = new DateTime(2023,04,23),
                    EditDate = DateTime.UtcNow,
                },
                new Note
                {
                    UserId = UserB,
                    Title = TitleC,
                    Details = DescriptionC,
                    CreateDate = new DateTime(2023,02,23),
                }
            };
            if (!context.Notes.Any())
            {
                context.AddRange(notes);
                context.SaveChanges();
            }
        }
    }
}
