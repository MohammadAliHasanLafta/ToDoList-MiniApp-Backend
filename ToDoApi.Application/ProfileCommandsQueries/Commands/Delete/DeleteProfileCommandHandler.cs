using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.ProfileCommandsQueries.Commands.Delete;

public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, bool>
{
    private readonly IProfileRepository _profileRepository;

    public DeleteProfileCommandHandler(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        var result = _profileRepository.Delete(request.Id);

        return result;
    }
}
