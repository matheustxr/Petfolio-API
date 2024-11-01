using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.Delete;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetByID;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Application.UseCases.Pet.Update;
using Petfolio.Communication.Reponses;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterPetJson request)
    {
        var response = new RegisterPetUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestRegisterPetJson request)
    {
        var useCase = new UpdatePetUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllPetsUseCase();

        var response = useCase.Execute();

        if (response.Pets.Any())
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet]
    [Route("{Id}")]
    [ProducesResponseType(typeof(ResponseGetByIdPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetByID(int Id)
    {
        var useCase = new GetPetByIdUseCase();

        var response = useCase.Execute(Id);

        int idFalse = 7;

        if (Id != idFalse)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteById(int Id)
    {
        var useCase = new DeletePetUseCase();

        useCase.Execute(Id);

        return NoContent();
    }
}
