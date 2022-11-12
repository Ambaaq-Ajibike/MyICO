using System.Net;
using Application.Common.Exeptions;
using Application.Features.ContestantService.Commands.RegisterContestant.Dto;
using Application.Features.ContestantService.Commands.RegisterContestant.Validator;

namespace Application.Features.ContestantService.Commands.RegisterContestant;

public sealed class RegisterContestantHandler : IRequestHandler<RegisterContestantRequest, RegisterContestantResponseModel>
{
    private readonly IContestantRepository _contestantRepository;
    public RegisterContestantHandler(IContestantRepository contestantRepository)
    {
        _contestantRepository = contestantRepository;
    }

    public async Task<RegisterContestantResponseModel> Handle(RegisterContestantRequest request, CancellationToken cancellationToken)
    {
        var validator = new RegisterContestantValidator();
        var validate = await validator.ValidateAsync(request.Model);
        if(!validate.IsValid) throw new ValidationException(validate);
        var cont = await _contestantRepository.Get(x => x.Email.Equals(request.Model.email));
        if(cont != null)throw new CustomException("User with the same email already exist", null, HttpStatusCode.BadRequest);
       var contestant = new Contestant(request.Model.name, request.Model.email, request.Model.password);
       await _contestantRepository.Create(contestant);
       await _contestantRepository.SaveDbChanges();
       return new RegisterContestantResponseModel("Contestant Successfully created", true);
    }
}
