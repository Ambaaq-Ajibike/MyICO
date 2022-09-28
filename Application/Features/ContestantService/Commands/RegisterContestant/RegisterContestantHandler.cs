using Application.Common.Interfaces.Repositories;
using Application.Features.ContestantService.Commands.RegisterContestant.Dto;
using Mapster;
using MediatR;

namespace Application.Features.ContestantService.Commands.RegisterContestant;

public class RegisterContestantHandler : IRequestHandler<RegisterContestantRequest, RegisterContestantResponseModel>
{
    private readonly IContestantRepository _contestantRepository;
    public RegisterContestantHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<RegisterContestantResponseModel> Handle(RegisterContestantRequest request, CancellationToken cancellationToken)
    {
        var cont = _contestantRepository.Get(x => x.Email == request.Model.email);
        if(cont != null)return new RegisterContestantResponseModel("A user with these email already exist", false);
       var contestant = new Contestant(request.Model.name, request.Model.email, request.Model.password);
       await _contestantRepository.Create(contestant);
       return new RegisterContestantResponseModel("Contestant Successfully created", true);
    }
}
