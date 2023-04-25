using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Notes.Create;
using Serdiuk.NoteApp.Infrastructure.Persistance;
using Serdiuk.NoteApp.Tests.Common;
using Xunit;

namespace Serdiuk.NoteApp.Tests.Notes.Command
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async void CreateNoteCommandHandler_Success()
        {
            // Arrange

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            
            var command = new CreateNoteCommand
            {
                Details = ApplicationDbContextFactory.DescriptionB,
                Title = ApplicationDbContextFactory.TitleB,
                UserId = ApplicationDbContextFactory.UserB,
            };

            var handler = new CreateNoteCommandHandler(context);

            // Act

            var result = await handler.Handle(command, CancellationToken.None);
            // Assert

            Assert.NotNull(context.Notes.FirstOrDefault(n=>n.Details == ApplicationDbContextFactory.DescriptionB));
;           Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Value);
        }
        [Fact]
        public async void CreateNoteCommandHandler_NoData_Failure()
        {
            var command = new CreateNoteCommand
            {
                UserId = ApplicationDbContextFactory.UserC,
            };
            var handler = new CreateNoteCommandHandler(Context);
            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsFailed);
        }
    }
}
