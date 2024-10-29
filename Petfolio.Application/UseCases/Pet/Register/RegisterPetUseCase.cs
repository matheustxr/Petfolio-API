using Petfolio.Communication.Reponses;
using Petfolio.Communication.Requests;

namespace Petfolio.Application.UseCases.Pet.Register;
public class RegisterPetUseCase
{
    public ResponseRegisterPetJson Execute(RequestRegisterPetJson request)
    {
        return new ResponseRegisterPetJson
        {
            Id = 1,
            Name = request.Name,
        };
    }
}
