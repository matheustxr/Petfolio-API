using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Communication.Reponses;
using Petfolio.Communication.Requests;

namespace Petfolio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterPetJson request)
    {
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }
}
