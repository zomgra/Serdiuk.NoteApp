using AutoMapper;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Common.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping()
        {
            CreateMap<Note, NoteDto>()
                .ForMember(d => d.Id, o => o.MapFrom(n => n.Id))
                .ForMember(d => d.CreateDate, o => o.MapFrom(n => n.CreateDate))
                .ForMember(d => d.DateTime, o => o.MapFrom(n => n.IsEdited ? n.EditDate : n.CreateDate))
                .ForMember(d => d.IsEdit, o => o.MapFrom(n => n.IsEdited))
                .ForMember(d => d.Title, o => o.MapFrom(n => n.Title))
                .ForMember(d => d.Details, o => o.MapFrom(n => n.Details));
        }
    }
}
