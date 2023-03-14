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

        public IActionResult Index()
        {
            return View();
        }
    }
}