using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Infrastructure.Persistance
{
    public class ApplicationDbContextFactory
    {
        #region statics
        public static readonly string TitleA = "First title";
        public static readonly string TitleB = "Second title";
        public static readonly string TitleC = "Third title";

        public static readonly string DescriptionA = "First Desc";
        public static readonly string DescriptionB = "Second Desc";
        public static readonly string DescriptionC = "Third Desc";

        public static readonly Guid UserA = new("9D9FC0AA-5A03-41E8-94A6-AC50FC291F51");
        public static readonly Guid UserB = new("180FE5BB-5C4D-4072-BE40-D93947FC7F29");
        public static readonly Guid UserC = Guid.NewGuid();
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
