using AutoMapper;
using ToDoApi.Core.ToDoDtosProfiles.Dtos;
using ToDoApi.Domain.Entities;

namespace ToDoApi.Core.ToDoDtosProfiles.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<ToDoItem, TodoItemDto>().ReverseMap();
    }
}

