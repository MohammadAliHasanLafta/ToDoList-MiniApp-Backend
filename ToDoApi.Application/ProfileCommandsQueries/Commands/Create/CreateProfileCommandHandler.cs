using MediatR;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ProfileCommandsQueries.Commands.Create;

public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, long>
{
    private readonly IProfileRepository _profileRepository;

    public CreateProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<long> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profileId = await _profileRepository.Create(request.UserName, request.Email, request.UserId, request.PhoneNumber);

        return profileId;
    }
}
