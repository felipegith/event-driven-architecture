using Application.Command;
using Application.Model.Inputmodel;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Apresentation.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PaymentController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentInputModel model, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<PaymentCommand>(model);
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