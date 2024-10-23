using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ProfileCommandsQueries.Commands.Update;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, bool>
{
    private readonly IProfileRepository _profileRepository;

    public UpdateProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var result = await _profileRepository.Update(request.UserName, request.Email, request.Id);

        return result;
    }
}
