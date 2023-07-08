using Application.Insurances;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddInsuranceRequest request)
        {

            return HandleResult(await Mediator.Send(new Create.Command(request)));
           
            
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id}));
        }


        [HttpGet("Averages")]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new ArithmeticAverages.Query() ));
        }
    }
}



