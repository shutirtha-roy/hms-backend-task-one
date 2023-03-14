using HmsBackendTaskOne.Application.Commands;
using HmsBackendTaskOne.Application.Queries;
using HmsBackendTaskOne.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HmsBackendTaskOne.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());

            return Ok(employees);
        }

        [HttpGet("{id:Guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee product)
        {
            var productToReturn = await _mediator.Send(new AddEmployeeCommand(product));

            return CreatedAtRoute("GetEmployeeById", new { id = productToReturn.Id },
                productToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee product)
        {
            var productToReturn = await _mediator.Send(new UpdateEmployeeCommand(product));

            return CreatedAtRoute("GetEmployeeById", new { id = productToReturn.Id },
                productToReturn);
        }
    }
}