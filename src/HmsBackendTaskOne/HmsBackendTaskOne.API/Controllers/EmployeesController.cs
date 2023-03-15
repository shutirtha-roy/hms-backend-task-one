using Autofac;
using AutoMapper;
using HmsBackendTaskOne.Application.Commands.AddEmployee;
using HmsBackendTaskOne.Application.Commands.DeleteEmployee;
using HmsBackendTaskOne.Application.Commands.UpdateEmployee;
using HmsBackendTaskOne.Application.DTOs;
using HmsBackendTaskOne.Application.Queries.GetAllEmployees;
using HmsBackendTaskOne.Application.Queries.GetEmployeeById;
using HmsBackendTaskOne.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HmsBackendTaskOne.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly ISender _sender;
        private readonly ILifetimeScope _scope;

        public EmployeesController(ISender sender, ILifetimeScope scope)
        {
            _sender = sender;
            _scope = scope;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _sender.Send(new GetEmployeesQuery());

            return Ok(employees);
        }

        [HttpGet("{id:Guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _sender.Send(new GetEmployeeByIdQuery(id));

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeCreateDTO employee)
        {
            await employee.ResolveDependency(_scope);

            var employeeObj = await employee.GetEmployeeeObj();

            var employeeToReturn = await _sender.Send(new AddEmployeeCommand(employeeObj));

            return CreatedAtRoute("GetEmployeeById", new { id = employeeToReturn.Id },
                employeeToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeUpdateDTO employee)
        {
            await employee.ResolveDependency(_scope);

            var employeeObj = await employee.GetEmployeeUpdateObj();

            var employeeToReturn = await _sender.Send(new UpdateEmployeeCommand(employeeObj));

            return CreatedAtRoute("GetEmployeeById", new { id = employeeToReturn.Id },
                employeeToReturn);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sender.Send(new DeleteEmployeeCommand(id));
            return Ok();
        }
    }
}