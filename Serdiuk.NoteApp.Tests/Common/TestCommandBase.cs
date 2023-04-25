using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Mapping;
using Serdiuk.NoteApp.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serdiuk.NoteApp.Tests.Common
{
    public class TestCommandBase
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;
        public TestCommandBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            Context = ApplicationDbContextFactory.Initialize(context);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationMapper>());
            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            ApplicationDbContextFactory.Destroy(Context);
        }
    }
}
