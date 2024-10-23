using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ProfileCommandsQueries.Queries.Get;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, UserProfile>
{
    private readonly IProfileRepository _profileRepository;

    public GetProfileQueryHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<UserProfile> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.Get(request.UserId, request.PhoneNumber);
        return profile;
    }
}
