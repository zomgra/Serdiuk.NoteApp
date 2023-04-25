using Serdiuk.NoteApp.Appication.Notes.Edit;
using Serdiuk.NoteApp.Infrastructure.Persistance;
using Serdiuk.NoteApp.Tests.Common;
using Xunit;

namespace Serdiuk.NoteApp.Tests.Notes.Command
{
    public class EditNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task EditNoteCommandHandler_ChangeOnlyDetails_Success()
        {
            // A

            var command = new EditNoteCommand
            {
                Details = ApplicationDbContextFactory.DescriptionB,
                UserId = ApplicationDbContextFactory.UserA,
                Id = 1,
            };
            var handler = new EditNoteCommandHandler(Context);

            // A

            var result = await handler.Handle(command, CancellationToken.None);

            // A

            var note = Context.Notes.FirstOrDefault(n => n.Id == 1);
            Assert.True(result.IsSuccess);

            Assert.True(note.IsEdited);
            Assert.Equal(ApplicationDbContextFactory.DescriptionB, note?.Details);
        }

        [Fact]
        public async Task EditNoteCommandHandler_ChangeAllData_Success()
        {
            // A

            var command = new EditNoteCommand
            {
                Details = ApplicationDbContextFactory.DescriptionA,
                Title = ApplicationDbContextFactory.TitleA,
                UserId = ApplicationDbContextFactory.UserB,
                Id = 2,
            };
            var handler = new EditNoteCommandHandler(Context);

            // A

            var result = await handler.Handle(command, CancellationToken.None);

            // A

            var note = Context.Notes.FirstOrDefault(n => n.Id == 2);

            Assert.True(result.IsSuccess);
            Assert.True(note.IsEdited);
            Assert.Equal(ApplicationDbContextFactory.TitleA, note?.Title);
            Assert.Equal(ApplicationDbContextFactory.DescriptionA, note?.Details);
            Assert.True(note.CreateDate < note?.EditDate);
        }


        [Fact]
        public async Task EditNoteCommandHandler_ChangeEmptyData_Failure()
        {
            // A

            var command = new EditNoteCommand
            {
                UserId = ApplicationDbContextFactory.UserB,
                Id = 3,
            };
            var handler = new EditNoteCommandHandler(Context);

            // A

            var result = await handler.Handle(command, CancellationToken.None);

            // A

            var note = Context.Notes.FirstOrDefault(n => n.Id == 1);

            Assert.True(result.IsFailed);
        }
        [Fact]
        public async Task EditNoteCommandHandler_UserIdError_FailureAsync()
        {
            // A

            var command = new EditNoteCommand
            {
                Details = ApplicationDbContextFactory.DescriptionB,
                Title = ApplicationDbContextFactory.TitleC,
                UserId = ApplicationDbContextFactory.UserB,
                Id = 1,
            };
            var handler = new EditNoteCommandHandler(Context);

            // A

            var result = await handler.Handle(command, CancellationToken.None);

            // A

            var note = Context.Notes.FirstOrDefault(n => n.Id == 1);
            Assert.True(result.IsFailed);
            Assert.Equal(note.Title, ApplicationDbContextFactory.TitleA);
            Assert.Equal(note.Details, ApplicationDbContextFactory.DescriptionA);
        }
    }
}
