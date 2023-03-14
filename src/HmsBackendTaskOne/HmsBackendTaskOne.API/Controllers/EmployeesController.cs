﻿using HmsBackendTaskOne.Application.Commands.AddEmployee;
using HmsBackendTaskOne.Application.Commands.DeleteEmployee;
using HmsBackendTaskOne.Application.Commands.UpdateEmployee;
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

        public EmployeesController(ISender sender)
        {
            _sender = sender;
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
        public async Task<ActionResult> AddEmployee([FromBody] Employee product)
        {
            var productToReturn = await _sender.Send(new AddEmployeeCommand(product));

            return CreatedAtRoute("GetEmployeeById", new { id = productToReturn.Id },
                productToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee product)
        {
            var productToReturn = await _sender.Send(new UpdateEmployeeCommand(product));

            return CreatedAtRoute("GetEmployeeById", new { id = productToReturn.Id },
                productToReturn);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _sender.Send(new DeleteEmployeeCommand(id));
            return Ok();
        }
    }
}