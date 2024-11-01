using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetByID;

public class GetPetByIdUseCase
{
    public ResponseGetByIdPetJson Execute(int Id)
    {
        return new ResponseGetByIdPetJson
        {
            Id = Id,
            Name = "Pink",
            Birthday = new DateTime( year: 2020, month: 1, day: 1 ),
            Type = Communication.Enums.PetType.Dog,
        };
    }
}
