using Application.Features.GameService.Commands.CreateGame.Dto;

namespace Application.Features.GameService.Commands.CreateGame;

public record CreateGameRequest(CreateGameRequestModel model) : IRequest<BaseResponse>;
