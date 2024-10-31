using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetByID;

public class GetPetByIdUseCase
{
    public ResponseGetById Execute()
    {
        return new ResponseGetById
        {
            Name = "Pink",
            Birthday = DateTime.Now, //precisa trocar
            Type = Communication.Enums.PetType.Dog,
        };
    }
}
