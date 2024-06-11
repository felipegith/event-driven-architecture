using Application.Command.User;
using Application.Model.Inputmodel;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Apresentation.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRegisterInputModel model, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegisterUserCommand>(model);
        var result = await _mediator.Send(command, cancellationToken);

        if (result.Erros is not null)
            return BadRequest(result);

        return Created(nameof(GetById),result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok();
    }
}